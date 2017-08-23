using System.Linq;
using ProjectEuler.Core;
using ProjectEuler.Math;

namespace ProjectEuler.Problems
{
    // Problem 72: How many elements would be contained in the set of reduced proper fractions for d ≤ 1,000,000?
    public class Problem72 : IProjectEulerProblem
    {
        public object ExpectedSolution => 303963552391;
        public long Benchmark => 839;

        public object Solve()
        {
            var phiSieve = new PhiSieve(1000000);

            return Integer.Range(2, 1000001).Sum(n => phiSieve.Phi(n));
        }
    }
}