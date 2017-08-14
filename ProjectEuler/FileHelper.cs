using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    static class FileHelper
    {
        public static string GetFullPath(string relativePath)
        {
            var path = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            var parent = path.Parent.Parent.FullName;

            return Path.Combine(parent, relativePath);
        }
    }
}
