using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Core;
using ProjectEuler.Math;

namespace ProjectEulerTests
{
    public static class ProblemExtensions
    {
        public static ProblemWithDiagnostics SolutionShouleBe(this IProjectEulerProblem problem, object expectedSolution)
        {
            var name = problem.GetType().Name;

            var withDiagnostics = problem.WithDiagnostics();

            var solution = withDiagnostics.Solve();

            if (solution is long && expectedSolution is int)
            {
                expectedSolution = ((int)expectedSolution).ToLong();
            }

            if (!expectedSolution.Equals(solution))
            {
                throw new Exception($"{name} expected a solution of {expectedSolution}, but returned {solution}.");
            }
            Assert.AreEqual(expectedSolution, solution);

            return withDiagnostics;
        }

        public static void AndSolveTimeShouldBeUnder(this ProblemWithDiagnostics problem, long milliseconds)
        {
            Assert.IsTrue(problem.Milliseconds < milliseconds);
        }
    }
}
