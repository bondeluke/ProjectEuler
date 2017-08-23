using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Math;

namespace ProjectEulerTests.Math
{
    [TestClass]
    public class GeneralizedPentagonalSequenceTests
    {
        [TestMethod]
        public void Sequence()
        {
            var x = new GeneralizedPentagonalSequence(5);

            x.Values[0].ShouldBe(1);
            x.Values[1].ShouldBe(2);
            x.Values[2].ShouldBe(5);
            x.Values[3].ShouldBe(7);
            x.Values[4].ShouldBe(12);
        }
    }
}
