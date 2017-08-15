namespace ProjectEuler
{
    public class OutputWriter
    {
        private readonly ILogReadable _log;

        public OutputWriter(ILogReadable log)
        {
            _log = log;
        }

        public string GetOutput(object solution, long milliseconds)
        {
            var output = $"Solution: {solution}.\r\nTime elapsed: {milliseconds} millisecond(s).";

            return _log.HasContent()
                ? $"{_log.GetLog()}\r\n{output}"
                : output;
        }
    }
}