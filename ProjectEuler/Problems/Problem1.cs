using System.Linq;
using ProjectEuler.Core;
using ProjectEuler.Math;

namespace ProjectEuler.Problems
{
    // Problem 1: Find the sum of all the multiples of 3 or 5 below 1000.
    public class Problem1 : IProjectEulerProblem
    {
        public object Solve()
        {
            const long start = 1L; 
            const long end = 999L;

            return start.To(end)
                .Where(value => value.IsMultipleOfAny(3, 5))
                .Sum();
        }
    }
}