using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEulerTests
{
    internal static class AssertionExtensions
    {
        public static void ShouldBeTrue(this bool value)
        {
            Assert.IsTrue(value);
        }

        public static void ShouldBeFalse(this bool value)
        {
            Assert.IsFalse(value);
        }

        public static void ShouldBe<T>(this T value, T expectedValue)
        {
            Assert.AreEqual(expectedValue, value);
        }

        public static void ShouldBeBetween(this int value, int lower, int upper)
        {
            Assert.IsTrue(value >= lower);
            Assert.IsTrue(value <= upper);
        }
    }
}
