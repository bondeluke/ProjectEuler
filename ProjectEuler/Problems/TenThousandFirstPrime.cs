namespace ProjectEuler.Problems
{
    class TenThousandFirstPrime : IProjectEulerProblem
    {
        public object Solve()
        {
            return new PrimeSieve().GetNthPrime(10001);
        }
    }
}
