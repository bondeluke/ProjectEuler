using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler.Math
{
    public class GeneralizedPentagonalSequence
    {
        public GeneralizedPentagonalSequence(int size)
        {
            size = size % 2 == 0? size : size + 1;
            Values = GenerateValues(size);
        }

        public long[] Values { get; }

        private long[] GenerateValues(int size)
        {
            var list = new List<long>();

            for (var i = 1; i <= size / 2; i++)
            {
                foreach (var sign in new[] { 1, -1 })
                {
                    var k = i * sign;
                    var value = k * (3 * k - 1) / 2;

                    list.Add(value);
                }
            }

            return list.ToArray();
        }
    }
}
