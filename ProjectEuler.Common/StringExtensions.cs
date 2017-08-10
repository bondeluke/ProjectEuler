using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Common
{
    public static class StringExtensions
    {
        public static string Format(this string format, params object [] args)
        {
            return String.Format(format, args);
        }

        public static bool IsPalindrome(this string subject)
        {
            if (subject.Length <= 1)
                return true;
            else
                return subject.GetFirstChar() == subject.GetLastChar() && 
                    subject.StripEnds(1).IsPalindrome();
        }

        private static char GetFirstChar(this string subject)
        {
            return subject[0];
        }

        private static char GetLastChar(this string subject)
        {
            return subject[subject.Length - 1];
        }

        private static string StripEnds(this string subject, int distance)
        {
            return subject.Substring(distance, subject.Length - 1 - distance);
        }
    }
}
