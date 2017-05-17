using MS = Microsoft.Extensions.Logging;

namespace Es.Logging
{
    public class LoggerProvider : ILoggerProvider
    {
        private readonly MS.ILoggerFactory _logFactory;

        public LoggerProvider(MS.ILoggerFactory logFactory)
        {
            _logFactory = logFactory;
        }

        public ILogger CreateLogger(string name)
        {
            return new Logger(_logFactory.CreateLogger(name));
        }

        public void Dispose()
        {
        }
    }
}