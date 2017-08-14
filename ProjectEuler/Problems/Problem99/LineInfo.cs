namespace ProjectEuler.Problems.Problem99
{
    class LineInfo
    {
        public LineInfo(int lineNumber, int @base, int exponent)
        {
            LineNumber = lineNumber;
            Base = @base;
            Exponent = exponent;
        }

        public int LineNumber { get; }
        public int Base { get; }
        public int Exponent { get; }

        public override string ToString()
        {
            return $"{LineNumber}: {Base}^{Exponent}";
        }
    }
}
