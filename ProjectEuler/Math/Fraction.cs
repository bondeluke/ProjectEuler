using System;

namespace ProjectEuler.Math
{
    public struct Fraction : IEquatable<Fraction>
    {
        public Fraction(long numerator, long denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public long Numerator { get; }
        public long Denominator { get; }
        public bool IsReduced => Numerator.IsCoPrimeWith(Denominator);

        public static Fraction New(long numerator, long denominator) => new Fraction(numerator, denominator);

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public static Fraction operator +(Fraction left, Fraction right)
        {
            if (left.Denominator == right.Denominator)
                return New(left.Numerator + right.Numerator, left.Denominator);

            var lcm = Algebra.Lcm(left.Denominator, right.Denominator);

            return left.Scale(lcm / left.Denominator) + right.Scale(lcm / right.Denominator);
        }

        public static Fraction operator -(Fraction left, Fraction right)
        {
            return left + -1 * right;
        }

        public static Fraction operator +(long left, Fraction right)
        {
            return New(left, 1) + right;
        }

        public static Fraction operator -(long left, Fraction right)
        {
            return New(left, 1) - right;
        }

        public static Fraction operator *(long scalar, Fraction right)
        {
            return New(right.Numerator * scalar, right.Denominator);
        }

        public static Fraction operator *(Fraction left, Fraction right)
        {
            return New(left.Numerator * right.Numerator, left.Denominator * right.Denominator);
        }

        public bool Equals(Fraction other)
        {
            if (!IsReduced || !other.IsReduced)
            {
                return Equals(this.Reduce(), other.Reduce());
            }

            return Numerator == other.Numerator && Denominator == other.Denominator;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Fraction && Equals((Fraction)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Numerator.GetHashCode() * 397) ^ Denominator.GetHashCode();
            }
        }
    }
}
