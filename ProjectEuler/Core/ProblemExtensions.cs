namespace ProjectEuler.Core
{
    public static class ProblemExtensions
    {
        public static string GetName(this IProjectEulerProblem problem) => problem.GetType().Name;
    }
}
