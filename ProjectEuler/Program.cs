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
            Log.Current = new Log();

            var result = new Problem87().SolveWithTime();

            Log.Current.WriteLine(result);

            File.WriteAllText(FileHelper.GetFullPath("output.txt"), Log.Current.ReadAll());
        }
    }
}