using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEuler.Math;

namespace ProjectEuler.Primes
{
    // PrimalityAlgorithm does not care how its primes came to be, 
    // It simply evaluates whether a number between 1 and max(primes)^2 is prime.
    public class PrimalityAlgorithm : IPrimeDecider
    {
        private readonly long _greatestChecked;
        private readonly ICollection<long> _primes;

        public PrimalityAlgorithm(IPrimeProvider provider, long greatestChecked)
        {
            _primes = provider.GetPrimes();
            _greatestChecked = greatestChecked;
        }

        public bool IsPrime(long number)
        {
            if (number < _greatestChecked)
                return _primes.Any(p => p == number);

            var sqrt = number.Sqrt().Ceiling().ToLong();

            foreach (var prime in _primes)
            {
                if (number % prime == 0)
                    return false; // number is not a prime.

                if (prime >= sqrt)
                    return true;
            }

            if (_greatestChecked >= sqrt)
                return true;

            throw new Exception("A decision could not be made");
        }
    }
}