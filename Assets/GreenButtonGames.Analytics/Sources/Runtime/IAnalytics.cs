using JetBrains.Annotations;

namespace GreenButtonGames.Analytics
{
    public interface IAnalytics
    {
        void Send([NotNull] string eventName, [NotNull] params AnalyticsArg[] args);
    }
}