using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Primes;

namespace ProjectEulerTests.Primes
{
    [TestClass]
    public class PrimeSieveTests
    {
        [TestMethod]
        public void Providing()
        {
            var sieve = new PrimeSieve(1000);

            var primes = sieve.GetPrimes().ToArray();

            primes.Length.ShouldBe(168);
            primes[0].ShouldBe(2);
            primes[1].ShouldBe(3);
            primes[2].ShouldBe(5);
        }

        [TestMethod]
        public void Indexing()
        {
            var sieve = new PrimeSieve(20001);

            sieve.GetNthPrime(1).ShouldBe(2);
            sieve.GetNthPrime(10).ShouldBe(29);
            sieve.GetNthPrime(100).ShouldBe(541);
            sieve.GetNthPrime(1000).ShouldBe(7919);
        }

        [TestMethod]
        public void Deciding()
        {
            var sieve = new PrimeSieve(1000);

            sieve.IsPrime(2).ShouldBeTrue();
            sieve.IsPrime(3).ShouldBeTrue();
            sieve.IsPrime(5).ShouldBeTrue();
            sieve.IsPrime(151).ShouldBeTrue();
            sieve.IsPrime(9973).ShouldBeTrue();
            sieve.IsPrime(999983).ShouldBeTrue();

            sieve.IsPrime(6).ShouldBeFalse();
            sieve.IsPrime(1000001).ShouldBeFalse();
            sieve.IsPrime(1320359782305982082).ShouldBeFalse();
        }
    }
}
