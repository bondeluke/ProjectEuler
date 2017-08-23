using System.Numerics;
using ProjectEuler.Core;
using ProjectEuler.Math;

namespace ProjectEuler.Problems
{
    public class Problem78 : IProjectEulerProblem, ITestCaseable
    {
        private BigInteger[] _p;

        private long[] _pentagonals;

        public object ExpectedSolution => 55374;

        public long Benchmark => 4461;

        public object Solve()
        {
            var size = 70000;

            _pentagonals = new GeneralizedPentagonalSequence(size).Values;
            _p = new BigInteger[size + 1];

            for (var n = 5; n < size; n++)
            {
                if (P(n) % 1000000 == 0)
                    return n;
            }

            return P(size);
        }

        public BigInteger P(long n)
        {
            if (n == 0 || n == 1)
                return 1;

            if (_p[n] != 0)
                return _p[n];

            BigInteger sum = 0;

            for (var i = 0; i < n; i++)
            {
                var m = n - _pentagonals[i];

                if (m < 0)
                    break;

                var sign = i % 4 == 0 || i % 4 == 1 ? 1 : -1;

                sum += sign * P(m);
            }

            return _p[n] = sum;
        }

        public object TestSolve()
        {
            const int size = 200;

            _pentagonals = new GeneralizedPentagonalSequence(size).Values;
            _p = new BigInteger[size + 1];

            return P(size);
        }

        public object TestSolution => 3972999029388.ToBigInteger();
        public long TestBenchmark => 15;
    }
}