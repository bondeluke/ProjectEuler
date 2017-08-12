using ProjectEuler.Problems;

namespace ProjectEuler
{
    static class ProblemExtensions
    {
        public static ProblemWithDiagnostics WithDiagnostics(this IProjectEulerProblem problem)
        {
            return new ProblemWithDiagnostics(problem);
        }
    }
}
