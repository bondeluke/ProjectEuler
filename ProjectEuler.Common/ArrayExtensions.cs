using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Common
{
    public static class ArrayExtensions
    {
        public static void DoubleSize<T>(this T[] array)
        {
            var newSize = array.Length * 2;
            var newArray = new T[newSize];
            array.CopyTo(newArray, 0);

            array = newArray;
        }
    }
}
