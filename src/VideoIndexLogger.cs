namespace AzureVideoIndexer;

public static class VideoIndexLogger
{
    private static bool HasVideos(VideoIndexApiResponse videoIndex) => videoIndex.Videos is { Count: > 0 };
    private static bool HasTranscript(Video video) => video.Insights.Transcript is { Count: > 0 };
    private static bool HasKeywords(Video video) => video.Insights.Keywords is { Count: > 0 };
    private static bool HasFaces(Video video) => video.Insights.Faces is { Count: > 0 };
    private static bool HasInstances(Keyword keyword) => keyword.Instances is { Count: > 0 };
    private static bool HasInstances(TranscriptItem transcriptItem) => transcriptItem.Instances is { Count: > 0 };
    private static bool HasInstance(Face face) => face.Instances is { Count: > 0 };
    private static Video GetFirstVideo(VideoIndexApiResponse videoIndex) => videoIndex.Videos![0];

    private static void LogInstances(List<Instance> instances)
    {
        foreach (var instance in instances)
        {
            Console.WriteLine($"Instance: {instance.Start} - {instance.End}");
        }
    }

    public static void LogTranscript(VideoIndexApiResponse videoIndex)
    {
        if (!HasVideos(videoIndex)) return;
        var firstVideo = GetFirstVideo(videoIndex);

        if (!HasTranscript(firstVideo)) return;

        foreach (var trans in firstVideo.Insights.Transcript!)
        {
            Console.WriteLine($"Transcript: {trans.Text}, Confidence: {trans.Confidence}");

            if (!HasInstances(trans)) continue;
            LogInstances(trans.Instances!);
        }
    }

    public static void LogKeywords(VideoIndexApiResponse videoIndex)
    {
        if (!HasVideos(videoIndex)) return;
        var firstVideo = GetFirstVideo(videoIndex);

        if (!HasKeywords(firstVideo)) return;

        foreach (var keyword in firstVideo.Insights.Keywords!)
        {
            Console.WriteLine($"Keyword: {keyword.Text}, Confidence: {keyword.Confidence}");

            if (!HasInstances(keyword)) continue;
            LogInstances(keyword.Instances!);
        }
    }


    public static void LogFaces(VideoIndexApiResponse videoIndex)
    {
        if (!HasVideos(videoIndex)) return;
        var firstVideo = GetFirstVideo(videoIndex);

        if (!HasFaces(firstVideo)) return;

        foreach (var face in firstVideo.Insights.Faces!)
        {
            Console.WriteLine($"Face: {face.Name}, Confidence: {face.Confidence}");

            if (!HasInstance(face)) continue;
            foreach (var instance in face.Instances!)
            {
                Console.WriteLine($"Instance: {instance.Start} - {instance.End}");
            }
        }
    }

    public static void LogVideoInfo(VideoIndexApiResponse videoIndex)
    {
        if (!HasVideos(videoIndex)) return;

        var firstVideo = GetFirstVideo(videoIndex);
        Console.WriteLine($"Video ID: {firstVideo.Id}");
        Console.WriteLine($"Video Name: {videoIndex.Name}");
        Console.WriteLine($"Duration: {firstVideo.Insights.Duration}");
        Console.WriteLine($"Language: {firstVideo.Insights.Language}");
    }
}