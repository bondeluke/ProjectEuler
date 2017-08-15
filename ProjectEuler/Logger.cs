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

        public void WriteLine(string line)
        {
            _log += line + Environment.NewLine;
            _hasContent = true;
        }

        public bool HasContent()
        {
            return _hasContent;
        }

        public string GetLog()
        {
            return _log;
        }
    }

    public interface ILogWritable
    {
        void WriteLine(string line);
    }

    public interface ILogReadable
    {
        bool HasContent();
        string GetLog();
    }
}