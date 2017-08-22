using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectEuler.Math;

namespace ProjectEuler
{
    public static class StringExtensions
    {
        public static bool IsPalindrome(this string value)
        {
            if (value.Length <= 1)
                return true;

            return value.GetFirstChar() == value.GetLastChar() &&
                   value.StripEnds(1).IsPalindrome();
        }

        private static char GetFirstChar(this string value) => value[0];

        private static char GetLastChar(this string value) => value[value.Length - 1];

        private static string StripEnds(this string value, int distance) => value.Substring(distance, value.Length - 1 - distance);

        public static string StripRight(this string value, int distance = 1) => value.Substring(0, value.Length - distance);

        public static string StringJoin(this IEnumerable<long> values, string seperator = ", ") => string.Join(seperator, values);
        public static string Plus(this string value, object addition) => value + addition;

        public static string Repeat(this string value, int times)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < times; i++)
            {
                sb.Append(value);
            }

            return sb.ToString();
        }
    }
}