using System;

namespace ProjectEuler.Math
{
    public static class MathExtensions
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

        public static int ToInt(this string value)
        {
            return Convert.ToInt32(value);
        }

        public static double Sqrt(this long value)
        {
            return System.Math.Sqrt(value);
        }

        public static double Ceiling(this double value)
        {
            return System.Math.Ceiling(value);
        }

        public static long Power(this int value, int power)
        {
            return System.Math.Pow(value, power).ToLong();
        }

        public static long Power(this long value, int power)
        {
            return System.Math.Pow(value, power).ToLong();
        }
    }
}
