using System.Collections.Generic;

namespace GreenButtonGames.Analytics.AppMetrica.Sources
{
    public interface IAppMetricaImpl
    {
        void ReportEvent(string message, Dictionary<string, object> parameters);
    }
}