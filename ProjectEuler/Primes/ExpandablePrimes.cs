using System;
using System.Collections.Generic;
using ProjectEuler.Math;

namespace ProjectEuler.Primes
{
    public class ExpandablePrimes : IPrimeDecider, IPrimeProvider, IPrimeIndexer
    {
        private readonly List<long> _primes;

        private long _greatestChecked;
        private readonly long _largestCoprime;

        private const long Root = 2 * 3;

        public int Count => _primes.Count;

        public ExpandablePrimes()
        {
            _primes = new List<long>
            {
                2, 3, 5/*, 7, 11, 13, 17, 19, 23, 29*/
            };

            _largestCoprime = Root - 1;
            _greatestChecked = _largestCoprime; // Number of the form 6k + 5
        }

        public bool IsPrime(long number)
        {
            var sqrt = number.Sqrt().Ceiling().ToLong();

            if (sqrt > _greatestChecked)
            {
                PopulatePrimesUpTo(sqrt);
                // This could be more reactive instead of pro-active, but chances are that if we're 
                // checking numbers at this magnitude, we'll probably need to grow soon anyway.
            }

            return new PrimalityAlgorithm(this, _greatestChecked).IsPrime(number);
        }

        private void PopulatePrimesUpTo(long upto)
        {
            for (var kRoot = _greatestChecked + 1; kRoot <= upto; kRoot += Root)
            {
                foreach (var coPrime in _rootLesserCoprimes.Value)
                {
                    AddIfPrime(kRoot + coPrime);
                }

                _greatestChecked = kRoot + _largestCoprime;
            }
        }

        private readonly Lazy<long[]> _rootLesserCoprimes = new Lazy<long[]>(() => Root.GetTotatives());

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

        public ICollection<long> GetPrimes() => _primes;
    }
}