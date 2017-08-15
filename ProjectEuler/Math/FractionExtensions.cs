namespace ProjectEuler.Math
{
    public static class FractionExtensions
    {
        public static Fraction Reduce(this Fraction fraction)
        {
            var gcd = Algebra.Gcd(fraction.Numerator, fraction.Denominator);

            return new Fraction(fraction.Numerator / gcd, fraction.Denominator / gcd);
        }

        public static Fraction Scale(this Fraction fraction, long scalar) => new Fraction(fraction.Numerator * scalar, fraction.Denominator * scalar);

        public static long ToWhole(this Fraction fraction) => fraction.Numerator / fraction.Denominator;
    }
}