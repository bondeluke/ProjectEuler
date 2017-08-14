namespace ProjectEuler.Math
{
    public static class PhiExtensions
    {
        public static long Phi(this long number)
        {
            return _sieve.Phi(number);
        }

        private static readonly PhiSieve _sieve = new PhiSieve(1000000);
    }
}
