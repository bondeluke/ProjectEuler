using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Math;

namespace ProjectEulerTests.Math
{
    [TestClass]
    public class PhiTests
    {
        [TestMethod]
        public void Sieve()
        {
            var sieve = new PhiSieve(1000);

            sieve.Phi(0).ShouldBe(0);
            sieve.Phi(1).ShouldBe(1);
            sieve.Phi(2).ShouldBe(1);
            sieve.Phi(6).ShouldBe(2);
            sieve.Phi(9).ShouldBe(6);
            sieve.Phi(1000).ShouldBe(400);
        }
    }
}
