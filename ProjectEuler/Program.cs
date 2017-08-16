using System.IO;
using ProjectEuler.Core;
using ProjectEuler.Helpers;
using ProjectEuler.Problems;

namespace ProjectEuler
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var log = new Log();

            var problem = new Problem72().WithDiagnostics();

            var solution = problem.Solve();

            var output = new OutputWriter(log).GetOutput(problem.Name, solution, problem.Milliseconds);

            File.WriteAllText(FileHelper.GetFullPath("output.txt"), output);
        }
    }
}