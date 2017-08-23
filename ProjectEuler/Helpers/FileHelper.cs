using System.IO;

namespace ProjectEuler.Helpers
{
    public static class FileHelper
    {
        public static string GetFullPath(string relativePath)
        {
            //var path = Directory.GetCurrentDirectory(); // Doesn't work for unit tests
            var path = @"C:\Users\Luke\Source\Repos\ProjectEuler\ProjectEuler";

            return Path.Combine(path, relativePath);
        }

        public static string[] GetResourceLines(string name)
        {
            var path = GetFullPath("Resources\\" + name);

            return File.ReadAllLines(path);
        }
    }
}