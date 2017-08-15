using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Math;

namespace ProjectEulerTests.Math
{
    [TestClass]
    public class AlgebraTests
    {
        [TestMethod]
        public void Divides()
        {
            1L.Divides(1).ShouldBeTrue();
            1L.Divides(99).ShouldBeTrue();
            2L.Divides(4).ShouldBeTrue();

            2L.Divides(5).ShouldBeFalse();
            4L.Divides(2).ShouldBeFalse();
        }

        [TestMethod]
        public void Gcd()
        {
            Algebra.Gcd(1, 1).ShouldBe(1);
            Algebra.Gcd(2, 3).ShouldBe(1);
            Algebra.Gcd(4, 12).ShouldBe(4);
            Algebra.Gcd(6, 12).ShouldBe(6);
            Algebra.Gcd(10, 25).ShouldBe(5);
            Algebra.Gcd(36, 15).ShouldBe(3);
        }

        [TestMethod]
        public void AreCoprime()
        {
            Algebra.AreCoprime(6, 1).ShouldBeTrue();
            Algebra.AreCoprime(6, 5).ShouldBeTrue();
            Algebra.AreCoprime(6, 2).ShouldBeFalse();
            Algebra.AreCoprime(6, 3).ShouldBeFalse();
            Algebra.AreCoprime(6, 4).ShouldBeFalse();
            Algebra.AreCoprime(6, 6).ShouldBeFalse();
        }

        [TestMethod]
        public void Lcm()
        {
            Algebra.Lcm(1, 1).ShouldBe(1);
            Algebra.Lcm(1, 3).ShouldBe(3);
            Algebra.Lcm(2, 3).ShouldBe(6);
            Algebra.Lcm(9, 24).ShouldBe(72);
            Algebra.Lcm(24, 9).ShouldBe(72);
        }

        [TestMethod]
        public void Totatives()
        {
            var totatives = 6L.GetTotatives();

            totatives.Length.ShouldBe(2);
            totatives[0].ShouldBe(1);
            totatives[1].ShouldBe(5);

            totatives = 5L.GetTotatives();

            totatives.Length.ShouldBe(4);
            totatives[0].ShouldBe(1);
            totatives[1].ShouldBe(2);
            totatives[2].ShouldBe(3);
            totatives[3].ShouldBe(4);
        }

        [TestMethod]
        public void Divisors()
        {
            1L.Divisors().Length.ShouldBe(1);
            1L.Divisors().First().ShouldBe(1);

            var divisors = 12L.Divisors();

            divisors.Length.ShouldBe(6);

            divisors[0].ShouldBe(1);
            divisors[1].ShouldBe(2);
            divisors[2].ShouldBe(3);
            divisors[3].ShouldBe(4);
            divisors[4].ShouldBe(6);
            divisors[5].ShouldBe(12);

            divisors = 4L.Divisors();

            divisors.Length.ShouldBe(3);

            divisors[0].ShouldBe(1);
            divisors[1].ShouldBe(2);
            divisors[2].ShouldBe(4);
        }

        [TestMethod]
        public void Phi()
        {
            1L.Phi().ShouldBe(1);
            2L.Phi().ShouldBe(1);
            6L.Phi().ShouldBe(2);
            9L.Phi().ShouldBe(6);
        }
    }
}
