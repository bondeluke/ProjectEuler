namespace ProjectEuler.Problems
{
    class TenThousandFirstPrime : IProjectEulerProblem
    {
        public object Solve()
        {
            return new PrimeSequence().GetNthPrime(10001);
        }
    }
}
