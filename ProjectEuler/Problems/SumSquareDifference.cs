using System.Linq;

namespace ProjectEuler.Problems
{
    public class SumSquareDifference : IProjectEulerProblem
    {
        public object Solve()
        {
            var integers = Integer.First(100).ToArray();

            var sumOfSquares = integers.Select(Integer.Square).Sum();

            var squareOfSum = integers.Sum().Square();

            return squareOfSum - sumOfSquares;
        }
    }
}
