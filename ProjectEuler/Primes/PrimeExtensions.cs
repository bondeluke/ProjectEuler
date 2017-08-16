using System.Collections.Generic;
using ProjectEuler.Math;

namespace ProjectEuler.Primes
{
    public static class PrimeExtensions
    {
        private static readonly ExpandablePrimes _primes = new ExpandablePrimes();
        private static readonly PrimeSieve _sieve = new PrimeSieve(10000001); // That's a lot of primes

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
        public static bool IsPrime(this long number) => _sieve.IsPrime(number);

        public static bool IsComposite(this long number) => !IsPrime(number);
    }
}