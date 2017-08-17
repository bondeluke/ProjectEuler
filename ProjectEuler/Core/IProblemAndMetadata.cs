namespace ProjectEuler.Core
{
    public interface IProblemAndMetadata : IProjectEulerProblem
    {
        /// <summary>
        /// The best solve time for this problem (in milliseconds)
        /// </summary>
        long Benchmark { get; }

        object ExpectedSolution { get; }
    }
}
