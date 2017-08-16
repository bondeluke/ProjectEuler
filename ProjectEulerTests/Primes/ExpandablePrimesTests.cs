using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Math;
using ProjectEuler.Primes;

namespace ProjectEulerTests.Primes
{
    [TestClass]
    public class ExpandablePrimesTests
    {
        [TestMethod]
        public void IsPrime()
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
        public void GetNthPrime()
        {
            var collection = new ExpandablePrimes();

            collection.GetNthPrime(1).ShouldBe(2);
            collection.GetNthPrime(10).ShouldBe(29);
            collection.GetNthPrime(100).ShouldBe(541);
            collection.GetNthPrime(1000).ShouldBe(7919);
        }
    }
}
