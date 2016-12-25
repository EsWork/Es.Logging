using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Es.Logging;

namespace LoggingTest
{
    public class StaticLogger
    {
        private static ILogger _logger = LoggerManager.GetLogger<StaticLogger>();

        public bool IsEnabled(LogLevel logLevel) {
            return _logger.IsEnabled(logLevel);
        }
    }
}
