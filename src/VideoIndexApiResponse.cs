using System.Text.Json.Serialization;

namespace AzureVideoIndexer
{
    public class VideoIndexApiResponse
    {
        [JsonPropertyName("partition")] public string? Partition { get; set; }

        [JsonPropertyName("description")] public string? Description { get; set; }

        [JsonPropertyName("privacyMode")] public string? PrivacyMode { get; set; }

        [JsonPropertyName("state")] public string? State { get; set; }

        [JsonPropertyName("accountId")] public string? AccountId { get; set; }

        [JsonPropertyName("id")] public string? Id { get; set; }

        [JsonPropertyName("name")] public string? Name { get; set; }

        [JsonPropertyName("userName")] public string? UserName { get; set; }

        [JsonPropertyName("created")] public string? Created { get; set; }

        [JsonPropertyName("isOwned")] public bool IsOwned { get; init; }

        [JsonPropertyName("isEditable")] public bool IsEditable { get; init; }

        [JsonPropertyName("isBase")] public bool IsBase { get; init; }

        [JsonPropertyName("durationInSeconds")]
        public int DurationInSeconds { get; init; }

        [JsonPropertyName("duration")] public string? Duration { get; set; }

        [JsonPropertyName("summarizedInsights")]
        public object? SummarizedInsights { get; set; }

        [JsonPropertyName("videos")] public List<Video>? Videos { get; set; }
    }

    public class Video
    {
        [JsonPropertyName("accountId")] public string? AccountId { get; set; }

        [JsonPropertyName("id")] public string? Id { get; set; }

        [JsonPropertyName("state")] public string? State { get; set; }

        [JsonPropertyName("moderationState")] public string? ModerationState { get; set; }

        [JsonPropertyName("reviewState")] public string? ReviewState { get; set; }

        [JsonPropertyName("privacyMode")] public string? PrivacyMode { get; set; }

        [JsonPropertyName("processingProgress")]
        public string? ProcessingProgress { get; set; }

        [JsonPropertyName("failureMessage")] public string? FailureMessage { get; set; }

        [JsonPropertyName("externalId")] public object ExternalId { get; set; }

        [JsonPropertyName("externalUrl")] public object ExternalUrl { get; set; }

        [JsonPropertyName("metadata")] public object Metadata { get; set; }

        [JsonPropertyName("insights")] public Insights Insights { get; set; }
    }

    public class Insights
    {
        [JsonPropertyName("version")] public string? Version { get; set; }

        [JsonPropertyName("duration")] public string? Duration { get; set; }

        [JsonPropertyName("sourceLanguage")] public string? SourceLanguage { get; set; }

        [JsonPropertyName("sourceLanguages")] public List<string>? SourceLanguages { get; set; }

        [JsonPropertyName("language")] public string? Language { get; set; }

        [JsonPropertyName("languages")] public List<string>? Languages { get; set; }

        [JsonPropertyName("transcript")] public List<TranscriptItem>? Transcript { get; set; }

        [JsonPropertyName("keywords")] public List<Keyword>? Keywords { get; set; }

        [JsonPropertyName("faces")] public List<Face>? Faces { get; set; }
    }

    public class TranscriptItem
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("text")] public string? Text { get; set; }
        [JsonPropertyName("confidence")] public double Confidence { get; set; }
        [JsonPropertyName("speakerId")] public int SpeakerId { get; set; }
        [JsonPropertyName("language")] public string? Language { get; set; }
        [JsonPropertyName("instances")] public List<Instance>? Instances { get; set; }
    }

    public class Instance
    {
        [JsonPropertyName("adjustedStart")] public string? AdjustedStart { get; set; }
        [JsonPropertyName("adjustedEnd")] public string? AdjustedEnd { get; set; }
        [JsonPropertyName("start")] public string? Start { get; set; }
        [JsonPropertyName("end")] public string? End { get; set; }
    }

    public class Keyword
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("text")] public string? Text { get; set; }
        [JsonPropertyName("confidence")] public double Confidence { get; set; }
        [JsonPropertyName("language")] public string? Language { get; set; }
        [JsonPropertyName("instances")] public List<Instance>? Instances { get; set; }
    }

    public class Face
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("name")] public string? Name { get; set; }
        [JsonPropertyName("confidence")] public double Confidence { get; set; }
        [JsonPropertyName("description")] public object? Description { get; set; }
        [JsonPropertyName("thumbnailId")] public string? ThumbnailId { get; set; }
        [JsonPropertyName("title")] public object? Title { get; set; }
        [JsonPropertyName("imageUrl")] public object? ImageUrl { get; set; }
        [JsonPropertyName("highQuality")] public bool HighQuality { get; set; }
        [JsonPropertyName("thumbnails")] public List<Thumbnail>? Thumbnails { get; set; }
        [JsonPropertyName("instances")] public List<FaceInstance>? Instances { get; set; }
    }

    public class Thumbnail
    {
        [JsonPropertyName("id")] public string? Id { get; set; }
        [JsonPropertyName("fileName")] public string? FileName { get; set; }
        [JsonPropertyName("instances")] public List<Instance>? Instances { get; set; }
    }

    public class FaceInstance
    {
        [JsonPropertyName("thumbnailsIds")] public List<string>? ThumbnailsIds { get; set; }
        [JsonPropertyName("adjustedStart")] public string? AdjustedStart { get; set; }
        [JsonPropertyName("adjustedEnd")] public string? AdjustedEnd { get; set; }
        [JsonPropertyName("start")] public string? Start { get; set; }
        [JsonPropertyName("end")] public string? End { get; set; }
    }
}