namespace ProjectEuler.Core
{
    /// <summary>
    ///     An interface for testing a smaller version of a problem.
    /// </summary>
    public interface ITestCaseable
    {
        object TestSolution { get; }

        /// <summary>
        ///     The best solve time for this problem (in milliseconds)
        /// </summary>
        long TestBenchmark { get; }

        object TestSolve();
    }

    public class TestCase : IProjectEulerProblem
    {
        private readonly ITestCaseable _small;

        public TestCase(ITestCaseable small)
        {
            _small = small;
        }

        public object ExpectedSolution => _small.TestSolution;
        public long Benchmark => _small.TestBenchmark;
        public object Solve() => _small.TestSolve();
    }
}