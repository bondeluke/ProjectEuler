using System.Collections.Generic;
using System.IO;
using ProjectEuler.Core;
using ProjectEuler.Helpers;
using ProjectEuler.Math;

namespace ProjectEuler.Problems.Problem99
{
    // Largest Exponential
    public class Problem99 : IProjectEulerProblem
    {
        public object Solve()
        {
            var lines = GetLines();

            var line = GetLineWithLargestExponential(lines);

            return line.LineNumber;
        }

        private LineInfo GetLineWithLargestExponential(LineInfo[] lines)
        {
            var greatest = lines[0];

            foreach (var line in lines)
            {
                if (IsGreaterThan(line, greatest))
                {
                    greatest = line;
                }
            }

            return greatest;
        }

        private static bool IsGreaterThan(LineInfo line1, LineInfo line2) => Log(line1) > Log(line2);

        private static double Log(LineInfo line) => line.Exponent * System.Math.Log(line.Base);

        private static LineInfo[] GetLines()
        {
            var path = FileHelper.GetFullPath("Problems\\Problem99\\numbers.txt");

            var lines = File.ReadAllLines(path);

            var lineInfo = new List<LineInfo>();

            for (var i = 0; i < lines.Length; i++)
            {
                var lineNumber = i + 1;
                var pair = lines[i].Split(',');
                var @base = pair[0].ToInt();
                var exponent = pair[1].ToInt();

                lineInfo.Add(new LineInfo(lineNumber, @base, exponent));
            }

            return lineInfo.ToArray();
        }
    }
}