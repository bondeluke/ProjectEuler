using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    public class PrimeSieve
    {
        private long _current;

        private bool[] _isPrime;

        private List<long> _primes;

        private const long _defaultSize = 823123123;

        private long _size;

        public PrimeSieve()
        {
            Reset();
        }

        public void Reset()
        {
            _size = _defaultSize;
            _current = 2;
            _primes = new List<long>();

            InitializeArray();
            CrossOutComposites();
        }

        private void InitializeArray()
        {
            _isPrime = new bool[_size];
            for (var i = 0; i < _size; i++)
                _isPrime[i] = true;

            _isPrime[0] = _isPrime[1] = false;
        }

        private void CrossOutComposites()
        {
            for (long number = 0; number.Squared() < _size; number++)
            {
                if (_isPrime[number])
                    CrossOutMultiplesOf(number);
            }
        }

        private void CrossOutMultiplesOf(long prime)
        {
            for (long mult = prime * 2; mult < _size; mult += prime)
                _isPrime[mult] = false;
        }

        public long Next()
        {
            var returnValue = _current;

            MoveToNextCurrent();

            return returnValue;
        }

        private void MoveToNextCurrent()
        {
            while (!_isPrime[++_current])
            {
                if (_current == _size - 1)
                    throw new Exception("Should've added more primes");
            }
        }

        public static IEnumerable<long> Below(long end)
        {
            var sequence = new PrimeSieve();

            long prime;

            while ((prime = sequence.Next()) < end)
                yield return prime;
        }

        public bool Contains(long subject)
        {
            return _isPrime[subject];
        }

        public long GetNthPrime(int N)
        {
            throw new NotImplementedException();
        }
    }
}