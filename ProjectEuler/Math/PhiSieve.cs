namespace ProjectEuler.Math
{
    public class PhiSieve
    {
        public PhiSieve(long size)
        {
            size += 1;
            _phi = new long[size];

            foreach (var number in Integer.Range(0, size))
            {
                _phi[number] = number;
            }

            foreach (var number in Integer.Range(2, size))
            {
                if (_phi[number] != number) continue;

                // If number is prime, "cross out" multiples
                foreach (var mulitple in Integer.Range(number, size, number))
                {
                    var frac = 1 - Fraction.New(1, number);

                    _phi[mulitple] = _phi[mulitple] * frac.Numerator / frac.Denominator;
                }
            }
        }

        private readonly long[] _phi;

        public long Phi(long number) => _phi[number];
    }
}