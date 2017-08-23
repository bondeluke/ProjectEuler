using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Math;
using ProjectEuler.Primes;

namespace ProjectEulerTests.Primes
{
    [TestClass]
    public class PrimeExtensionTests
    {
        public PrimeExtensionTests()
        {
            _sieve = new PrimeSieve();   
        }

        private readonly PrimeSieve _sieve;

        [TestMethod]
        public void IsPrime()
        {
            2L.IsPrime(_sieve).ShouldBeTrue();
            29L.IsPrime(_sieve).ShouldBeTrue();

            4L.IsPrime(_sieve).ShouldBeFalse();
            24L.IsPrime(_sieve).ShouldBeFalse();

            10L.Power(8).IsPrime(_sieve).ShouldBeFalse();

            1123L.IsPrime(_sieve).ShouldBeTrue();
            4008200000033L.IsPrime(_sieve).ShouldBeTrue();
        }

        [TestMethod]
        public void IsComposite()
        {
            2L.IsComposite(_sieve).ShouldBeFalse();
            29L.IsComposite(_sieve).ShouldBeFalse();

            4L.IsComposite(_sieve).ShouldBeTrue();
            24L.IsComposite(_sieve).ShouldBeTrue();
        }

        [TestMethod]
        public void Factorization()
        {
            var factors = 2L.GetPrimeFactors(_sieve);
            factors.Length.ShouldBe(1);
            factors[0].ShouldBe(2);

            factors = 29L.GetPrimeFactors(_sieve);
            factors.Length.ShouldBe(1);
            factors[0].ShouldBe(29);

            factors = 4L.GetPrimeFactors(_sieve);
            factors.Length.ShouldBe(2);
            factors[0].ShouldBe(2);
            factors[1].ShouldBe(2);

            factors = 24L.GetPrimeFactors(_sieve).OrderBy(p => p).ToArray();
            factors.Length.ShouldBe(4);
            factors[0].ShouldBe(2);
            factors[1].ShouldBe(2);
            factors[2].ShouldBe(2);
            factors[3].ShouldBe(3);

            factors = 24L.GetUniquePrimeFactors(_sieve);
            factors.Length.ShouldBe(2);
            factors[0].ShouldBe(2);
            factors[1].ShouldBe(3);
        }
    }
}
