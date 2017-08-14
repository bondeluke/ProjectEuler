using ProjectEuler.Core;
using ProjectEuler.Math;

namespace ProjectEuler.Problems
{
    // Problem 2: By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.
    public class EvenFibonacciNumbers : IProjectEulerProblem
    {
        private const long Limit = 4000000;

        public object Solve()
        {
            long sum = 0;

            var seq = new FibonacciSequence();

            foreach (var fib in seq)
            {
                if (fib > Limit)
                    break;

                if (fib.IsEven())
                    sum += fib;
            }

            return sum;
        }
    }
}