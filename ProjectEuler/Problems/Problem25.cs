using ProjectEuler.Core;
using ProjectEuler.Math;

namespace ProjectEuler.Problems
{
    // Problem 25: What is the index of the first term in the Fibonacci sequence to contain 1000 digits?
    public class Problem25 : IProjectEulerProblem
    {
        public object Solve()
        {
            var index = 0;
            foreach (var number in new FibonacciSequence())
            {
                index++;
                if (number.ToString().Length >= 1000)
                    return index;
            }

            return -1;
        }
    }
}
