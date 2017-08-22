using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Math;

namespace ProjectEulerTests.Math
{
    [TestClass]
    public class RomanNumerableTests
    {
        private readonly Isomorphism<string, int> _simpleMappings;
        private readonly Isomorphism<string, int> _subtraciveMappings;

        public RomanNumerableTests()
        {
            _simpleMappings = new Isomorphism<string, int>
            {
                {"I", 1},
                {"II", 2},
                {"III", 3},
                {"V", 5},
                {"VI", 6},
                {"X", 10},
                {"XI", 11},
                {"XVI", 16},
                {"XX", 20},
                {"XXI", 21},
                {"XXII", 22},
                {"XXV", 25},
                {"XXXVII", 37},
                {"L", 50},
                {"LI", 51},
                {"LV", 55},
                {"LX", 60},
                {"LXXXVII", 87},
                {"CI", 101},
                {"CV", 105},
                {"CX", 110},
                {"CL", 150},
                {"CLX", 160},
                {"CLXXVII", 177},
                {"CC", 200},
                {"CCCLXXVII", 377},
                {"D", 500 },
                {"DI", 501 },
                {"DV", 505 },
                {"DX", 510 },
                {"DL", 550 },
                {"DC", 600 },
                {"DCCCLXXXVI", 886},
                {"M", 1000 },
                {"MI", 1001 },
                {"MV", 1005 },
                {"MX", 1010 },
                {"ML", 1050 },
                {"MD", 1500 },
                {"MM", 2000 },
                {"MMDCCLXVII", 2767 },
                {"MDCVI", 1606 },
                {"MMMMMMMDCCCLXI", 7861 }
            };

            _subtraciveMappings = new Isomorphism<string, int>
            {
                {"IV", 4},
                {"IX", 9},
                {"XIV", 14},
                {"XIX", 19},
                {"XXIV", 24},
                {"XXIX", 29},
                {"XL", 40},
                {"XLIV", 44},
                {"XLIX", 49},
                {"XC", 90},
                {"XCIV", 94},
                {"XCIX", 99},
                {"CD", 400},
                {"CDXLIV", 444},
                {"CM", 900},
                {"CMXCIX", 999},
                {"MMMMCDXCI", 4491 }
            };
        }

        [TestMethod]
        public void BasicToRoman()
        {
            foreach (var mapping in _simpleMappings)
            {
                mapping.Item2.ToRoman().ShouldBe(mapping.Item1);
            }
        }

        [TestMethod]
        public void SubtractiveToRoman()
        {
            foreach (var mapping in _subtraciveMappings)
            {
                mapping.Item2.ToRoman().ShouldBe(mapping.Item1);
            }
        }

        [TestMethod]
        public void BasicFromRoman()
        {
            foreach (var mapping in _simpleMappings)
            {
                mapping.Item1.FromRoman().ShouldBe(mapping.Item2);
            }
        }

        [TestMethod]
        public void SubtractiveFromRoman()
        {
            foreach (var mapping in _subtraciveMappings)
            {
                mapping.Item1.FromRoman().ShouldBe(mapping.Item2);
            }
        }
    }
}
