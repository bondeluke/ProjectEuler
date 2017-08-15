﻿using ProjectEuler.Core;
using ProjectEuler.Math;

namespace ProjectEuler.Problems
{
    public class Problem65 : IProjectEulerProblem
    {
        public Problem65(ILogWritable log)
        {
            _log = log;
        }

        private readonly ILogWritable _log;

        public object Solve()
        {
            const int term = 100;

            //LogFirstConvergents(term);

            return GetConvergent(term).Numerator.SumDigits();
        }

        private BigFraction GetConvergent(int n) => 2 + GetNextExpansion(n - 1, 1);

        private BigFraction GetNextExpansion(int expansionsLeft, int nthTerm)
        {
            if (expansionsLeft == 0)
                return BigFraction.Zero;

            var d = GetNthTerm(nthTerm) + GetNextExpansion(expansionsLeft - 1, nthTerm + 1);
            return 1 / d;
        }

        // n => term
        // 1 -> 1
        // 2 -> 2
        // 3 -> 1
        // 4 -> 1
        // 5 -> 4
        private long GetNthTerm(int n)
        {
            var result = (n.ToLong() + 3).DivideBy(3);

            return result.Remainder == 2
                ? result.Quotient * 2
                : 1;
        }

        private void LogFirstConvergents(int limit)
        {
            for (var i = 1; i < limit; i++)
            {
                // Long overflow at term 39
                _log.WriteLine(GetConvergent(i).Numerator);
            }
        }
    }
}