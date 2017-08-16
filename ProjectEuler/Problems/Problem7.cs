using ProjectEuler.Core;
using ProjectEuler.Primes;

namespace ProjectEuler.Problems
{
    // Problem 7: What is the 10,001st prime number?
    public class Problem7 : IProjectEulerProblem
    {
        public object Solve()
        {
            var primes = new ExpandablePrimes();

            return primes.GetNthPrime(10001);
        }
    }
}