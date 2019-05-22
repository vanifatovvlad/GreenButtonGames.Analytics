using System.Text;
using UnityEngine;

namespace GreenButtonGames.Analytics.DebugLog
{
    public class DebugLogAnalyticsAdapter : IAnalyticsAdapter
    {
        public void Send(string eventName, AnalyticsArg[] args)
        {
            var sb = new StringBuilder();
            sb.Append("Analytics: ").AppendLine(eventName);
            foreach (var element in AnalyticsArgTraverse.Linear(args, analyticsArg => analyticsArg))
            {
                sb.Append(" - ").Append(element.Key).Append(" = ").AppendLine(element.Value);
            }

            Debug.Log(sb.ToString());
        }
    }
}