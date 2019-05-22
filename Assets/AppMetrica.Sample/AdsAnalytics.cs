using GreenButtonGames.Analytics;

static class AdsAnalytics
{
    // Flat: ads
    // - Type = Interstitial
    // - placement = gameDouble
    // - result = No Fill
    // - provider = AdMob
    // - reason = Network Error

    // Hierarchical: {
    //    "Type": {
    //        "Interstitial": {
    //            "placement": {
    //                "gameDouble": "No Fill"
    //            },
    //            "provider": {
    //                "AdMob": "Network Error"
    //            }
    //        }
    //    }
    //}
    public static void SendAdsEvent(this IAnalytics analytics, string adType, string placement, string result,
        string reason, string provider)
    {
        analytics.Send("ads",
            new AnalyticsArg("Type", adType)
            {
                new AnalyticsArg("placement", placement)
                {
                    new AnalyticsArg("result", result)
                },
                new AnalyticsArg("provider", provider)
                {
                    new AnalyticsArg("reason", reason)
                }
            });
    }
}