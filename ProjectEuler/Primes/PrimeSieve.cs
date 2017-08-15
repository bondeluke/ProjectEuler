using System.Collections.Generic;
using ProjectEuler.Math;

namespace ProjectEuler.Primes
{
    public class PrimeSieve
    {
        public PrimeSieve(int limit)
        {
            _limit = limit;
            _primes = new List<long>();

            InitializeArray();
            CrossOutComposites();
            AddPrimesToList();
        }

        private readonly int _limit;

        private readonly List<long> _primes;
        private bool[] _isPrime;

        public long[] Primes => _primes.ToArray();

        private void AddPrimesToList()
        {
            for (var i = 0; i < _limit; i++)
            {
                if (_isPrime[i])
                {
                    _primes.Add(i);
                }
            }
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

        public bool IsPrime(int number) => _isPrime[number];
    }
}