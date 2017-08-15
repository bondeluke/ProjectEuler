using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Math
{
    public static class Integer
    {
        public static bool IsMultipleOf(this long value, long divisor) => value % divisor == 0;

        public static bool IsMultipleOfAny(this long value, params long[] divisors)
        {
            return divisors.Any(divisor => value.IsMultipleOf(divisor));
        }

        public static bool IsEven(this long value) => value.IsMultipleOf(2);

        public static bool IsOdd(this long value) => !value.IsMultipleOf(2);

        public static long Squared(this long value) => value * value;

        public static long Product(this IEnumerable<long> values)
        {
            return values.Aggregate((left, right) => left * right);
        }

        public static bool IsPalindrome(this long value) => value.ToString().IsPalindrome();

        public static IEnumerable<long> GetNDigitIntegers(byte N)
        {
            var range = GetNumberOfLength(N);

            for (var integer = range.Lower; integer < range.Upper; integer++)
                yield return integer;
        }

        public static Range GetNumberOfLength(byte length)
        {
            var lower = 10.Power(length - 1);
            var upper = 10.Power(length);

            return new Range(lower, upper);
        }

        public static IEnumerable<long> Range(long lower, long upper, long step = 1)
        {
            for (var number = lower; number < upper; number += step)
                yield return number;
        }

        public static DivisionResult DivideBy(this long number, long divisor)
        {
            var remainder = number % divisor;
            var quotient = (number - remainder) / divisor;

            return new DivisionResult(quotient, remainder);
        }
    }
}