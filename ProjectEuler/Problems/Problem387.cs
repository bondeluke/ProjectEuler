using System.Collections.Generic;
using System.Linq;
using ProjectEuler.Core;
using ProjectEuler.Math;
using ProjectEuler.Primes;

namespace ProjectEuler.Problems
{
    // Problem 387: Harshad numbers. It's complicated.
    public class Problem387 : IProjectEulerProblem
    {
        public object Solve()
        {
            const int power = 14;

            var harshadNumbers = new long[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9
            };

            var trunctableHarshads = new List<long>(harshadNumbers);
            var previousNDigitHarshads = harshadNumbers;

            for (var digitLength = 2; digitLength < power; digitLength++)
            {
                previousNDigitHarshads = FindNextIteration(previousNDigitHarshads);
                trunctableHarshads.AddRange(previousNDigitHarshads);
            }

            var strongs = trunctableHarshads.Where(IsStrong).ToArray();
            var primes = FindPrimes(strongs); // Finding primes adds another digit

            return primes.Sum();
        }

        private static long[] FindNextIteration(long[] previousHarshads)
        {
            var list = new List<long>();

            foreach (var number in previousHarshads)
            {
                for (var digit = 0; digit < 10; digit++)
                {
                    var newNumber = number.ToString().Plus(digit).ToLong();
                    if (newNumber.IsHarshad())
                    {
                        list.Add(newNumber);
                    }
                }
            }

            return list.ToArray();
        }

        private static long[] FindPrimes(long[] strongs)
        {
            var list = new List<long>();

            foreach (var number in strongs)
            {
                for (var digit = 1; digit < 10; digit += 2)
                {
                    var newNumber = number.ToString().Plus(digit).ToLong();
                    if (newNumber.IsPrime())
                    {
                        list.Add(newNumber);
                    }
                }
            }

            return list.ToArray();
        }

        private static bool IsStrong(long number) => number.IsHarshad() && (number / number.SumDigits()).IsPrime();
    }
}