using System.Collections.Generic;

namespace ProjectEuler.Primes
{
    public interface IPrimeDecider
    {
        bool IsPrime(long number);
    }

    public interface IPrimeProvider
    {
        ICollection<long> GetPrimes();
    }

    public interface IPrimeIndexer
    {
        long GetNthPrime(int n);
    }
}
