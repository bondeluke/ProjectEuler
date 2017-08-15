using System;

namespace ProjectEuler.Math
{
    public struct Fraction : IEquatable<Fraction>
    {
        public Fraction(long numerator, long denominator)
        {
            if (denominator == 0)
                throw new Exception("Denominator cannot be zero");

            if (denominator < 0)
            {
                numerator *= -1;
                denominator *= -1;
            }

            Numerator = numerator;
            Denominator = denominator;
        }

        public long Numerator { get; }
        public long Denominator { get; }
        public bool IsReduced => Algebra.AreCoprime(Numerator, Denominator);
        public bool IsWhole => Denominator.Divides(Numerator);

        public static Fraction New(long numerator, long denominator) => new Fraction(numerator, denominator);

        public override string ToString() => IsWhole ? (Numerator/Denominator).ToString() : $"{Numerator}/{Denominator}";

        public static implicit operator Fraction(long number) => number.ToFraction();

        public static Fraction operator +(Fraction left, Fraction right) => New(left.Numerator * right.Denominator + left.Denominator * right.Numerator, left.Denominator * right.Denominator);

        public static Fraction operator -(Fraction left, Fraction right) => left + -1 * right;

        public static Fraction operator +(long left, Fraction right) => New(left, 1) + right;

        public static Fraction operator +(Fraction left, long right) => right + left;

        public static Fraction operator -(long left, Fraction right) => left + -1 * right;

        public static Fraction operator -(Fraction left, long right) => left + -1 * right;

        public static Fraction operator *(long scalar, Fraction right) => New(right.Numerator * scalar, right.Denominator);

        public static Fraction operator *(Fraction left, long scalar) => scalar * left;

        public static Fraction operator /(long scalar, Fraction right) => scalar * right.Invert();

        public static Fraction operator /(Fraction left, long scalar) => New(left.Numerator, left.Denominator * scalar);

        public static Fraction operator *(Fraction left, Fraction right) => New(left.Numerator * right.Numerator, left.Denominator * right.Denominator);

        public static Fraction operator /(Fraction left, Fraction right) => left * right.Invert();

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
            return obj is Fraction && Equals((Fraction) obj);
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