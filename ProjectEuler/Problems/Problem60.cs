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
        public object ExpectedSolution => 26033;
        public long Benchmark => 25038;

        public Problem60()
        {
            PrimeExtensions.PreLoadSieve();
        }

        // On my first go, I got 423841 as my sum. That was wrong, but gives me an upper limit to work with.
        public object Solve()
        {
            var primes = new PrimeSieve(10.Power(4)).Primes;

            var groups = new List<FriendlyPrimes>();

            for (var i = 0; i < primes.Length; i++)
            {
                for (var j = i + 1; j < primes.Length; j++)
                {
                    if (!WorkTogether(primes[i], primes[j])) continue;
                    for (var k = j + 1; k < primes.Length; k++)
                    {
                        if (!WorkTogether(primes[i], primes[k]) || !WorkTogether(primes[j], primes[k])) continue;
                        for (var m = k + 1; m < primes.Length; m++)
                        {
                            if (WorkTogether(primes[i], primes[m]) && WorkTogether(primes[j], primes[m]) && WorkTogether(primes[k], primes[m]))
                            {
                                groups.Add(new FriendlyPrimes(new[]
                                {
                                    primes[i], primes[j], primes[k], primes[m]
                                }));
                            }
                        }
                    }
                }
            }

            foreach (var prime in primes)
            {
                foreach (var group in groups)
                {
                    if (group.IsFriendlyWith(prime))
                    {
                        return group.Sum + prime;
                    }
                }
            }

            return 0;
        }

        public static bool WorkTogether(long number, long anotherNumber)
        {
            return number.Concat(anotherNumber).IsPrime() &&
                   anotherNumber.Concat(number).IsPrime();
        }

        private Dictionary<long, List<long>> PopulateDict(long[] primes)
        {
            var d = new Dictionary<long, List<long>>();

            for (var i = 0; i < primes.Length; i++)
            {
                for (var j = i + 1; j < primes.Length; j++)
                {
                    var p1 = primes[i];
                    var p2 = primes[j];
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
                        if (d.ContainsKey(p2))
                        {
                            d[p2].Add(p1);
                        }
                        else
                        {
                            d[p2] = new List<long> { p1 };
                        }
                    }
                }
            }
            return d;
        }
    }

    public class FriendlyPrimes
    {
        private readonly long[] _primes;

        public FriendlyPrimes(long[] primes)
        {
            _primes = primes;
        }

        public override string ToString()
        {
            return _primes.OrderBy(p => p).StringJoin();
        }

        public long Id => _primes.Product();

        public bool IsFriendlyWith(long candidate)
        {
            return _primes.All(p => p == candidate || Problem60.WorkTogether(p, candidate));
        }

        public bool IsFriendlyWith(FriendlyPrimes group) => _primes.All(IsFriendlyWith);

        public FriendlyPrimes Merge(FriendlyPrimes group) => new FriendlyPrimes(_primes.Concat(group._primes).ToArray());

        public long Sum => _primes.Sum();
    }
}
