using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Common;

namespace ProjectEuler.Problems
{
    class LargestPalindromeProduct : ProjectEulerProblem
    {
        private const byte NumDigits = 3;

        public LargestPalindromeProduct()
        {
            Id = 4;

            Statement = "Find the largest palindrome made from the product of two 3-digit numbers.";
        }

        public override void Solve()
        {
            Solution = GetThreeDigitProducts().Where(Integer.IsPalindrome).Largest();
        }

        private IEnumerable<long> GetThreeDigitProducts()
        {
            var range = Integer.GetNDigitBoundaries(NumDigits);

            for (var left = range.Lower; left < range.Upper; left++)
                for (var right = left; right < range.Upper; right++)
                    yield return left * right;
        }
    }
}