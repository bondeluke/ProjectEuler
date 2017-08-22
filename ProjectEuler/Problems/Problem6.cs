using System.Linq;
using ProjectEuler.Core;
using ProjectEuler.Math;

namespace ProjectEuler.Problems
{
    // Problem 6: Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
    public class Problem6 : IProjectEulerProblem
    {
        public object ExpectedSolution => 25164150;
        public long Benchmark => 23;

        public object Solve()
        {
            var integers = Integer.Range(1, 101).ToArray();

            var sumOfSquares = integers.Select(Integer.Squared).Sum();

            var squareOfSum = integers.Sum().Squared();

            return squareOfSum - sumOfSquares;
        }
    }
}