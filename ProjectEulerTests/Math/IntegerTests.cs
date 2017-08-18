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

        [TestMethod]
        public void DivideBy()
        {
            var result = 4L.DivideBy(3);
            result.Quotient.ShouldBe(1);
            result.Remainder.ShouldBe(1);

            result = 24L.DivideBy(4);
            result.Quotient.ShouldBe(6);
            result.Remainder.ShouldBe(0);

            result = 24L.DivideBy(25);
            result.Quotient.ShouldBe(0);
            result.Remainder.ShouldBe(24);
        }

        [TestMethod]
        public void Product()
        {
            new[] { 1L }.Product().ShouldBe(1);
            new[] { 1L, 5 }.Product().ShouldBe(5);
            new[] { 1L, 2, 5 }.Product().ShouldBe(10);
            new[] { 1L, 2, 3, 3 }.Product().ShouldBe(18);
            new[] { 3, 2, 3L }.Product().ShouldBe(18);
        }

        [TestMethod]
        public void IsPalindrome()
        {
            0L.IsPalindrome().ShouldBeTrue();
            1L.IsPalindrome().ShouldBeTrue();
            22L.IsPalindrome().ShouldBeTrue();
            909L.IsPalindrome().ShouldBeTrue();

            123L.IsPalindrome().ShouldBeFalse();
            1321L.IsPalindrome().ShouldBeFalse();
        }

        [TestMethod]
        public void DigitSum()
        {
            1L.SumDigits().ShouldBe(1);
            12L.SumDigits().ShouldBe(3);
            555L.SumDigits().ShouldBe(15);
        }

        [TestMethod]
        public void Harshad()
        {
            201L.IsHarshad().ShouldBeTrue();
            202L.IsHarshad().ShouldBeFalse();
        }

        [TestMethod]
        public void TruncateRight()
        {
            201L.TruncateRight().ShouldBe(20);
            201L.TruncateRight().TruncateRight().ShouldBe(2);
        }

        [TestMethod]
        public void Concat()
        {
            2L.Concat(1).ShouldBe(21);
            1L.Concat(2).ShouldBe(12);
            12345L.Concat(6789).ShouldBe(123456789);
        }
    }
}
