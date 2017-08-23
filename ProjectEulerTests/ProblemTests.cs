using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Core;
using ProjectEuler.Problems;

namespace ProjectEulerTests
{
    [TestClass]
    public class ProblemTests
    {
        [TestMethod]
        public void TestSolutionsAndTimeToSolve()
        {
            var problemsToVerify = new[]
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
                new Problem27(),
                new Problem47(),
                new Problem58(),
                new Problem60(),
                new Problem65(),
                new Problem72(),
                new Problem78().GetTestCase(),
                new Problem89(),
                new Problem99(),
                new Problem387()
            };

            foreach (var problem in problemsToVerify)
            {
                problem.VerifySolutionAndPerformance();
            }
        }
    }
}