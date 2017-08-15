using System;
using ProjectEuler.Core;
using ProjectEuler.Math;
using ProjectEuler.Primes;

namespace ProjectEuler.Problems
{
    public class Problem357 : IProjectEulerProblem
    {
        public object Solve()
        {
            long sum = 0;

            Research();

            return sum;
        }

        private void Research()
        {
            for (long number = 1; number < 150; number++)
            {
                if (HasProperty(number))
                {
                    Console.WriteLine($"{number}: {number.GetPrimeFactors().StringJoin()}");
                }
            }
        }

        private bool HasProperty(long number)
        {
            var divisors = number.Divisors();

            if (divisors.Length.ToLong().IsOdd())
                return false;

            for (var i = 0; i < divisors.Length / 2; i++)
            {
                var j = divisors.Length - i - 1;
                if (!(divisors[i] + divisors[j]).IsPrime())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
