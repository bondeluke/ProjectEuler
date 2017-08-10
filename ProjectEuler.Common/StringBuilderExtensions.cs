using System;
using System.Text;

namespace ProjectEuler.Common
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder AppendLine(this StringBuilder sb, string format, params object[] args)
        {
            return sb.AppendLine(String.Format(format, args));
        }
    }
}