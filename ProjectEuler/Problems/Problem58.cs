using ProjectEuler.Core;
using ProjectEuler.Math;
using ProjectEuler.Primes;

namespace ProjectEuler.Problems
{
    // Spiral primes
    public class Problem58 : IProjectEulerProblem
    {
        public object Solve()
        {
            const double threshold = 0.1;
            var totalNumbers = 5; // 1, 3, 5, 7, 9
            var totalPrimes = 3;  // 3, 5, 7

            var layer = 1;

            while (((double)totalPrimes/totalNumbers) >= threshold)
            {
                layer++;

                for (byte diagonal = 0; diagonal < 4; diagonal++)
                {
                    var number = GetNumberAlongDiagonal(layer, diagonal);
                    if (number.IsPrime())
                        totalPrimes++;

                    totalNumbers++;
                }
            }

            return layer * 2 + 1;
        }

        private static long GetNumberAlongDiagonal(int layer, byte diagonal)
        {
            return (layer * 2 + 1).ToLong().Squared() - 2 * diagonal * layer;
        }
    }
}
