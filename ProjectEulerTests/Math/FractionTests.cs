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
        public void Creation()
        {
            // Not fancy... 117 characters
            var f = Fraction.New(-1, 3);
            f.Numerator.ShouldBe(-1);
            f.Denominator.ShouldBe(3);

            // A little fancy... 162 characters
            Fraction.New(1, -3).AssertThat(x =>
            {
                x.Numerator.ShouldBe(-1);
                x.Denominator.ShouldBe(3);
            });

            // Very fancy... 146 characters
            Fraction.New(-1, -3).Assert()
                .That(x => x.Numerator.ShouldBe(1))
                .And(x => f.Denominator.ShouldBe(3));
        }

        [TestMethod]
        public void Equality()
        {
            Fraction.New(2, 3).ShouldBe(Fraction.New(2, 3));
            Fraction.New(4, 6).ShouldBe(Fraction.New(2, 3));
            Fraction.New(2, 3).ShouldBe(Fraction.New(4, 6));
            Fraction.New(6, 2).ShouldBe(Fraction.New(3, 1));
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
        public void ScalarAddition()
        {
            (1 + _threeSixths).ShouldBe(Fraction.New(9, 6));
            (_threeSixths + 1).ShouldBe(Fraction.New(9, 6));
        }

        [TestMethod]
        public void Subtraction()
        {
            (_threeSixths - _twoSixths).ShouldBe(_oneSixth);
            (_oneHalf - _oneThird).ShouldBe(_oneSixth);
        }

        [TestMethod]
        public void ScalarSubtraction()
        {
            (1 - _oneThird).ShouldBe(_twoThirds);
            (_oneThird - 1).ShouldBe(Fraction.New(-2, 3));
        }

        [TestMethod]
        public void Multiplication()
        {
            (_twoThirds * _fiveSixths).ShouldBe(Fraction.New(10, 18));
            (_fiveSixths * _twoThirds).ShouldBe(Fraction.New(10, 18));

            (2 * _oneThird).ShouldBe(_twoThirds);
            (_twoSixths * 2).ShouldBe(_twoThirds);
        }

        [TestMethod]
        public void ScalarMultiplication()
        {
            (2 * _oneThird).ShouldBe(_twoThirds);
            (_twoSixths * 2).ShouldBe(_twoThirds);
        }

        [TestMethod]
        public void Division()
        {
            (_twoThirds / _oneHalf).ShouldBe(Fraction.New(4, 3));
            (_oneHalf / _twoThirds).ShouldBe(Fraction.New(3, 4));
        }

        [TestMethod]
        public void ScalarDivision()
        {
            (1 / _fiveSixths).ShouldBe(Fraction.New(6, 5));
            (2 / _twoThirds).ShouldBe(Fraction.New(6, 2));

            (_twoThirds / 2).ShouldBe(_oneThird);
        }

        [TestMethod]
        public void Inversion()
        {
            Fraction.New(6, 5).Invert().ShouldBe(_fiveSixths);
        }

        [TestMethod]
        public void ToWhole()
        {
            Fraction.New(6, 2).ToWhole().ShouldBe(3);
            Fraction.New(4, 1).ToWhole().ShouldBe(4);
        }

        [TestMethod]
        public void ToFraction()
        {
            2L.ToFraction().ShouldBe(Fraction.New(2, 1));
        }
    }
}