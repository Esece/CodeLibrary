using System;
using System.Collections.Generic;
using System.Linq;

namespace S78.Extensions
{
    public static class IEnumerableExtensions
    {
        public static T Median<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var all = source.ToArray();

            if (all.Length == 0)
            {
                throw new InvalidOperationException("Sequence contains no elements");
            }

            if (all.Length > 1)
            {
                var ordred = all.OrderBy(ms => ms).ToArray();

                if (all.Length == 2 || all.Length == 3)
                {
                    return ordred[1];
                }
                else
                {
                    return ordred[ordred.Length / 2];
                }
            }
            else
            {
                return all[0];
            }
        }
        
        public static IEnumerable<T[]> TakeEvery<T>(this IEnumerable<T> source, int every)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            
            var group = new List<T>(every);

            foreach (var element in source)
            {
                if (group.Count == every)
                {
                    yield return group.ToArray();

                    group = new List<T>(every);
                }

                group.Add(element);
            }

            if (group.Count > 0)
            {
                yield return group.ToArray();
            }
        }
        
        public static IEnumerable<T> TakeUniqueSequence<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            
            bool first = true;
            T previous = default(T);
            var type = typeof(T);

            foreach (T s in source)
            {
                if (first)
                {
                    previous = s;
                    yield return s;
                    first = false;
                }
                else if (!EqualityComparer<T>.Default.Equals(s, previous))
                {
                    yield return s;
                    previous = s;
                }
            }
        }
        
        public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }
            
            foreach (var s in source)
            {
                if (!predicate(s))
                {
                    break;
                }

                yield return s;
            }
        }
    }
}
