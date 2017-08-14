using ProjectEuler.Core;

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
