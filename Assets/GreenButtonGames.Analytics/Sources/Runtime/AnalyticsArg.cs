using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace GreenButtonGames.Analytics
{
    public struct AnalyticsArg : IEnumerable<AnalyticsArg>
    {
        private List<AnalyticsArg> _args;

        public string Key { get; }
        public string StringValue { get; }
        public int IntValue { get; }
        public ArgType Type { get; }
        public List<AnalyticsArg> Nodes => _args;

        public string Value
        {
            get
            {
                switch (Type)
                {
                    case ArgType.String:
                        return StringValue;
                    case ArgType.Int:
                        return IntValue.ToString();
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public enum ArgType
        {
            String,
            Int,
        }

        public AnalyticsArg([NotNull] string key, string val)
        {
            Key = key ?? throw new ArgumentNullException(nameof(key));
            _args = null;
            StringValue = val;
            IntValue = 0;
            Type = ArgType.String;
        }

        public AnalyticsArg([NotNull] string key, int val)
        {
            Key = key ?? throw new ArgumentNullException(nameof(key));
            _args = null;
            IntValue = val;
            StringValue = null;
            Type = ArgType.Int;
        }

        public void Add(AnalyticsArg arg)
        {
            if (_args == null)
                _args = new List<AnalyticsArg>();

            _args.Add(arg);
        }

        public IEnumerator<AnalyticsArg> GetEnumerator()
        {
            if (_args == null)
                _args = new List<AnalyticsArg>();

            foreach (var arg in _args)
            {
                yield return arg;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}