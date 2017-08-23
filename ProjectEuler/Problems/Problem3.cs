using System.Linq;
using ProjectEuler.Core;
using ProjectEuler.Math;
using ProjectEuler.Primes;

namespace ProjectEuler.Problems
{
    // Problem 3: What is the largest prime factor of the number 600851475143?
    public class Problem3 : IProjectEulerProblem
    {
        private const long LargeNumber = 600851475143;

        public object ExpectedSolution => 6857;
        public long Benchmark => 224;

        public object Solve()
        {
            var sieve = new PrimeSieve(LargeNumber.Sqrt().Ceiling().ToLong());

            return LargeNumber.GetPrimeFactors(sieve).Max();
        }
    }
}
