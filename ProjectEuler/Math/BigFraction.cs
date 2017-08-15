using System;
using System.Numerics;

namespace ProjectEuler.Math
{
    public struct BigFraction : IEquatable<BigFraction>
    {
        public BigFraction(BigInteger numerator, BigInteger denominator)
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

        public BigInteger Numerator { get; }
        public BigInteger Denominator { get; }
        public bool IsReduced => Algebra.AreCoprime(Numerator, Denominator);
        public bool IsWhole => Numerator % Denominator == 0;

        public static BigFraction New(BigInteger numerator, BigInteger denominator) => new BigFraction(numerator, denominator);

        public override string ToString() => IsWhole ? (Numerator / Denominator).ToString() : $"{Numerator}/{Denominator}";

        public static implicit operator BigFraction(BigInteger number) => number.ToBigFraction();

        public static BigFraction operator +(BigFraction left, BigFraction right) => New(left.Numerator * right.Denominator + left.Denominator * right.Numerator, left.Denominator * right.Denominator);

        public static BigFraction operator -(BigFraction left, BigFraction right) => left + -1 * right;

        public static BigFraction operator +(BigInteger left, BigFraction right) => New(left, 1) + right;

        public static BigFraction operator +(BigFraction left, BigInteger right) => right + left;

        public static BigFraction operator -(BigInteger left, BigFraction right) => left + -1 * right;

        public static BigFraction operator -(BigFraction left, BigInteger right) => left + -1 * right;

        public static BigFraction operator *(BigInteger scalar, BigFraction right) => New(right.Numerator * scalar, right.Denominator);

        public static BigFraction operator *(BigFraction left, BigInteger scalar) => scalar * left;

        public static BigFraction operator /(BigInteger scalar, BigFraction right) => scalar * right.Invert();

        public static BigFraction operator /(BigFraction left, BigInteger scalar) => New(left.Numerator, left.Denominator * scalar);

        public static BigFraction operator *(BigFraction left, BigFraction right) => New(left.Numerator * right.Numerator, left.Denominator * right.Denominator);

        public static BigFraction operator /(BigFraction left, BigFraction right) => left * right.Invert();

        public bool Equals(BigFraction other)
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
            return obj is BigFraction && Equals((BigFraction)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Numerator.GetHashCode() * 397) ^ Denominator.GetHashCode();
            }
        }

        public static BigFraction Zero => New(0, 1);
    }
}