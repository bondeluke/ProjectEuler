using ProjectEuler.Problems;
using System;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            var problem = new SumOfPrimes().WithDiagnostics();

            Console.WriteLine($"Solution: {problem.Solve()}. Time elapsed: {problem.Milliseconds} millisecond(s).");

            Console.ReadLine();
        }
    }
}
