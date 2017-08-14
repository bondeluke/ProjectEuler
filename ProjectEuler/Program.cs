using ProjectEuler.Problems;
using ProjectEuler.Problems.Problem99;
using System;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            var problem = new LargestExponential().WithDiagnostics();

            Console.WriteLine($"Solution: {problem.Solve()}. Time elapsed: {problem.Milliseconds} millisecond(s).");

            Console.ReadLine();
        }
    }
}
