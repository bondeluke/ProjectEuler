using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerTools
{
    public class Factorization
    {
        public static ICollection<long> PrimeFactors(long number)
        {
            List<long> factors = new List<long>();
            PrimeGenerator primeGen = new PrimeGenerator();

            foreach (long prime in primeGen.Range(Convert.ToInt32(Math.Sqrt(number))))
                while (Divides(prime, number))
                {
                    factors.Add(prime);
                    number /= prime;
                }

            return factors;
        }

        private static bool Divides(long divisor, long number)
        {
            return number % divisor == 0;
        }
    }
}
