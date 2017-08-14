using System.Diagnostics;

namespace ProjectEuler.Core
{
    public class ProblemWithDiagnostics : IProjectEulerProblem
    {
        public ProblemWithDiagnostics(IProjectEulerProblem problem)
        {
            _problem = problem;
            _stopWatch = new Stopwatch();
            Milliseconds = 0;
        }

        private readonly IProjectEulerProblem _problem;
        private readonly Stopwatch _stopWatch;
        public long Milliseconds { get; private set; }

        public object Solve()
        {
            _stopWatch.Reset();
            _stopWatch.Start();

            var solutiuon = _problem.Solve();

            _stopWatch.Stop();
            Milliseconds = _stopWatch.ElapsedMilliseconds;

            return solutiuon;
        }
    }
}
