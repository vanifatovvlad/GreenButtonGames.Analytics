using System.Collections.Generic;

namespace GreenButtonGames.Analytics
{
    public class AnalyticsArgTraverse
    {
        public delegate TDest AnalyticsArgMapper<out TDest>(AnalyticsArg arg);
        //public delegate TDest Fold<TDest>(string key, TDest[] child);
        //public delegate TDest FoldFinal<out TDest>(string key, AnalyticsArg arg);

        public static IEnumerable<TDest> Linear<TDest>(AnalyticsArg[] args, AnalyticsArgMapper<TDest> mapper)
        {
            if (args == null)
                yield break;

            foreach (AnalyticsArg arg in args)
            {
                foreach (TDest dest in Linear(arg, mapper))
                {
                    yield return dest;
                }
            }
        }

        public static IEnumerable<TDest> Linear<TDest>(List<AnalyticsArg> args, AnalyticsArgMapper<TDest> mapper)
        {
            if (args == null)
                yield break;

            foreach (AnalyticsArg arg in args)
            {
                foreach (TDest dest in Linear(arg, mapper))
                {
                    yield return dest;
                }
            }
        }

        public static IEnumerable<TDest> Linear<TDest>(AnalyticsArg arg, AnalyticsArgMapper<TDest> mapper)
        {
            yield return mapper.Invoke(arg);

            foreach (TDest dest in Linear(arg.Nodes, mapper))
            {
                yield return dest;
            }
        }

        /*
        public static TDest Hierarchical<TDest>(AnalyticsArg arg,
            Fold<TDest> fold,
            FoldFinal<TDest> foldFinal)
        {
            return arg.Node == null
                ? foldFinal.Invoke(arg.Key, arg)
                : fold.Invoke(arg.Key, HierarchicalInternal(arg.Node, arg.Value, fold, foldFinal));
        }

        private static TDest HierarchicalInternal<TDest>(AnalyticsArg arg, string key,
            Fold<TDest> fold,
            FoldFinal<TDest> foldFinal)
        {
            return arg.Node == null
                ? foldFinal.Invoke(key, arg)
                : fold.Invoke(key, HierarchicalInternal(arg.Node, arg.Value, fold, foldFinal));
        }
        */
    }
}