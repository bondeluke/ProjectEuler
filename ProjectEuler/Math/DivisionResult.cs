namespace ProjectEuler.Math
{
    public class DivisionResult
    {
        public DivisionResult(long quotient, long remainder)
        {
            Quotient = quotient;
            Remainder = remainder;
        }

        public long Quotient { get; }
        public long Remainder { get; }
    }
}
