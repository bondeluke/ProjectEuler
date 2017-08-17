using System.Diagnostics;

namespace ProjectEuler.Core
{
    public static class Timer
    {
        public static TimedResult SolveWithTimedResult(this IProjectEulerProblem problem)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            var solution = problem.Solve();

            stopwatch.Stop();

            return new TimedResult(problem.GetName(), solution, stopwatch.ElapsedMilliseconds);
        }
    }

    public class TimedResult
    {
        public TimedResult(string name, object solution, long milliseconds)
        {
            Name = name;
            Solution = solution;
            Milliseconds = milliseconds;
        }

        public object Solution { get; }
        public long Milliseconds { get; }
        public string Name { get; }

        public override string ToString() => $"{Name}\r\nSolution: {Solution}\r\nTime elapsed: {Milliseconds} millisecond(s)";
    }
}