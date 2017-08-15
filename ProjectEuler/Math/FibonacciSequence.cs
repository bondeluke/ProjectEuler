using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler.Math
{
    public class FibonacciSequence : IEnumerable<BigInteger>, IEnumerator<BigInteger>
    {
        public FibonacciSequence()
        {
            Reset();
        }

        private bool _firstMove;

        private BigInteger _prev;

        public IEnumerator<BigInteger> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public BigInteger Current { get; private set; }

        public bool MoveNext()
        {
            if (_firstMove)
            {
                _firstMove = false;
                return true;
            }

            var next = Current + _prev;
            _prev = Current;
            Current = next;

            return true;
        }

        public void Reset()
        {
            _prev = 0;
            Current = 1;
            _firstMove = true;
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }
    }
}