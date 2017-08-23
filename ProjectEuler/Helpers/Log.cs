using System.Text;

namespace ProjectEuler.Helpers
{
    public class Log : IWriteOnlyLog, IReadOnlyLog
    {
        private readonly StringBuilder _log;

        // Merely convenience
        public static Log Current { get; set; }

        public Log()
        {
            _log = new StringBuilder();
        }

        public string ReadAll() => _log.ToString();

        public void WriteLine(object line)
        {
            if (line != null)
            {
                _log.AppendLine(line.ToString());
            }
        }
    }

    public interface IWriteOnlyLog
    {
        void WriteLine(object line);
    }

    public interface IReadOnlyLog
    {
        string ReadAll();
    }
}