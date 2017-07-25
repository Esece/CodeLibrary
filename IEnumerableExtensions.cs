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
    }
}
