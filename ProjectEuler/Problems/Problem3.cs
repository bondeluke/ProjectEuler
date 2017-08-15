﻿using System.Linq;
using ProjectEuler.Core;
using ProjectEuler.Primes;

namespace ProjectEuler.Problems
{
    // Problem 3: What is the largest prime factor of the number 600851475143?
    public class Problem3 : IProjectEulerProblem
    {
        private const long LargeNumber = 600851475143;

        public object Solve()
        {
            return LargeNumber.GetPrimeFactors().Max();
        }
    }
}
