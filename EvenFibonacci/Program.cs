using EulerTools;
using System.Collections;

namespace EvenFibonacci
{
    // Problem 2
    // By considering the terms in the Fibonacci sequence whose values do 
    // not exceed four million, find the sum of the even-valued terms

    class Program
    {
        const int limit = 4000000;

        static void Main(string[] args)
        {
            int sum = 0;
            int fib;
            FibGenerator fibGenerator = new FibGenerator();

            while ((fib = fibGenerator.Next()) < limit)
                if (IsEven(fib))
                    sum += fib;
            
            EulerHelper.DisplayAnswer(sum);
        }

        static bool IsEven(int number)
        {
            return number % 2 == 0;
        }
    }
}
