using ProjectEuler.Core;
using ProjectEuler.Math;

namespace ProjectEuler.Problems
{
    class MultiplesOf3And5 : IProjectEulerProblem
    {
        public object Solve()
        {
            var sum = 0L;
            var start = 1L; 
            var end = 999L;

            foreach (var value in start.To(end))
                if (value.IsMultipleOf(3, 5))
                    sum += value;

            return sum;
        }
    }
}