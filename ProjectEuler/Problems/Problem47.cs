using System;
using ProjectEuler.Core;
using ProjectEuler.Math;
using ProjectEuler.Primes;

namespace ProjectEuler.Problems
{
    public class Problem47 : IProjectEulerProblem
    {
        public object Solve()
        {
            const int arbitraryLimit = 200000;
            var sieve = new PrimeSieve(arbitraryLimit);

            var numPrimeFactors = new int[arbitraryLimit];

            foreach (var prime in sieve.Primes)
            {
                for (var number = prime; number < arbitraryLimit; number += prime)
                {
                    numPrimeFactors[number]++;
                }
            }

            return FindTheSmallestOfFourConsecutive(arbitraryLimit, number => numPrimeFactors[number]);
        }

        private long FindTheSmallestOfFourConsecutive(long limit, Func<long, int> getUniquePrimeFactorCount)
        {
            var consecutive = 0;
            long smallerNumber = 0;

            for (long number = 2 * 3 * 5 * 7; number < limit; number++)
            {
                if (getUniquePrimeFactorCount(number) == 4)
                {
                    consecutive += 1;
                    if (consecutive == 1)
                    {
                        smallerNumber = number;
                    }
                }
                else
                {
                    consecutive = 0;
                }

                if (consecutive == 4)
                {
                    return smallerNumber;
                }
            }

            return 0;
        }

        // ~ 3000 ms
        private long SlowSolve()
        {
            return FindTheSmallestOfFourConsecutive(10.Power(6), number => number.GetUniquePrimeFactors().Length);
        }
    }
}