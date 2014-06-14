using EulerTools;
using System.Collections.Generic;


namespace LargestPrimeFactor
{
    class Program
    {
        // Problem 3
        // What is the largest prime factor of the number 600851475143?

        const long largeNumber = 600851475143;

        static void Main(string[] args)
        {
            long largestFactor = 1;
            var factors = Factorization.PrimeFactors(largeNumber);
            foreach (long factor in factors)
                if (factor > largestFactor)
                    largestFactor = factor;

            EulerHelper.DisplayAnswer(largestFactor);
        }
    }
}
