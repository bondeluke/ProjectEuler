using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Primes;

namespace ProjectEulerTests.Primes
{
    [TestClass]
    public class PrimeSieveTests
    {
        [TestMethod]
        public void SieveLength()
        {
            var sieve = new PrimeSieve(1000);

            sieve.Primes.Length.ShouldBe(168);

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
