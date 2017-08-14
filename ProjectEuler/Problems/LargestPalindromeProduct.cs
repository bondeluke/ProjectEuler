using ProjectEuler.Core;
using ProjectEuler.Math;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    class LargestPalindromeProduct : IProjectEulerProblem
    {
        private const byte NumDigits = 3;

        public object Solve()
        {
            return GetThreeDigitProducts().Where(Integer.IsPalindrome).Largest();
        }

        private IEnumerable<long> GetThreeDigitProducts()
        {
            var range = Integer.GetAllNDigitNumbers(NumDigits);

            for (var left = range.Lower; left < range.Upper; left++)
                for (var right = left; right < range.Upper; right++)
                    yield return left * right;
        }
    }
}