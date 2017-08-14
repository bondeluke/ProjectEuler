using ProjectEuler.Core;
using ProjectEuler.Primes;

namespace ProjectEuler.Problems
{
    class TenThousandFirstPrime : IProjectEulerProblem
    {
        public object Solve()
        {
            var primes = new PrimeCollection();

            return primes.GetNthPrime(10001);
        }
    }
}
