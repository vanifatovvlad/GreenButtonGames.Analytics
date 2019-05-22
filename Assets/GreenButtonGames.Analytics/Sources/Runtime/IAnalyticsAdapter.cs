using JetBrains.Annotations;

namespace GreenButtonGames.Analytics
{
    public interface IAnalyticsAdapter
    {
        void Send([NotNull] string eventName, [NotNull] AnalyticsArg[] args);
    }
}