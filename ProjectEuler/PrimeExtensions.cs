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
        public static ICollection<long> GeneratePrimeFactors(this long subject, bool repetition = false)
        {
            var factors = new List<long>();

            var seq = new PrimeSequence();

            long prime;
            while (subject != 1)
            {
                prime = seq.Next();
                while(subject.IsMultipleOf(prime))
                {
                    factors.Add(prime);
                    subject /= prime;
                }
            }

            return repetition ? factors.Distinct().ToList() : factors;
        }

        public static ICollection<long> GenerateUniquePrimeFactors(this long subject)
        {
            return subject.GeneratePrimeFactors(true);
        }

        public static bool IsPrime(this long subject)
        {
            return new PrimeSequence().Contains(subject);
        }
    }
}
