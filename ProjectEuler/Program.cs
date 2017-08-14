﻿using System;
using ProjectEuler.Core;
using ProjectEuler.Problems;

namespace ProjectEuler
{
    public class Program
    {
        static void Main(string[] args)
        {
            var problem = new Problem72().WithDiagnostics();

            Console.WriteLine($"Solution: {problem.Solve()}. Time elapsed: {problem.Milliseconds} millisecond(s).");

            Console.ReadLine();
        }
    }
}
