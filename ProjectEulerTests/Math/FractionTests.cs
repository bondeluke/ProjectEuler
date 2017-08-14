using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Math;

namespace ProjectEulerTests.Math
{
    [TestClass]
    public class FractionTests
    {
        private static readonly Fraction _oneHalf = Fraction.New(1, 2);
        private static readonly Fraction _oneThird = Fraction.New(1, 3);
        private static readonly Fraction _twoThirds = Fraction.New(2, 3);
        private static readonly Fraction _oneSixth = Fraction.New(1, 6);
        private static readonly Fraction _twoSixths = Fraction.New(2, 6);
        private static readonly Fraction _threeSixths = Fraction.New(3, 6);
        private static readonly Fraction _fourSixths = Fraction.New(4, 6);
        private static readonly Fraction _fiveSixths = Fraction.New(5, 6);

        [TestMethod]
        public void Equality()
        {
            Fraction.New(2, 3).ShouldBe(Fraction.New(2, 3));
            Fraction.New(4, 6).ShouldBe(Fraction.New(2, 3));
            Fraction.New(2, 3).ShouldBe(Fraction.New(4, 6));
        }

        [TestMethod]
        public void ScalingAndReducing()
        {
            _twoThirds.Scale(2).ShouldBe(_fourSixths);
            _twoThirds.Scale(3).Reduce().ShouldBe(_twoThirds);
        }

        [TestMethod]
        public void Addition()
        {
            (_twoSixths + _threeSixths).ShouldBe(_fiveSixths);
            (_oneThird + _oneHalf).ShouldBe(_fiveSixths);
        }

        [TestMethod]
        public void Subtraction()
        {
            (_threeSixths - _twoSixths).ShouldBe(_oneSixth);
            (_oneHalf - _oneThird).ShouldBe(_oneSixth);
            (1 - _oneThird).ShouldBe(_twoThirds);
        }

        [TestMethod]
        public void Multiplication()
        {
            (_twoThirds * _fiveSixths).ShouldBe(Fraction.New(10, 18));
            (_fiveSixths * _twoThirds).ShouldBe(Fraction.New(10, 18));
        }
    }
}
