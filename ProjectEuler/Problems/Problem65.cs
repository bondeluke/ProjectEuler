using System;
using System.Collections.Generic;
using System.Text;
using ProjectEuler.Core;
using ProjectEuler.Math;

namespace ProjectEuler.Problems
{
    class Problem65 : IProjectEulerProblem
    {
        public object Solve()
        {
            const int term = 2;

            return GetTerm(term);
        }

        private Fraction GetTerm(int n) => 2 + GetNthFraction(n);

        private Fraction GetNthFraction(int n)
        {
            if (n == 1) return Fraction.New(0, 1);

            var denominator = n % 3 == 0
                ? n * 2 / 3
                : 1;

            return Fraction.New(0, 0);
        }

        private Fraction GetNthSomething(int n)
        {
            var numerator = 1;

            var term = 1;
            var denominator = term + GetNthSomething(n);

            return numerator / denominator;
        }
    }
}
