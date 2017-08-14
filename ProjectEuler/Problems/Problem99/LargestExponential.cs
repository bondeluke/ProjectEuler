using System;
using ProjectEuler.Core;
using ProjectEuler.Primes;
using System.IO;
using System.Collections.Generic;
using ProjectEuler.Math;

namespace ProjectEuler.Problems.Problem99
{
    class LargestExponential : IProjectEulerProblem
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

        private bool IsGreaterThan(LineInfo line1, LineInfo line2)
        {
            var factors1 = line1.Base.ToLong().GetPrimeFactors();
            var factors2 = line2.Base.ToLong().GetPrimeFactors();

            return true;
        }

        private LineInfo[] GetLines()
        {
            var path = FileHelper.GetFullPath("Problems\\Problem99\\numbers.txt");

            var lines = File.ReadAllLines(path);

            var lineInfo = new List<LineInfo>();

            for (int i = 0; i < lines.Length; i++)
            {
                var lineNumber = i + 1;
                var pair = lines[i].Split(',');
                var @base = Convert.ToInt32(pair[0]);
                var exponent = Convert.ToInt32(pair[1]);

                lineInfo.Add(new LineInfo(lineNumber, @base, exponent));
            }

            return lineInfo.ToArray();
        }
    }
}
