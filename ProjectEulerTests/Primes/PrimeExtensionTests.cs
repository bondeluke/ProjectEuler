using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Math;
using ProjectEuler.Primes;

namespace ProjectEulerTests.Primes
{
    [TestClass]
    public class PrimeExtensionTests
    {
        [TestMethod]
        public void IsPrime()
        {
            2L.IsPrime().ShouldBeTrue();
            29L.IsPrime().ShouldBeTrue();

            4L.IsPrime().ShouldBeFalse();
            24L.IsPrime().ShouldBeFalse();

            10L.Power(8).IsPrime().ShouldBeFalse();

            1123L.IsPrime().ShouldBeTrue();
            4008200000033L.IsPrime().ShouldBeTrue();
        }

        [TestMethod]
        public void IsComposite()
        {
            2L.IsComposite().ShouldBeFalse();
            29L.IsComposite().ShouldBeFalse();

            4L.IsComposite().ShouldBeTrue();
            24L.IsComposite().ShouldBeTrue();
        }

        [TestMethod]
        public void Factorization()
        {
            var factors = 2L.GetPrimeFactors();
            factors.Length.ShouldBe(1);
            factors[0].ShouldBe(2);

            factors = 29L.GetPrimeFactors();
            factors.Length.ShouldBe(1);
            factors[0].ShouldBe(29);

            factors = 4L.GetPrimeFactors();
            factors.Length.ShouldBe(2);
            factors[0].ShouldBe(2);
            factors[1].ShouldBe(2);

            factors = 24L.GetPrimeFactors().OrderBy(p => p).ToArray();
            factors.Length.ShouldBe(4);
            factors[0].ShouldBe(2);
            factors[1].ShouldBe(2);
            factors[2].ShouldBe(2);
            factors[3].ShouldBe(3);

            factors = 24L.GetUniquePrimeFactors();
            factors.Length.ShouldBe(2);
            factors[0].ShouldBe(2);
            factors[1].ShouldBe(3);
        }
    }
}
