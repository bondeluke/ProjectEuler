using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerTools;

namespace MultipliesOf3And5
{
    // Problem 1
    // Find the sum of all the multiples of 3 or 5 below 1000. 

    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            for (int number = 0; number < 1000; number++)
                if (IsMultipleOf3Or5(number))
                    sum += number;

            EulerHelper.DisplayAnswer(sum);
        }

        static bool IsMultipleOf3Or5(int number)
        {
            if (number % 3 == 0 || number % 5 == 0)
                return true;

            return false;
        }
    }
}
