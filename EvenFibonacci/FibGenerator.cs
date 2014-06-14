using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenFibonacci
{
    class FibGenerator
    {
        private int currentFib;
        private int prevFib;

        public FibGenerator()
        {
            currentFib = 0;
            prevFib = 1;
        }

        public int Next()
        {
            int nextFib = currentFib + prevFib;
            prevFib = currentFib;
            currentFib = nextFib;
            return nextFib;
        }
    }
}
