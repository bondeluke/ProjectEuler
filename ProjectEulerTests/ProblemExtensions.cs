using System;
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
                throw new Exception($"{problem.Name} took too long to solve. It ran for {problem.Milliseconds} but was expected to run under {milliseconds}");
            }
        }

        public static void VerifySolutionAndPerformance(this IProjectEulerProblem problem)
        {
            problem
                .SolutionShouleBe(problem.ExpectedSolution)
                .SolveTimeShouldBeLessThan((problem.Benchmark * 1.1 + 5).ToLong());
        }
    }
}