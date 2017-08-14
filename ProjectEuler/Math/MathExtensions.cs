using System;

namespace ProjectEuler.Math
{
    static class MathExtensions
    {
        public static long ToLong(this int value)
        {
            return Convert.ToInt64(value);
        }

        public static long ToLong(this double value)
        {
            return Convert.ToInt64(value);
        }

        public static long ToLong(this string value)
        {
            return Convert.ToInt64(value);
        }

        public static double Sqrt(this long value)
        {
            return System.Math.Sqrt(value);
        }

        public static double Ceiling(this double value)
        {
            return System.Math.Ceiling(value);
        }

        public static double Power(this int value, double power)
        {
            return System.Math.Pow(value, power);
        }
    }
}
