using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Math;

namespace ProjectEulerTests.Math
{
    [TestClass]
    public class IsomorphismTests
    {
        public void Creation()
        {
            var x = new Isomorphism<int, int>
            {
                {1, 2},
                {2, 4}
            };

            var y = new Isomorphism<string, int>
            {
                {"I", 1},
                {"V", 5}
            };
        }

        public void BiDirectionLookup()
        {
            var x = new Isomorphism<string, int>
            {
                {"I", 1},
                {"V", 5}
            };

            x["V"].ShouldBe(5);
            x[5].ShouldBe("V");
            x["I"].ShouldBe(1);
            x[1].ShouldBe("I");
        }
    }
}
