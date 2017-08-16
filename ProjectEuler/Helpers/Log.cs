using System;

namespace ProjectEuler.Helpers
{
    public class Log : IWriteOnlyLog, IReadOnlyLog
    {
        private bool _hasContent;
        private string _log;

        public Log()
        {
            _log = string.Empty;
            _hasContent = false;
        }

        public bool HasContent() => _hasContent;

        public string GetLog() => _log;

        public void WriteLine(object line)
        {
            _log += line + Environment.NewLine;
            _hasContent = true;
        }
    }

    public interface IWriteOnlyLog
    {
        void WriteLine(object line);
    }

    public interface IReadOnlyLog
    {
        bool HasContent();
        string GetLog();
    }
}