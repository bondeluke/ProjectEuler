using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Math;

namespace ProjectEulerTests
{
    [TestClass]
    public class IntegerTests
    {
        [TestMethod]
        public void IsMultipleOfTests()
        {
            long x = 3;
            x.IsMultipleOf(1).ShouldBeTrue();
            x.IsMultipleOf(3).ShouldBeTrue();
            x.IsMultipleOf(2).ShouldBeFalse();

            x = 6;
            x.IsMultipleOf(2).ShouldBeTrue();
            x.IsMultipleOf(3).ShouldBeTrue();
            x.IsMultipleOf(5).ShouldBeFalse();
            x.IsMultipleOf(12).ShouldBeFalse();
            x.IsMultipleOfAny(2, 5).ShouldBeTrue();
            x.IsMultipleOfAny(3, 7).ShouldBeTrue();
        }

        [TestMethod]
        public void GcdAndCoPrimeShouldWork()
        {
            1L.Gcd(1).ShouldBe(1);
            2L.Gcd(3).ShouldBe(1);
            4L.Gcd(12).ShouldBe(4);
            6L.Gcd(12).ShouldBe(6);
            10L.Gcd(25).ShouldBe(5);
            36L.Gcd(15).ShouldBe(3);

            6L.IsCoPrimeWith(1).ShouldBeTrue();
            6L.IsCoPrimeWith(2).ShouldBeFalse();
            6L.IsCoPrimeWith(3).ShouldBeFalse();
            6L.IsCoPrimeWith(4).ShouldBeFalse();
            6L.IsCoPrimeWith(5).ShouldBeTrue();
            6L.IsCoPrimeWith(6).ShouldBeFalse();
        }

        [TestMethod]
        public void GetLesserCoPrimesShouldWork()
        {
            var coPrimes = 6L.GetLesserCoPrimes();

            coPrimes.Length.ShouldBe(2);
            coPrimes[0].ShouldBe(1);
            coPrimes[1].ShouldBe(5);

            coPrimes = 5L.GetLesserCoPrimes();

            coPrimes.Length.ShouldBe(4);
            coPrimes[0].ShouldBe(1);
            coPrimes[1].ShouldBe(2);
            coPrimes[2].ShouldBe(3);
            coPrimes[3].ShouldBe(4);
        }
    }
}
