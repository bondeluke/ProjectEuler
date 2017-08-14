﻿using System;
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

        public static bool IsMultipleOf(this long value, params long[] divisors)
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
            var lower = 10.Power(N-1).ToLong();
            var upper = 10.Power(N).ToLong();

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