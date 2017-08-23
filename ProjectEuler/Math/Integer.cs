using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using static System.Int32;

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

        public static DivisionResult<long> DivideBy(this long number, long divisor)
        {
            var remainder = number % divisor;
            var quotient = (number - remainder) / divisor;

            return new DivisionResult<long>(quotient, remainder);
        }

        public static DivisionResult<int> DivideBy(this int number, int divisor)
        {
            var remainder = number % divisor;
            var quotient = (number - remainder) / divisor;

            return new DivisionResult<int>(quotient, remainder);
        }

        public static long SumDigits(this long number) => number.ToString().Select(c => Parse(c.ToString())).Sum();

        public static long SumDigits(this BigInteger number) => number.ToString().Select(c => Parse(c.ToString())).Sum();

        public static long NumDigits(this BigInteger number) => number.ToString().Length;

        public static bool IsHarshad(this long number) => number.SumDigits().Divides(number);

        public static long TruncateRight(this long number) => number.ToString().StripRight().ToLong();

        public static long Concat(this long number, long anotherNumber) => number.ToString().Plus(anotherNumber).ToLong();

        public static BigInteger ToBigInteger(this int  number) => new BigInteger(number);

        public static BigInteger ToBigInteger(this long  number) => new BigInteger(number);

        public static double NthRoot(this long number, int n) => System.Math.Pow(number, (double) 1 / n);
    }
}