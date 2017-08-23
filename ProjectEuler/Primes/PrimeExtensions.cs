using System.Collections.Generic;
using ProjectEuler.Math;

namespace ProjectEuler.Primes
{
    public static class PrimeExtensions
    {
        public static long[] GetPrimeFactors(this long value, IPrimeProvider provider, bool makeDistinct = false)
        {
            var factors = new List<long>(4);

            foreach (var prime in provider.GetPrimes())
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

        public static long[] GetUniquePrimeFactors(this long value, IPrimeProvider provider) => value.GetPrimeFactors(provider, true);

        public static bool IsPrime(this long value, IPrimeDecider decider) => decider.IsPrime(value);
        public static bool IsComposite(this long value, IPrimeDecider decider) => !decider.IsPrime(value);
    }
}