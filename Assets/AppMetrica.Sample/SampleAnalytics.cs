using GreenButtonGames.Analytics;

static class SampleAnalytics
{
    // Flat: sample_event
    // - key1 = value1
    // - key2 = value1

    // Hierarchical(AppMetrica): {
    //    "key1": "value1",
    //    "key2": "value1"
    // }
    public static void SendSampleEvent(this IAnalytics analytics, string value1, string value2)
    {
        analytics.Send("sample_event",
            new AnalyticsArg("key1", value1),
            new AnalyticsArg("key2", value2));
    }
}