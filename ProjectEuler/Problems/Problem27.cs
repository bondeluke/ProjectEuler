using System.Linq;
using ProjectEuler.Core;
using ProjectEuler.Math;
using ProjectEuler.Primes;

namespace ProjectEuler.Problems
{
    // Problem 27: Find the product of the coefficients, aa and bb, for the quadratic expression that 
    // produces the maximum number of primes for consecutive values of nn, starting with n=0.
    public class Problem27 : IProjectEulerProblem
    {
        private PrimeSieve _sieve;

        public object Solve()
        {
            // b must be a prime since a^2 + an + b = b when n = 0
            _sieve = new PrimeSieve(10000);

            var greatestCount = 0;
            long aGreat = 0, bGreat = 0;
            for (var a = -999; a < 1000; a++)
            {
                foreach (var b in _sieve.Primes.TakeWhile(p => p < 1000))
                {
                    var count = GetConsecutivePrimeCount(a, b);

                    if (count > greatestCount)
                    {
                        greatestCount = count;
                        aGreat = a;
                        bGreat = b;
                    }
                }
            }

            return aGreat * bGreat;
        }

        private int GetConsecutivePrimeCount(long a, long b)
        {
            var count = 0;
            for (long n = 0; n < 150; n++)
            {
                var pn = n.Squared() + a * n + b;

                if (pn > 0 && _sieve.IsPrime(pn))
                {
                    count += 1;
                }
                else
                {
                    break;
                }
            }
            return count;
        }
    }
}