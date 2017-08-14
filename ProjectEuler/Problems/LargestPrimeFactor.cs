using ProjectEuler.Core;
using ProjectEuler.Math;

namespace ProjectEuler.Problems
{
    class LargestPrimeFactor : IProjectEulerProblem
    {
        private const long LargeNumber = 600851475143;

        public object Solve()
        {
            return LargeNumber.GetPrimeFactors().Largest();
        }
    }
}
