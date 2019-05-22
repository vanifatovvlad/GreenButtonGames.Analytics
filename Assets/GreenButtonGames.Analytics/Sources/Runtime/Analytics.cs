using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace GreenButtonGames.Analytics
{
    public class Analytics : IAnalytics
    {
        private readonly IAnalyticsAdapter[] _adapters;

        public Analytics([NotNull] IAnalyticsAdapter[] adapters)
        {
            _adapters = adapters ?? throw new ArgumentNullException(nameof(adapters));
        }

        public void Send(string eventName, params AnalyticsArg[] args)
        {
            if (eventName == null) throw new ArgumentNullException(nameof(eventName));
            if (args == null) throw new ArgumentNullException(nameof(args));

            foreach (var adapter in _adapters)
            {
                adapter.Send(eventName, args);
            }
        }
    }
}