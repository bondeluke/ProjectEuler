using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    public static class EnumerableExtensions
    {
        public static void IjFor<T>(this T[] array, Action<int, int> indexAction)
        {
            for (var i = 0; i < array.Length; i++)
            {
                for (var j = i + 1; j < array.Length; j++)
                {
                    indexAction(i, j);
                }
            }
        }

        public static void IjForEach<T>(this T[] array, Action<T, T> valueAction)
        {
            for (var i = 0; i < array.Length; i++)
            {
                for (var j = i + 1; j < array.Length; j++)
                {
                    valueAction(array[i], array[j]);
                }
            }
        }

        public static void AddSafe<TKey, TValue>(this Dictionary<TKey, List<TValue>> d, TKey key, TValue value)
        {
            if (!d.ContainsKey(key))
            {
                d[key] = new List<TValue>();
            }

            d[key].Add(value);
        }
    }
}
