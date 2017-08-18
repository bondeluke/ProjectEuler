namespace ProjectEuler.Core
{
    public interface IProjectEulerProblem
    {
        object ExpectedSolution { get; }

        /// <summary>
        /// The best solve time for this problem (in milliseconds)
        /// </summary>
        long Benchmark { get; }

        object Solve();
    }
}
