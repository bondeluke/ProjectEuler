namespace ProjectEuler.Helpers
{
    public class OutputWriter
    {
        private readonly IReadOnlyLog _readOnlyLog;

        public OutputWriter(IReadOnlyLog readOnlyLog)
        {
            _readOnlyLog = readOnlyLog;
        }

        public string GetOutput(string name, object solution, long milliseconds)
        {
            var output = $"{name}\r\nSolution: {solution}\r\nTime elapsed: {milliseconds} millisecond(s)";

            return _readOnlyLog.HasContent()
                ? $"{_readOnlyLog.GetLog()}\r\n{output}"
                : output;
        }
    }
}