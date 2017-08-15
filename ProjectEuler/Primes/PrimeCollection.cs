using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEuler.Math;

namespace ProjectEuler.Primes
{
    public class PrimeCollection
    {
        private readonly List<long> _primes;

        private long _greatestChecked;
        private readonly long _largestCoPrime;

        private const long Root = 2 * 3;

        public int Count => _primes.Count;

        public PrimeCollection()
        {
            _primes = new List<long>
            {
                2, 3, 5/*, 7, 11, 13, 17, 19, 23, 29*/
            };

            _largestCoPrime = Root - 1;
            _greatestChecked = _largestCoPrime; // Number of the form 6k + 5
        }

        public bool IsPrime(long number)
        {
            if (_greatestChecked > number)
                return _primes.Any(p => p == number);

            var sqrt = number.Sqrt().Ceiling().ToLong();

            var i = 0;
            long prime = 2;
            while (true)
            {
                if (number % prime == 0)
                    return false; // number is not a prime.

                if (_primes.Count == i + 1)
                {
                    PopulatePrimesUpTo(sqrt);
                }

                if (prime >= sqrt || _primes.Count == i + 1) // If we just populated, but none were added, this number must be prime.
                    return true;

                i += 1;
                prime = _primes[i];
            }
        }

        private void PopulatePrimesUpTo(long upto)
        {
            for (var kRoot = _greatestChecked + 1; kRoot <= upto; kRoot += Root)
            {
                foreach (var coPrime in _rootLesserCoPrimes.Value)
                {
                    AddIfPrime(kRoot + coPrime);
                }

                _greatestChecked = kRoot + _largestCoPrime;
            }
        }

        private readonly Lazy<long[]> _rootLesserCoPrimes = new Lazy<long[]>(() => Root.GetTotatives());

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
                PopulatePrimesUpTo(_greatestChecked + Root);
            }

            return _primes[index];
        }
    }
}