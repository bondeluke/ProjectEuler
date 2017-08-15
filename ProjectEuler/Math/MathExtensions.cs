using System;

namespace ProjectEuler.Math
{
    public static class MathExtensions
    {
        public static long ToLong(this int value) => Convert.ToInt64(value);

        public static long ToLong(this double value) => Convert.ToInt64(value);

        public static long ToLong(this string value) => Convert.ToInt64(value);

        public static int ToInt(this string value) => Convert.ToInt32(value);

        public static int ToInt(this double value) => Convert.ToInt32(value);

        public static long Abs(this long value) => System.Math.Abs(value);

        public static double Sqrt(this long value) => System.Math.Sqrt(value);

        public static double Sqrt(this int value) => System.Math.Sqrt(value);

        public static double Ceiling(this double value) => System.Math.Ceiling(value);

        public static long Power(this int value, int power) => System.Math.Pow(value, power).ToLong();

        public static long Power(this long value, int power) => System.Math.Pow(value, power).ToLong();
    }
}