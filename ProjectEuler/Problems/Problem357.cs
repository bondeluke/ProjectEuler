using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEuler.Core;
using ProjectEuler.Math;
using ProjectEuler.Primes;

namespace ProjectEuler.Problems
{
    // Problem 357: Find the sum of all positive integers n not exceeding 100 000 000
    // such that for every divisor d of n, d+n/d is prime.
    public class Problem357 : IProjectEulerProblem
    {
        public object Solve()
        {
            long sum = 0;
            // Hmm.. All candidates are odd prime combinations whose product is less than 50 000 000.
            Research();

            // Nope... just... totally wrong.
            const int limit = 50000000;
            var sqrt = limit.Sqrt().Ceiling().ToInt();

            var primes = new PrimeSieve(limit).Primes.Skip(1).ToArray();

            var couldHaveProperty = new bool[limit];

            for (long index = 0; index < couldHaveProperty.Length; index++)
            {
                couldHaveProperty[index] = index.IsOdd();
            }

            foreach (var prime in primes.TakeWhile(p => p < sqrt))
            {
                var primeSquared = prime.Squared(); // Always odd
                for (var multiple = primeSquared; multiple < limit; multiple += primeSquared * 2)
                {
                    couldHaveProperty[multiple] = false;
                }
            }

            for (long index = 1; index < couldHaveProperty.Length; index += 2)
            {
                if (!couldHaveProperty[index]) continue;

                couldHaveProperty[index] = (index * 2 + 1).IsPrime();
            }

            var candidates = new List<long>();

            for (var index = 1; index < couldHaveProperty.Length; index++)
            {
                if (!couldHaveProperty[index]) continue;

                candidates.Add(index * 2);
            }

            return candidates.Where(HasProperty).Sum();
        }

        private static void Research()
        {
            for (long number = 1; number < 250; number++)
            {
                if (HasProperty(number))
                {
                    Console.WriteLine($"{number}: {number.GetPrimeFactors().StringJoin()}");
                }
            }
        }

        private static bool HasProperty(long number)
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
