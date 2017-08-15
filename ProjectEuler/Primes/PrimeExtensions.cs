using System.Collections.Generic;
using ProjectEuler.Math;

namespace ProjectEuler.Primes
{
    public static class PrimeExtensions
    {
        private static readonly PrimeCollection _primes = new PrimeCollection();
        private static readonly PrimeSieve _sieve = new PrimeSieve(2000000);

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

        public static long[] GetUniquePrimeFactors(this long value) => value.GetPrimeFactors(true);

        // Not thread safe
        public static bool IsPrime(this long number) => _primes.IsPrime(number);

        public static bool IsComposite(this long number) => !IsPrime(number);
    }
}