using System.Linq;
using ProjectEuler.Core;
using ProjectEuler.Math;

namespace ProjectEuler.Problems
{
    // Problem 1: Find the sum of all the multiples of 3 or 5 below 1000.
    public class Problem1 : IProblemAndMetadata
    {
        public object Solve()
        {
            return Integer.Range(1, 1000)
                .Where(value => value.IsMultipleOfAny(3, 5))
                .Sum();
        }

        public long Benchmark => 22;

        public object ExpectedSolution => 233168;
    }
}