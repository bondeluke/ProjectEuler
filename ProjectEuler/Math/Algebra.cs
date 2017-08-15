using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Math
{
    public static class Algebra
    {
        public static bool Divides(this long divisor, long value)
        {
            return value % divisor == 0;
        }

        public static long[] Divisors(this long number)
        {
            var divisors = new List<long>();

            for (long d = 1; d <= number.Sqrt(); d++)
            {
                if (!d.Divides(number)) continue;

                divisors.Add(d);
                if (number / d != d)
                {
                    divisors.Add(number / d);
                }
            }

            return divisors.OrderBy(div => div).ToArray();
        }

        public static bool IsCoPrimeWith(this long number, long candidate)
        {
            return Gcd(number, candidate) == 1;
        }

        public static long[] GetTotatives(this long number)
        {
            // Not performant
            return Integer.Range(1, number)
                .Where(n => n.IsCoPrimeWith(number))
                .ToArray();
        }

        public static long Gcd(long a, long b)
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

        public static long Lcm(long a, long b)
        {
            // Follow from the fact that lcm(a, b) * gcd (a, b) = ab;
            return a * b / Gcd(a, b);
        }

        public static long Phi(this long number)
        {
            return _sieve.Phi(number);
        }

        private static readonly PhiSieve _sieve = new PhiSieve(1000000);
    }
}
