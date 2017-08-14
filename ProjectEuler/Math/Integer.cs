using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Math
{
    public static class Integer
    {
        public static bool IsMultipleOf(this long value, long divisor)
        {
            return value % divisor == 0;
        }

        public static bool IsMultipleOfAny(this long value, params long[] divisors)
        {
            return divisors.Any(divisor => value.IsMultipleOf(divisor));
        }

        public static bool IsEven(this long value)
        {
            return value.IsMultipleOf(2);
        }

        public static bool IsOdd(this long value)
        {
            return !value.IsMultipleOf(2);
        }

        public static long Squared(this long value)
        {
            return value * value;
        }

        public static bool IsPalindrome(this long value)
        {
            return value.ToString().IsPalindrome();
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
            var range = GetAllNDigitNumbers(N);

            for (var integer = range.Lower; integer < range.Upper; integer++)
                yield return integer;
        }

        public static Range GetAllNDigitNumbers(byte N)
        {
            var lower = 10.Power(N - 1);
            var upper = 10.Power(N);

            return new Range(lower, upper);
        }

        public static IEnumerable<long> Range(long lower, long upper)
        {
            for (var number = lower; number <= upper; number++)
                yield return number;
        }

        public static bool IsCoPrimeWith(this long number, long candidate)
        {
            return number.Gcd(candidate) == 1;
        }

        public static long[] GetLesserCoPrimes(this long number)
        {
            // Not performant
            return Range(1, number - 1)
                .Where(n => n.IsCoPrimeWith(number))
                .ToArray();
        }

        public static long Gcd(this long a, long b)
        {
            // http://www.vcskicks.com/euclidean-gcd.php
            while (true)
            {
                if (b == 0) return a;
                var a1 = a;
                a = b;
                b = a1 % b;
            }
        }
    }
}
