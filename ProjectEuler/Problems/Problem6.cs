using ProjectEuler.Core;
using ProjectEuler.Math;
using System.Linq;

namespace ProjectEuler.Problems
{
    // Problem 6: Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
    public class Problem6 : IProjectEulerProblem
    {
        public object Solve()
        {
            var integers = Integer.Range(1, 100).ToArray();

            var sumOfSquares = integers.Select(Integer.Squared).Sum();

            var squareOfSum = integers.Sum().Squared();

            return squareOfSum - sumOfSquares;
        }
    }
}
