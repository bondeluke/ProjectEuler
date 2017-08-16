using System.IO;
using ProjectEuler.Core;
using ProjectEuler.Problems;

namespace ProjectEuler
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var log = new Logger();

            var problem = new Problem47().WithDiagnostics();

            var solution = problem.Solve();

            var output = new OutputWriter(log).GetOutput(solution, problem.Milliseconds);

            File.WriteAllText(FileHelper.GetFullPath("output.txt"), output);
        }
    }
}