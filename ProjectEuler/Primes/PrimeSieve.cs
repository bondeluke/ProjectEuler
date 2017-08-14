using ProjectEuler.Math;
using System.Collections.Generic;

namespace ProjectEuler.Primes
{
    public class PrimeSieve : List<long>
    {
        private bool[] _isPrime;

        private int _limit;

        public PrimeSieve(int limit) : base(256)
        {
            _limit = limit;

            InitializeArray();
            CrossOutComposites();
            AddPrimesToList();
        }

        private void AddPrimesToList()
        {
            for (int i = 0; i < _limit; i++)
            {
                if (_isPrime[i])
                {
                    Add(i);
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
            for (long mult = prime * 2; mult < _limit; mult += prime)
                _isPrime[mult] = false;
        }
    }
}