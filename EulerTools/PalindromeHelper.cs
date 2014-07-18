using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerTools
{
    public static class PalindromeHelper
    {
        public static bool IsPalindrome(long number)
        {
            int numDigits = Convert.ToInt32(Math.Ceiling(Math.Log10(number)));

            int p = 1;
            while (p <= numDigits / 2)
                if (GetIthDigit(p, number, numDigits) != GetIthDigit(numDigits - p++ + 1, number, numDigits))
                    return false;

            return true;
        }

        private static int GetIthDigit(int p, long number, int numDigits)
        {
            if (p == 1)
                return Convert.ToInt32(number % 10);

            long largeBase = Convert.ToInt64(Math.Pow(10, p));
            long normalBase = Convert.ToInt64(Math.Pow(10, p - 1));
            long part = number % largeBase;
            long smallerPart = part % normalBase;

            return Convert.ToInt32((part - smallerPart) / normalBase);
        }

    }
}
