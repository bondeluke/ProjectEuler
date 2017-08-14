using System.IO;

namespace ProjectEuler
{
    static class FileHelper
    {
        public static string GetFullPath(string relativePath)
        {
            var path = Directory.GetCurrentDirectory();

            return Path.Combine(path, relativePath);
        }
    }
}
