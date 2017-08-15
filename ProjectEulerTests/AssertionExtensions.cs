using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEulerTests
{
    internal static class AssertionExtensions
    {
        public static void ShouldBeTrue(this bool value)
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(value);
        }

        public static void ShouldBeFalse(this bool value)
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(value);
        }

        public static void ShouldBe<T>(this T value, T expectedValue)
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedValue, value);
        }

        public static void ShouldBeBetween(this int value, int lower, int upper)
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(value >= lower);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(value <= upper);
        }

        public static Assertable<T> Assert<T>(this T thing) => new Assertable<T>(thing);

        public static void AssertThat<T>(this T thing, Action<T> assertion)
        {
            assertion(thing);
        }

        public static Assertable<T> And<T>(this Assertable<T> assert, Action<T> assertion) => assert.That(assertion);
    }

    public class Assertable<T>
    {
        public Assertable(T thing)
        {
            _thing = thing;
        }

        private readonly T _thing;

        public Assertable<T> That(Action<T> assertion)
        {
            assertion(_thing);
            return this;
        }
    }
}
