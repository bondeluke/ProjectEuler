using System;

namespace ProjectEuler
{
    public class Logger: ILogWritable, ILogReadable
    {
        private string _log;
        private bool _hasContent;

        public Logger()
        {
            _log = string.Empty;
            _hasContent = false;
        }

        public void WriteLine(object line)
        {
            _log += line + Environment.NewLine;
            _hasContent = true;
        }

        public bool HasContent() => _hasContent;

        public string GetLog() => _log;
    }

    public interface ILogWritable
    {
        void WriteLine(object line);
    }

    public interface ILogReadable
    {
        bool HasContent();
        string GetLog();
    }
}