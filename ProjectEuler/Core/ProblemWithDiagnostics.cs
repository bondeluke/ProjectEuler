using System.Diagnostics;

namespace ProjectEuler.Core
{
    public class ProblemWithDiagnostics : IProjectEulerProblem
    {
        public ProblemWithDiagnostics(IProjectEulerProblem problem)
        {
            _problem = problem;
            _stopWatch = new Stopwatch();
            _milliseconds = 0;
        }

        private IProjectEulerProblem _problem;
        private Stopwatch _stopWatch;
        public long Milliseconds => _milliseconds;
        private long _milliseconds;

        public object Solve()
        {
            _stopWatch.Reset();
            _stopWatch.Start();

            var solutiuon = _problem.Solve();

            _stopWatch.Stop();
            _milliseconds = _stopWatch.ElapsedMilliseconds;

            return solutiuon;
        }
    }
}
