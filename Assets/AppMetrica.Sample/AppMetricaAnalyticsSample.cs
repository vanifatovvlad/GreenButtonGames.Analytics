using System.Collections.Generic;
using GreenButtonGames.Analytics;
using GreenButtonGames.Analytics.AppMetrica.Sources;
using GreenButtonGames.Analytics.DebugLog;
using UnityEngine;

public class AppMetricaAnalyticsSample : MonoBehaviour
{
    private IAnalytics _analytics;

    private void Awake()
    {
        Invoke(nameof(SendSampleEvent), 2f);
    }

    private void SendSampleEvent()
    {
        _analytics = new Analytics(new IAnalyticsAdapter[]
        {
            new DebugLogAnalyticsAdapter(),
            new AppMetricaAnalyticsAdapter(new AppMetricaImpl()),
        });

        _analytics.SendSampleEvent("value1", "value2");

        _analytics.SendNestedEvent("value1", "value2");

        _analytics.SendAdsEvent(
            "Interstitial",
            "gameDouble",
            "No Fill",
            "Network Error",
            "AdMob");
    }
}

class AppMetricaImpl : IAppMetricaImpl
{
    public void ReportEvent(string message, Dictionary<string, object> parameters)
    {
        AppMetrica.Instance.ReportEvent(message, parameters);
    }
}