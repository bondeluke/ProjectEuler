using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Math;
using ProjectEuler.Primes;

namespace ProjectEulerTests.Primes
{
    [TestClass]
    public class ExpandablePrimesTests
    {
        [TestMethod]
        public void Providing()
        {
            var sieve = new ExpandablePrimes();

            var primes = sieve.GetPrimes().ToArray();

            primes[0].ShouldBe(2);
            primes[1].ShouldBe(3);
            primes[2].ShouldBe(5);
        }

        [TestMethod]
        public void Deciding()
        {
            var collection = new ExpandablePrimes();

            collection.IsPrime(2).ShouldBeTrue();
            collection.IsPrime(3).ShouldBeTrue();
            collection.IsPrime(5).ShouldBeTrue();
            collection.IsPrime(151).ShouldBeTrue();
            collection.IsPrime(1123).ShouldBeTrue();
            collection.IsPrime(9973).ShouldBeTrue();

            collection.IsPrime(15).ShouldBeFalse();
            collection.IsPrime(121).ShouldBeFalse();
            collection.IsPrime(10.Power(8)).ShouldBeFalse();

            collection.IsPrime(4008200000033).ShouldBeTrue();
        }

        [TestMethod]
        public void Indexing()
        {
            var collection = new ExpandablePrimes();

            collection.GetNthPrime(1).ShouldBe(2);
            collection.GetNthPrime(10).ShouldBe(29);
            collection.GetNthPrime(100).ShouldBe(541);
            collection.GetNthPrime(1000).ShouldBe(7919);
        }
    }
}
