using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Common;

namespace ProjectEuler
{
    public static class PrimeExtensions
    {
        public static ICollection<long> GetPrimeFactors(this long value, bool repetition = false)
        {
            var factors = new List<long>();

            var seq = new PrimeSieve();

            long prime;
            while (value != 1)
            {
                prime = seq.Next();
                while(value.IsMultipleOf(prime))
                {
                    factors.Add(prime);
                    value /= prime;
                }
            }

            return repetition ? factors.Distinct().ToList() : factors;
        }

        public static ICollection<long> GenerateUniquePrimeFactors(this long value)
        {
            return value.GetPrimeFactors(true);
        }

        // Not thread safe
        public static bool IsPrime(this long number)
        {
            return _primes.IsPrime(number);
        }

        private static PrimeCollection _primes = new PrimeCollection();
    }
}
