using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Common;

namespace ProjectEuler.Problems
{
    class LargestPrimeFactor : ProjectEulerProblem
    {
        private const long LargeNumber = 600851475143;

        public LargestPrimeFactor()
        {
            Id = 3;
            Statement = "What is the largest prime factor of the number {0}?".Format(LargeNumber);
        }

        public override void Solve()
        {
            Solution = LargeNumber.GeneratePrimeFactors().Largest();
        }
    }
}
