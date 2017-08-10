using System.Collections.Generic;

namespace ProjectEuler
{
    class FibonacciSequence : Sequence
    {
        private long _prev;
        private long _current;

        public override long Next()
        {
            var returnValue = _current;
            var next = _current + _prev;
            _prev = _current;
            _current = next;

            return returnValue;
        }

        public override void Reset()
        {
            _prev = 0;
            _current = 1;
        }
    }
}