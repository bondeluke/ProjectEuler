using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    class PrimeCollection
    {
        public List<long> _primes;
        private long _greatestChecked;
        const long _root = 2 * 3 * 5;



        public PrimeCollection()
        {
            _primes = new List<long>
            {
                2, 3, 5, 7, 11, 13, 17, 19, 23, 29
            };

            _greatestChecked = _root - 1; // Number of the form 30k + 29
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
            for (long thirtyk = _greatestChecked + 1; thirtyk <= upto; thirtyk += _root)
            {
                AddIfPrime(thirtyk + 1);
                AddIfPrime(thirtyk + 7);
                AddIfPrime(thirtyk + 11);
                AddIfPrime(thirtyk + 13);
                AddIfPrime(thirtyk + 17);
                AddIfPrime(thirtyk + 19);
                AddIfPrime(thirtyk + 23);
                AddIfPrime(thirtyk + 29);

                _greatestChecked = thirtyk + 29;
            }
        }
        private void AddIfPrime(long candidate)
        {
            if (IsPrime(candidate))
            {
                _primes.Add(candidate);
            }
        }

        public long GetNthPrime(int n)
        {
            var index = n - 1; // The first prime n=1 will be at index=0
            while (_primes.Count <= index)
            {
                PopulatePrimesUpTo(_greatestChecked + _root);
            }

            return _primes[index];
        }
    }
}