using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler;
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
            var logger = new Logger();

            new Problem1()
                .SolutionShouleBe(233168)
                .AndSolveTimeShouldBeUnder(30);

            new Problem2()
                .SolutionShouleBe(4613732)
                .AndSolveTimeShouldBeUnder(25);

            new Problem3()
                .SolutionShouleBe(6857)
                .AndSolveTimeShouldBeUnder(125);

            new Problem4()
                .SolutionShouleBe(906609)
                .AndSolveTimeShouldBeUnder(200);

            new Problem6()
                .SolutionShouleBe(25164150)
                .AndSolveTimeShouldBeUnder(30);

            new Problem7()
                .SolutionShouleBe(104743)
                .AndSolveTimeShouldBeUnder(50);

            new Problem10()
                .SolutionShouleBe(142913828922)
                .AndSolveTimeShouldBeUnder(100);

            new Problem25()
                .SolutionShouleBe(4782)
                .AndSolveTimeShouldBeUnder(300);

            new Problem58()
                .SolutionShouleBe(26241)
                .AndSolveTimeShouldBeUnder(800);

            new Problem72()
                .SolutionShouleBe(303963552391)
                .AndSolveTimeShouldBeUnder(2000);

            new Problem65(logger)
                .SolutionShouleBe(272)
                .AndSolveTimeShouldBeUnder(50);

            new Problem99()
                .SolutionShouleBe(709)
                .AndSolveTimeShouldBeUnder(75);

            new Problem387()
                .SolutionShouleBe(696067597313468)
                .AndSolveTimeShouldBeUnder(1000);
        }
    }
}