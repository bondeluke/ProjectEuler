using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Math;
using ProjectEuler.Primes;

namespace ProjectEulerTests.Primes
{
    [TestClass]
    public class PrimeCollectionTests
    {
        [TestMethod]
        public void PrimeCollectionShouldAssessPrimalityCorrectly()
        {
            var collection = new PrimeCollection();

            collection.IsPrime(2).ShouldBeTrue();
            collection.IsPrime(3).ShouldBeTrue();
            collection.IsPrime(5).ShouldBeTrue();
            collection.IsPrime(151).ShouldBeTrue();
            collection.IsPrime(1123).ShouldBeTrue();
            collection.IsPrime(9973).ShouldBeTrue();

            collection.IsPrime(15).ShouldBeFalse();
            collection.IsPrime(121).ShouldBeFalse();
            collection.IsPrime(10.Power(8)).ShouldBeFalse();

            collection.Count.ShouldBeBetween(24, 26);
        }

        [TestMethod]
        public void PrimeCollectionShouldKnowPrimeOrder()
        {
            var collection = new PrimeCollection();

            collection.GetNthPrime(1).ShouldBe(2);
            collection.GetNthPrime(10).ShouldBe(29);
            collection.GetNthPrime(100).ShouldBe(541);
            collection.GetNthPrime(1000).ShouldBe(7919);
        }
    }
}
