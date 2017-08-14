using ProjectEuler.Core;
using ProjectEuler.Math;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    // Problem 4: Find the largest palindrome made from the product of two 3-digit numbers.
    public class Problem4 : IProjectEulerProblem
    {
        private const byte NumDigits = 3;

        public object Solve()
        {
            return GetThreeDigitProducts().Where(Integer.IsPalindrome).Largest();
        }

        private IEnumerable<long> GetThreeDigitProducts()
        {
            var range = Integer.GetNumberOfLength(NumDigits);

            for (var left = range.Lower; left < range.Upper; left++)
                for (var right = left; right < range.Upper; right++)
                    yield return left * right;
        }
    }
}