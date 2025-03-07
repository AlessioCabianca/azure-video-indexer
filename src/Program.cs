using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AzureVideoIndexer;

public abstract class Program
{
    public static async Task Main(string[] args)
    {
        var host = BuildHost();

        var videoIndexerService = host.Services.GetRequiredService<VideoIndexerService>();

        Console.Write("Enter Video ID: ");
        var videoId = Console.ReadLine() ?? throw new InvalidOperationException("Video ID cannot be null");

        var videoAccessToken = await videoIndexerService.GetVideoAccessTokenAsync(videoId);

        var videoIndex = await videoIndexerService.GetVideoIndexAsync(videoId, videoAccessToken);

        Console.WriteLine("Video Info:");
        VideoIndexLogger.LogVideoInfo(videoIndex);
        Console.WriteLine(string.Empty);

        Console.WriteLine("Transcript:");
        VideoIndexLogger.LogTranscript(videoIndex);
        Console.WriteLine(string.Empty);

        Console.WriteLine("Keywords:");
        VideoIndexLogger.LogKeywords(videoIndex);
        Console.WriteLine(string.Empty);

        Console.WriteLine("Faces:");
        VideoIndexLogger.LogFaces(videoIndex);
    }

    private static IHost BuildHost() =>
        Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((_, config) => { config.AddUserSecrets<Program>(); })
            .ConfigureServices((_, services) => { services.AddHttpClient<VideoIndexerService>().RemoveAllLoggers(); })
            .Build();
}