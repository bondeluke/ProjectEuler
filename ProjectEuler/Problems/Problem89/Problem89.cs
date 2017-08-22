using System.IO;
using ProjectEuler.Core;
using ProjectEuler.Helpers;
using ProjectEuler.Math;

namespace ProjectEuler.Problems.Problem89
{
    public class Problem89 : IProjectEulerProblem
    {
        public object ExpectedSolution => 743;
        public long Benchmark => 94;

        public object Solve()
        {
            var path = FileHelper.GetFullPath("Problems\\Problem89\\numbers.txt");

            var lines = File.ReadAllLines(path);

            var charactersSaved = 0;

            foreach (var line in lines)
            {
                var charCount = line.Trim().Length;
                var better = line.FromRoman().ToRoman().Length;

                charactersSaved += charCount - better;
            }

            return charactersSaved;
        }
    }
}