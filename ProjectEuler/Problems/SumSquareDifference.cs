using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class SumSquareDifference : ProjectEulerProblem
    {
        public SumSquareDifference()
        {
            Id = 6;

            Statement = "Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.";
        }

        public override void Solve()
        {
            var integers = Integer.First(100).ToArray();

            var sumOfSquares = integers.Select(Integer.Square).Sum();

            var squareOfSum = integers.Sum().Square();

            Solution = squareOfSum - sumOfSquares;
        }
    }
}
