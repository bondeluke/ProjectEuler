using ProjectEuler.Core;
using System.Linq;

namespace ProjectEuler.Problems
{
    class SumOfPrimes : IProjectEulerProblem
    {
        private const int limit = 2000000;

        public object Solve()
        {
            var sieve = new PrimeSieve(limit);

            return sieve.Sum();
        }
    }
}
