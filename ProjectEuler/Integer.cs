using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Common;

namespace ProjectEuler
{
    public static class Integer
    {
        public static bool IsMultipleOf(this long subject, long value)
        {
            return subject % value == 0;
        }

        public static bool IsMultipleOf(this long subject, params long[] values)
        {
            foreach (var value in values)
                if (subject.IsMultipleOf(value))
                    return true;

            return false;
        }

        public static bool IsEven(this long subject)
        {
            return subject.IsMultipleOf(2);
        }

        public static bool IsOdd(this long subject)
        {
            return !subject.IsMultipleOf(2);
        }

        public static long Square(this long subject)
        {
            return subject * subject;
        }

        public static bool IsPalindrome(this long subject)
        {
            return subject.ToString().IsPalindrome();
        }

        public static IEnumerable<long> To(this long from, long to)
        {
            while (from <= to)
                yield return from++;
        }

        public static long Largest(this IEnumerable<long> collection)
        {
            return collection.Condition(long.MinValue, (x, y) => x > y);
        }

        public static long Smallest(this IEnumerable<long> collection)
        {
            return collection.Condition(long.MaxValue, (x, y) => x < y);
        }

        private static long Condition(this IEnumerable<long> collection, long candidate, Func<long, long, bool> condition)
        {
            foreach (var number in collection)
                if (condition(number, candidate))
                    candidate = number;

            return candidate;
        }

        public static IEnumerable<long> GetNDigitIntegers(byte N)
        {
            var range = GetNDigitBoundaries(N);

            for (long integer = range.Lower; integer < range.Upper; integer++)
                yield return integer;
        }

        public static Range GetNDigitBoundaries(byte N)
        {
            long lower = Convert.ToInt64(Math.Pow(10, N - 1));
            long upper = Convert.ToInt64(Math.Pow(10, N));

            return new Range(lower, upper);
        }

        public static IEnumerable<long> Range(int lower, int upper)
        {
            for (var number = lower; number <= upper; number++)
                yield return number;
        }

        public static IEnumerable<long> First(int upper)
        {
            return Range(1, upper);
        }
    }
}
