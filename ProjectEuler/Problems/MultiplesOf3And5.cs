using ProjectEuler.Common;
using System.Linq;

namespace ProjectEuler.Problems
{
    class MultiplesOf3And5 : ProjectEulerProblem
    {
        public MultiplesOf3And5()
        {
            Id = 1;
            Statement = "Find the sum of all the multiples of 3 or 5 below 1000.";
        }

        public override void Solve()
        {
            var sum = 0L;
            var start = 1L; 
            var end = 999L;

            foreach (var value in start.To(end))
                if (value.IsMultipleOf(3, 5))
                    sum += value;

            Solution = sum;
        }
    }
}