using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerTools;

namespace LargestPalindromeProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            int largestProduct = 0, product;

            for (int preOp = 100; preOp < 1000; preOp++)
                for (int postOp = 100; postOp < 1000; postOp++)
                    if (PalindromeHelper.IsPalindrome(product = preOp * postOp))
                        if (product > largestProduct)
                            largestProduct = product; ;

            EulerHelper.DisplayAnswer(largestProduct);
        }
    }
}
