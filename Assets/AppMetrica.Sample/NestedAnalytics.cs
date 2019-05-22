using GreenButtonGames.Analytics;

static class NestedAnalytics
{
    // Flat: nested_event
    // - key1 = value1
    // - key2 = value2

    // Hierarchical: {
    //    "key1": {
    //        "value1": "value2"
    //    }
    // }
    public static void SendNestedEvent(this IAnalytics analytics, string value1, string value2)
    {
        analytics.Send("nested_event", new AnalyticsArg("key1", value1)
        {
            new AnalyticsArg("key2", value2)
        });
    }
}