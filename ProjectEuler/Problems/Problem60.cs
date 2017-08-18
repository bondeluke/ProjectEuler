using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEuler.Core;
using ProjectEuler.Math;
using ProjectEuler.Primes;

namespace ProjectEuler.Problems
{
    // Problem 60: Find the lowest sum for a set of five primes for which any two primes concatenate to produce another prime.
    public class Problem60 : IProjectEulerProblem
    {
        public object ExpectedSolution { get; }
        public long Benchmark { get; }

        private PrimeSieve _sieve;

        // On my first go, I got 423841 as my sum. That was wrong, but gives me an upper limit to work with.
        public object Solve()
        {

            const int power = 6;
            var limit = 423841;
            _sieve = new PrimeSieve(10.Power(7));

            var subset = _sieve.Primes
                .Where(p => p < limit)
                .Where(p => WorkTogether(p, 3) && WorkTogether(p, 7)).ToArray();

            var d = new Dictionary<long, List<long>>();

            for (int i = 0; i < subset.Length; i++)
            {
                for (int j = i + 1; j < subset.Length; j++)
                {
                    var p1 = subset[i];
                    var p2 = subset[j];
                    if (WorkTogether(p1, p2))
                    {
                        if (d.ContainsKey(p1))
                        {
                            d[p1].Add(p2);
                        }
                        else
                        {
                            d[p1] = new List<long> { p2 };
                        }
                    }
                }
            }

            d = d.Where(p => p.Value.Count > 1).ToDictionary(p => p.Key, p => p.Value);

            long smallest = long.MaxValue;
            long a, b, c;
            foreach (var prime in d.Keys)
            {
                for (int i = 0; i < d[prime].Count; i++)
                {
                    for (int j = i + 1; j < d[prime].Count; j++)
                    {
                        var p1 = d[prime][i];
                        var p2 = d[prime][j];
                        if (WorkTogether(p1, p2))
                        {
                            var sum = 3 + 7 + prime + p1 + p2;

                            if (sum < smallest)
                            {
                                smallest = sum;
                                a = prime;
                                b = p1;
                                c = p2;
                            }
                        }
                    }
                }
            }

            return smallest;
        }

        private bool WorkTogether(long number, long anotherNumber)
        {
            return _sieve.IsPrime(number.Concat(anotherNumber)) &&
                   _sieve.IsPrime(anotherNumber.Concat(number));
        }
    }
}
