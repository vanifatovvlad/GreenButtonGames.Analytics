using System.Collections.Generic;

namespace GreenButtonGames.Analytics.AppMetrica.Sources
{
    public class AppMetricaAnalyticsAdapter : IAnalyticsAdapter
    {
        private readonly IAppMetricaImpl _appMetricaImpl;

        public AppMetricaAnalyticsAdapter(IAppMetricaImpl appMetricaImpl)
        {
            _appMetricaImpl = appMetricaImpl;
        }

        public void Send(string eventName, AnalyticsArg[] args)
        {
            var dict = new Dictionary<string, object>();

            foreach (var arg in args)
            {
                dict.Add(arg.Key, BuildArg(arg));
            }

            _appMetricaImpl.ReportEvent(eventName, dict);
        }

        private object BuildArg(AnalyticsArg arg)
        {
            if (arg.Nodes == null || arg.Nodes.Count == 0)
            {
                return arg.Value;
            }

            if (arg.Nodes.Count == 1)
            {
                return new Dictionary<string, object>
                {
                    [arg.Value] = BuildArg(arg.Nodes[0])
                };
            }

            var dict = new Dictionary<string, object>();
            foreach (var subArg in arg.Nodes)
            {
                dict.Add(subArg.Key, BuildArg(subArg));
            }

            return new Dictionary<string, object> {[arg.Value] = dict};
        }
    }
}