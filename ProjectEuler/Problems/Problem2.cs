using System.Linq;
using ProjectEuler.Core;
using ProjectEuler.Math;

namespace ProjectEuler.Problems
{
    // Problem 2: By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.
    public class Problem2 : IProjectEulerProblem
    {
        private const long Limit = 4000000;

        public object Solve()
        {
            var seq = new FibonacciSequence();

            var sum = seq.TakeWhile(fib => fib <= Limit)
                .Where(fib => fib.IsEven)
                .Sum(b => (long) b);

            return sum;
        }
    }
}