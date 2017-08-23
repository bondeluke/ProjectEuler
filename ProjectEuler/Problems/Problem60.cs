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
        public long Benchmark => 800;

        private Dictionary<long, List<long>> _buddyLookup;

        private PrimeSieve _sieve;

        public object Solve()
        {
            var limit = 8389; // The greatest prime in the answer
            //var limit = 10.Power(4);
            _sieve = new PrimeSieve();

            var attempt = LookForSolution(limit, 1);

            return attempt > 0 
                ? attempt 
                : LookForSolution(limit, 2);
        }

        private long LookForSolution(int limit, int mod)
        {
            var primes = _sieve.GetPrimes().Where(p => p % 3 == mod && p <= limit).ToArray();

            _buddyLookup = CreateBuddyLookup(primes);

            foreach (var rootPrime in _buddyLookup)
            {
                foreach (var friend in rootPrime.Value)
                {
                    var intersection = rootPrime.Value.Intersect(_buddyLookup[friend]).ToArray();
                    if (intersection.Length < 3) continue;

                    long result = 0;

                    intersection.IjFor((i, j) =>
                    {
                        var p1 = intersection[i];
                        var p2 = intersection[j];
                        if (!AreBuddies(p1, p2)) return;

                        for (var k = j + 1; k < intersection.Length; k++)
                        {
                            var p3 = intersection[k];

                            if (AreBuddies(p1, p3) && AreBuddies(p2, p3))
                            {
                                result = rootPrime.Key + friend + p1 + p2 + p3;
                            }
                        }
                    });

                    if (result > 0)
                        return result;
                }
            }

            _buddyLookup = null;

            return 0;
        }

        public bool AreBuddies(long number, long anotherNumber)
        {
            if (_buddyLookup != null)
            {
                return _buddyLookup[number].Contains(anotherNumber) &&
                    _buddyLookup[anotherNumber].Contains(number);
            }

            return number.Concat(anotherNumber).IsPrime(_sieve) &&
                   anotherNumber.Concat(number).IsPrime(_sieve);
        }

        private Dictionary<long, List<long>> CreateBuddyLookup(long[] primes)
        {
            var d = new Dictionary<long, List<long>>();

            primes.IjForEach((p1, p2) =>
            {
                if (!AreBuddies(p1, p2)) return;

                d.AddSafe(p1, p2);
                d.AddSafe(p2, p1);
            });

            return d;
        }
    }
}
