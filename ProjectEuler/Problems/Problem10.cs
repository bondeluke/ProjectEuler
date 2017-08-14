using ProjectEuler.Core;
using ProjectEuler.Primes;
using System.Linq;

namespace ProjectEuler.Problems
{
    // Problem 10: Find the sum of all the primes below two million.
    public class Problem10 : IProjectEulerProblem
    {
        private const int Limit = 2000000;

        public object Solve()
        {
            var sieve = new PrimeSieve(Limit);

            return sieve.Primes.Sum();
        }
    }
}
