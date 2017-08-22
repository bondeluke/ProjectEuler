using ProjectEuler.Core;
using ProjectEuler.Primes;

namespace ProjectEuler.Problems
{
    // Problem 7: What is the 10,001st prime number?
    public class Problem7 : IProjectEulerProblem
    {
        public object ExpectedSolution => 104743;
        public long Benchmark => 61;

        public object Solve()
        {
            var primes = new ExpandablePrimes();

            return primes.GetNthPrime(10001);
        }
    }
}