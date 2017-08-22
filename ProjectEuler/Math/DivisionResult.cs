namespace ProjectEuler.Math
{
    public class DivisionResult<T>
    {
        public DivisionResult(T quotient, T remainder)
        {
            Quotient = quotient;
            Remainder = remainder;
        }

        public T Quotient { get; }
        public T Remainder { get; }
    }
}