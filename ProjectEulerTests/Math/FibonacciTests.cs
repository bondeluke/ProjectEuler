using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Math;

namespace ProjectEulerTests.Math
{
    [TestClass]
    public class FibonacciTests
    {
        [TestMethod]
        public void Sequence()
        {
            var seq = new FibonacciSequence().Take(10).ToArray();

            seq[0].ShouldBe(1);
            seq[1].ShouldBe(1);
            seq[2].ShouldBe(2);
            seq[3].ShouldBe(3);
            seq[4].ShouldBe(5);
        }
    }
}
