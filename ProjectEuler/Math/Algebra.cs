﻿using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.Math
{
    public static class Algebra
    {
        public static bool Divides(this long divisor, long value) => value % divisor == 0;

        public static bool AreCoprime(long a, long b) => Gcd(a.Abs(), b.Abs()) == 1;

        public static bool AreCoprime(BigInteger a, BigInteger b) => Gcd(a.Abs(), b.Abs()) == 1;

        public static long[] GetTotatives(this long number)
        {
            // Not performant
            return Integer.Range(1, number)
                .Where(n => AreCoprime(n, number))
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

        public static BigInteger Gcd(BigInteger a, BigInteger b)
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

        public static long Lcm(long a, long b) => a * b / Gcd(a, b);

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
    }
}