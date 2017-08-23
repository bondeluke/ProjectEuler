namespace ProjectEuler.Core
{
    public static class ProblemExtensions
    {
        public static string GetName(this IProjectEulerProblem problem) => problem.GetType().Name;

        public static IProjectEulerProblem GetTestCase(this ITestCaseable problem) => new TestCase(problem);
    }
}
