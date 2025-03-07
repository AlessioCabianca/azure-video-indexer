using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace AzureVideoIndexer;

public class VideoIndexerService(IConfiguration configuration, HttpClient httpClient)
{
    private readonly string _apiUrl = configuration["ApiUrl"]!;
    private readonly string _apiKey = configuration["ApiKey"]!;
    private readonly string _accountId = configuration["AccountId"]!;
    private readonly string _accountLocation = configuration["AccountLocation"]!;

    public async Task<string> GetVideoAccessTokenAsync(string videoId)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get,
            $"{_apiUrl}/auth/{_accountLocation}/Accounts/{_accountId}/Videos/{videoId}/AccessToken?allowEdit=true");

        request.Headers.Add("Ocp-Apim-Subscription-Key", _apiKey);
        var response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var token = await response.Content.ReadAsStringAsync();
        return token.Replace("\"", "");
    }

    public async Task<VideoIndexApiResponse> GetVideoIndexAsync(string videoId, string accessToken)
    {
        var url =
            $"{_apiUrl}/{_accountLocation}/Accounts/{_accountId}/Videos/{videoId}/Index?language=it-IT&reTranslate=false&includeStreamingUrls=false&includedInsights=Faces,Transcript,Keywords,Brands&includeSummarizedInsights=false&accessToken={accessToken}";

        var response = await httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<VideoIndexApiResponse>(content) ??
               throw new InvalidCastException("Cannot deserialize video index");
    }
}