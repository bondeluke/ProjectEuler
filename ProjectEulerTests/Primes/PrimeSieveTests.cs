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
        }
    }
}
