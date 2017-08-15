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
    }
}
