using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Math;

namespace ProjectEulerTests.Math
{
    [TestClass]
    public class IntegerTests
    {
        [TestMethod]
        public void IsMultipleOf()
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
        public void Gcd()
        {
            1L.Gcd(1).ShouldBe(1);
            2L.Gcd(3).ShouldBe(1);
            4L.Gcd(12).ShouldBe(4);
            6L.Gcd(12).ShouldBe(6);
            10L.Gcd(25).ShouldBe(5);
            36L.Gcd(15).ShouldBe(3);
        }

        [TestMethod]
        public void IsCoPrime()
        {
            6L.IsCoPrimeWith(1).ShouldBeTrue();
            6L.IsCoPrimeWith(2).ShouldBeFalse();
            6L.IsCoPrimeWith(3).ShouldBeFalse();
            6L.IsCoPrimeWith(4).ShouldBeFalse();
            6L.IsCoPrimeWith(5).ShouldBeTrue();
            6L.IsCoPrimeWith(6).ShouldBeFalse();
        }

        [TestMethod]
        public void Lcm()
        {
            Integer.Lcm(1, 1).ShouldBe(1);
            Integer.Lcm(1, 3).ShouldBe(3);
            Integer.Lcm(2, 3).ShouldBe(6);
            Integer.Lcm(9, 24).ShouldBe(72);
            Integer.Lcm(24, 9).ShouldBe(72);
        }

        [TestMethod]
        public void GetLesserCoPrimes()
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

        [TestMethod]
        public void Range()
        {
            Integer.Range(0, 0).ToArray().Length.ShouldBe(0);
            Integer.Range(0, 1).ToArray().Length.ShouldBe(1);
            Integer.Range(0, 100).ToArray().Length.ShouldBe(100);
            Integer.Range(0, 100, 9).ToArray().Length.ShouldBe(12);

            var range = Integer.Range(0, 6, 3).ToArray();
            range.Length.ShouldBe(2);
            range[0].ShouldBe(0);
            range[1].ShouldBe(3);

            range = Integer.Range(1, 6, 3).ToArray();
            range.Length.ShouldBe(2);
            range[0].ShouldBe(1);
            range[1].ShouldBe(4);
        }
    }
}
