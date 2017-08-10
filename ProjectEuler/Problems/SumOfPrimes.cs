using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class SumOfPrimes : ProjectEulerProblem
    {
        private const long limit = 2000000;

        public SumOfPrimes()
        {
            Id = 10;
            Statement = "Find the sum of all the primes below two million.";
        }

        public override void Solve()
        {
            Solution = PrimeSequence.Below(limit).Sum();
        }
    }
}
