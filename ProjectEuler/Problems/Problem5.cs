using System.Numerics;
using ProjectEuler.Core;
using ProjectEuler.Math;
using ProjectEuler.Primes;

namespace ProjectEuler.Problems
{
    // What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
    public class Problem5 : IProjectEulerProblem
    {
        public object Solve()
        {
            // Easily done by hand, but generalized to be fast for numbers as large as 10^5 
            // (Fun fact: The product at this magnitude is an insane 43452 digits)
            var number = 20;

            var sieve = new PrimeSieve(number);

            BigInteger product = 1;

            foreach (var prime in sieve.GetPrimes())
            {
                product *= GetLargestPowerOfPrime(prime, number);
            }

            return product;
        }

        // 1072 ms for number = 5 * 10^5  
        //   13 ms for number = 20
        private long GetLargestPowerOfPrime(long prime, long number)
        {
            return prime.Power(System.Math.Log(number, prime).Floor().ToInt());
        }

        // 1064 ms for 5 * 10^5
        //   13 ms for number = 20
        private long GetLargestPowerOfPrimeAlt(long prime, long number)
        {
            var greatestPowerOfPrime = prime;

            for (var power = 2; ; power++)
            {
                var powerOfPrime = prime.Power(power);

                if (powerOfPrime > number)
                {
                    return greatestPowerOfPrime;
                }

                greatestPowerOfPrime = powerOfPrime;
            }
        }

        public long Benchmark => 13;

        public object ExpectedSolution => 232792560.ToBigInteger();
    }
}
