using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Core;
using ProjectEuler.Helpers;
using ProjectEuler.Primes;
using ProjectEuler.Problems;
using ProjectEuler.Problems.Problem99;

namespace ProjectEulerTests
{
    [TestClass]
    public class ProblemTests
    {
        [TestMethod]
        public void TestSolutionsAndTimeToSolve()
        {
            var log = new Log();

            PrimeExtensions.PreLoadSieve(); // Give that sieve some time to load

            // Ideally, would find with reflection.
            var problemsToVerify = new IProjectEulerProblem[]
            {
                new Problem1(),
                new Problem5(),
                new Problem60() 
            };

            foreach (var problem in problemsToVerify)
            {
                problem.VerifySolutionAndPerformance();
            }

            new Problem2()
                .SolutionShouleBe(4613732)
                .SolveTimeShouldBeLessThan(25);

            new Problem3()
                .SolutionShouleBe(6857)
                .SolveTimeShouldBeLessThan(125);

            new Problem4()
                .SolutionShouleBe(906609)
                .SolveTimeShouldBeLessThan(200);

            new Problem6()
                .SolutionShouleBe(25164150)
                .SolveTimeShouldBeLessThan(30);

            new Problem7()
                .SolutionShouleBe(104743)
                .SolveTimeShouldBeLessThan(50);

            new Problem10()
                .SolutionShouleBe(142913828922)
                .SolveTimeShouldBeLessThan(100);

            new Problem25()
                .SolutionShouleBe(4782)
                .SolveTimeShouldBeLessThan(300);

            new Problem27()
                .SolutionShouleBe(-59231)
                .SolveTimeShouldBeLessThan(60);

            new Problem47()
                .SolutionShouleBe(134043)
                .SolveTimeShouldBeLessThan(25);

            new Problem58()
                .SolutionShouleBe(26241)
                .SolveTimeShouldBeLessThan(800);

            new Problem72()
                .SolutionShouleBe(303963552391)
                .SolveTimeShouldBeLessThan(1200);

            new Problem65(log)
                .SolutionShouleBe(272)
                .SolveTimeShouldBeLessThan(50);

            new Problem99()
                .SolutionShouleBe(709)
                .SolveTimeShouldBeLessThan(75);

            new Problem387()
                .SolutionShouleBe(696067597313468)
                .SolveTimeShouldBeLessThan(1000);
        }
    }
}