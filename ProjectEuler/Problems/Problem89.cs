using ProjectEuler.Core;
using ProjectEuler.Helpers;
using ProjectEuler.Math;

namespace ProjectEuler.Problems
{
    public class Problem89 : IProjectEulerProblem
    {
        public object ExpectedSolution => 743;
        public long Benchmark => 94;

        public object Solve()
        {
            var lines = FileHelper.GetResourceLines("p89.txt");

            var charactersSaved = 0;

            foreach (var line in lines)
            {
                var charCount = line.Trim().Length;
                var better = line.GetRomanValue().ToRoman().Length;

                charactersSaved += charCount - better;
            }

            return charactersSaved;
        }
    }
}