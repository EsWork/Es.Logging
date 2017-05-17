using Es.Logging;

namespace LoggingTest
{
    public class StaticLogger
    {
        private static ILogger _logger = LoggerFactory.GetLogger<StaticLogger>();

        public bool IsEnabled(LogLevel logLevel)
        {
            return _logger.IsEnabled(logLevel);
        }
    }
}