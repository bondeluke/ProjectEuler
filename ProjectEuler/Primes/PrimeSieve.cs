using System.Collections.Generic;
using ProjectEuler.Math;

namespace ProjectEuler.Primes
{
    public class PrimeSieve : IPrimeDecider, IPrimeProvider, IPrimeIndexer
    {
        public PrimeSieve() : this(10000001)
        {
            
        }

        public PrimeSieve(long limit)
        {
            _limit = limit + 1;

            InitializeArray();
            CrossOutComposites();
            AddPrimesToList();
        }

        private readonly long _limit;

        private bool[] _isPrime;

        private long[] _primes;

        private void AddPrimesToList()
        {
            var primes = new List<long>();

            for (var i = 0; i < _limit; i++)
            {
                if (_isPrime[i])
                {
                    primes.Add(i);
                }
            }

            _primes = primes.ToArray();
        }

        private void InitializeArray()
        {
            _isPrime = new bool[_limit];
            for (var i = 0; i < _limit; i++)
                _isPrime[i] = true;

            _isPrime[0] = _isPrime[1] = false;
        }

        private void CrossOutComposites()
        {
            for (long number = 0; number.Squared() < _limit; number++)
            {
                if (_isPrime[number])
                    CrossOutMultiplesOf(number);
            }
        }

        private void CrossOutMultiplesOf(long prime)
        {
            for (var mult = prime * 2; mult < _limit; mult += prime)
                _isPrime[mult] = false;
        }

        public bool IsPrime(long number)
        {
            if (number < _limit)
            {
                return _isPrime[number];
            }

            return new PrimalityAlgorithm(this, _limit).IsPrime(number);
        }

        public ICollection<long> GetPrimes() => _primes;

        public long GetNthPrime(int n) => _primes[n - 1];
    }
}