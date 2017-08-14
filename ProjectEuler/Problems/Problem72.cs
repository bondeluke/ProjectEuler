using System.Linq;
using ProjectEuler.Core;
using ProjectEuler.Math;

namespace ProjectEuler.Problems
{
    // Problem 72: How many elements would be contained in the set of reduced proper fractions for d ≤ 1,000,000?
    public class Problem72 : IProjectEulerProblem
    {
        public object Solve()
        {
            return Integer.Range(2, 1000001).Sum(n => n.Phi());
        }
    }
}
