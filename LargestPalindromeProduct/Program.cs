using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestPalindromeProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            int smallerHalf, largerHalf, product, previousProduct = Int32.MaxValue;
            for (int sum = 1998; sum > 200; sum--)
            {
                smallerHalf = sum / 2;
                largerHalf = sum - smallerHalf;
                while (largerHalf <= 999 && smallerHalf >= 100)
                {
                    product = smallerHalf * largerHalf;
                    Console.WriteLine(String.Format("{0} x {1} = {2}", largerHalf++, smallerHalf--, product));
                    if (previousProduct < product)
                        break;
                    previousProduct = product;
                }
            }
            Console.ReadLine();
        }
    }
}
