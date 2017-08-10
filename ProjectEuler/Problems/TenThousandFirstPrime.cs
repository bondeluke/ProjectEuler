using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class TenThousandFirstPrime : ProjectEulerProblem
    {
        public TenThousandFirstPrime()
        {
            Id = 7;

            Statement = "What is the 10,001st prime number?";
        }

        public override void Solve()
        {
            Solution = new PrimeSequence().GetNthPrime(10001);
        }
    }
}
