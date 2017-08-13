using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    class PrimeCollection
    {
        public List<long> _primes;
        private long _greatestChecked;

        public PrimeCollection()
        {
            _primes = new List<long>
            {
                2, 3, 5, 7, 11, 13, 17
            };

            _greatestChecked = 17; // Number of the form 6k + 5
        }

        public bool IsPrime(long number)
        {
            if (_greatestChecked > number)
                return _primes.Any(p => p == number);

            var sqrt = Convert.ToInt64(Math.Ceiling(Math.Sqrt(number)));

            if (sqrt > _greatestChecked)
            {
                PopulatePrimesUpTo(sqrt);
            }

            var i = 0;
            long prime = 2;
            while (true)
            {
                if (number % prime == 0)
                    return false; // number is not a prime.

                if (prime >= sqrt || _primes.Count == i + 1)
                    break;

                i += 1;
                prime = _primes[i];
            }

            return true;
        }

        private void PopulatePrimesUpTo(long upto)
        {
            for (long sixk = _greatestChecked + 1; sixk <= upto; sixk += 6)
            {
                var candidate = sixk + 1;
                if (IsPrime(candidate))
                {
                    _primes.Add(candidate);
                }
                candidate = sixk + 5;
                if (IsPrime(candidate))
                {
                    _primes.Add(candidate);
                }
                _greatestChecked = candidate;
            }
        }
    }
}