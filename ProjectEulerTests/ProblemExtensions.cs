﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Core;
using ProjectEuler.Math;

namespace ProjectEulerTests
{
    public static class ProblemExtensions
    {
        public static TimedResult SolutionShouleBe(this IProjectEulerProblem problem, object expectedSolution)
        {
            var result = problem.SolveWithTimedResult();

            if (result.Solution is long && expectedSolution is int)
            {
                expectedSolution = ((int)expectedSolution).ToLong();
            }

            if (!expectedSolution.Equals(result.Solution))
            {
                throw new Exception($"{result.Name} expected a solution of {expectedSolution}, but returned {result.Solution}.");
            }
            Assert.AreEqual(expectedSolution, result.Solution);

            return result;
        }

        public static void SolveTimeShouldBeLessThan(this TimedResult problem, long milliseconds)
        {
            if (problem.Milliseconds >= milliseconds)
            {
                throw new Exception($"{problem.Name} took too long to solve.");
            }
        }

        public static void VerifySolutionAndPerformance(this IProblemAndMetadata problem)
        {
            problem
                .SolutionShouleBe(problem.ExpectedSolution)
                .SolveTimeShouldBeLessThan((problem.Benchmark * 0.5).ToLong());
        }
    }
}