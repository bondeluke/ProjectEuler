using System.Collections;
using System.Collections.Generic;

namespace ProjectEuler
{
    public class FibonacciSequence : IEnumerable<long>
    {
        public FibonacciSequence()
        {
            _prev = 0;
            _current = 1;
        }

        private long _prev;
        private long _current;

        public long Next()
        {
            var returnValue = _current;
            var next = _current + _prev;
            _prev = _current;
            _current = next;

            return returnValue;
        }

        public IEnumerator<long> GetEnumerator()
        {
            return new FibonacciEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class FibonacciEnumerator : IEnumerator<long>
        {
            private readonly FibonacciSequence _seq;

            public FibonacciEnumerator(FibonacciSequence seq)
            {
                _seq = seq;
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                _seq.Next();

                return true;
            }

            public void Reset()
            {
                throw new System.NotImplementedException();
            }

            public long Current => _seq._current;

            object IEnumerator.Current => Current;
        }
    }
}