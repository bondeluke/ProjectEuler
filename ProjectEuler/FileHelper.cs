using System.IO;
using System.Reflection;

namespace ProjectEuler
{
    static class FileHelper
    {
        public static string GetFullPath(string relativePath)
        {
            var path = new DirectoryInfo(Assembly.GetEntryAssembly().Location);
            var parent = path.Parent.Parent.FullName;

            return Path.Combine(parent, relativePath);
        }
    }
}
