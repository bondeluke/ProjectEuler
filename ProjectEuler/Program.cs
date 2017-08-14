using System;
using ProjectEuler.Core;
using ProjectEuler.Problems;
using ProjectEuler.Problems.Problem99;

namespace ProjectEuler
{
    public class Program
    {
        static void Main(string[] args)
        {
            var problem = new Problem99().WithDiagnostics();

            Console.WriteLine($"Solution: {problem.Solve()}. Time elapsed: {problem.Milliseconds} millisecond(s).");

            Console.ReadLine();
        }
    }
}
