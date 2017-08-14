using System;
using ProjectEuler.Math;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Primes
{
    public static class PrimeExtensions
    {
        public static long[] GetPrimeFactors(this long value, bool makeDistinct = false)
        {
            var factors = new List<long>(4);

            foreach (var prime in _sieve.Primes)
            {
                var primeWasAdded = false;

                while (prime.Divides(value))
                {
                    if (!(primeWasAdded && makeDistinct))
                    {
                        primeWasAdded = true;
                        factors.Add(prime);
                    }

                    value /= prime;
                }

                if (value == 1)
                    break;
            }

            return factors.ToArray();
        }

        public static long[] GetUniquePrimeFactors(this long value)
        {
            return value.GetPrimeFactors(true);
        }

        // Not thread safe
        public static bool IsPrime(this long number)
        {
            return _primes.IsPrime(number);
        }

        private static readonly PrimeCollection _primes = new PrimeCollection();
        private static readonly PrimeSieve _sieve = new PrimeSieve(2000000);
    }
}
