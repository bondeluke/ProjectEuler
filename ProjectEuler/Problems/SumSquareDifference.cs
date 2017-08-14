using ProjectEuler.Core;
using ProjectEuler.Math;
using System.Linq;

namespace ProjectEuler.Problems
{
    public class SumSquareDifference : IProjectEulerProblem
    {
        public object Solve()
        {
            var integers = Integer.First(100).ToArray();

            var sumOfSquares = integers.Select(Integer.Squared).Sum();

            var squareOfSum = integers.Sum().Squared();

            return squareOfSum - sumOfSquares;
        }
    }
}
