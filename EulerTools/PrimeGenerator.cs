using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerTools
{
    public class PrimeGenerator
    {
        private const int firstPrime = 2;

        public ICollection<long> Range(long limit)
        {
            List<long> primes = new List<long>();
            bool[] IsPrime = new bool[limit];

            IsPrime[0] = IsPrime[1] = false;
            for (long number = firstPrime; number < IsPrime.Length; number++)
                IsPrime[number] = true;

            for (long number = 0; number < IsPrime.Length; number++)
                if (IsPrime[number])
                {
                    for (long i = number * 2; i < limit; i += number)
                        IsPrime[i] = false;
                    primes.Add(number);
                }

            return primes;
        }


    }
}
