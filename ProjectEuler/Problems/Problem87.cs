using System.Collections.Generic;
using System.Linq;
using ProjectEuler.Core;
using ProjectEuler.Math;
using ProjectEuler.Primes;

namespace ProjectEuler.Problems
{
    // How many numbers below fifty million can be expressed as the sum of a prime square, prime cube, and prime fourth power?
    // This is the quintessential PE problem
    public class Problem87 : IProjectEulerProblem
    {
        public object ExpectedSolution => 1097343;
        public long Benchmark => 414;

        public object Solve()
        {
            var limit = 5 * 10.Power(7);

            var primeLimit = limit.Sqrt().Ceiling().ToLong();

            var sieve = new PrimeSieve(primeLimit);

            var squareRootPrimes = sieve.GetPrimes().ToArray();
            var cubeRootPrimes = squareRootPrimes.Where(p => p <= limit.NthRoot(3)).ToArray();
            var fourthRootPrimes = squareRootPrimes.Where(p => p <= limit.NthRoot(4)).ToArray();

            var numbers = new HashSet<long>();

            foreach (var p1 in squareRootPrimes)
            {
                foreach (var p2 in cubeRootPrimes)
                {
                    var partialSum = p1.Power(2) + p2.Power(3);

                    if (partialSum > limit) break;

                    foreach (var p3 in fourthRootPrimes)
                    {
                        var sum = partialSum + p3.Power(4);

                        if (sum < limit && !numbers.Contains(sum))
                            numbers.Add(sum);
                    }
                }
            }

            return numbers.Count;
        }
    }
}