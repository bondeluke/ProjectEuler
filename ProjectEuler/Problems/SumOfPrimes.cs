using System.Linq;

namespace ProjectEuler.Problems
{
    class SumOfPrimes : IProjectEulerProblem
    {
        private const long limit = 2000000;

        public object Solve()
        {
            return PrimeSequence.Below(limit).Sum();
        }
    }
}
