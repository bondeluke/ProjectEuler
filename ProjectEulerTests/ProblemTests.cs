using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Core;
using ProjectEuler.Helpers;
using ProjectEuler.Primes;
using ProjectEuler.Problems;
using ProjectEuler.Problems.Problem89;
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
            var problemsToVerify = new []
            {
                new Problem1(),
                new Problem2(),
                new Problem3(),
                new Problem4(),
                new Problem5(),
                new Problem6(),
                new Problem7(),
                new Problem10(),
                new Problem25(),
                new Problem60(),
                new Problem78().GetTestCase(),
                new Problem89(),
                new Problem99()
            };

            foreach (var problem in problemsToVerify)
            {
                problem.VerifySolutionAndPerformance();
            }
            
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

            new Problem387()
                .SolutionShouleBe(696067597313468)
                .SolveTimeShouldBeLessThan(1000);
        }
    }
}