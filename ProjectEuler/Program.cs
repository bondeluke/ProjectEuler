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

            var result = new Problem7().SolveWithTimedResult();

            log.WriteLine(result);

            File.WriteAllText(FileHelper.GetFullPath("output.txt"), log.ReadAll());
        }
    }
}