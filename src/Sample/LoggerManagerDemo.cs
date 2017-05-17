using Es.Logging;

namespace Sample
{
    public class LoggerManagerDemo
    {
        private static ILogger _logger = LoggerFactory.GetLogger("LoggerManagerDemo");

        [Demo]
        public void Aggregate_And_AppendProvider()
        {
            //def console
            LoggerFactory.Factory.AddConsole(LogLevel.Trace);

            //print 1 line
            _logger.Info("------- console -------");

            var config = new NLog.Config.LoggingConfiguration();

            var consoleTarget = new NLog.Targets.ColoredConsoleTarget();
            config.AddTarget("console", consoleTarget);

            var rule1 = new NLog.Config.LoggingRule("*", NLog.LogLevel.Trace, consoleTarget);
            config.LoggingRules.Add(rule1);

            var factory = new NLog.LogFactory(config);

            //append NLog
            LoggerFactory.Factory.AddNLog(factory);

            //print 2 line
            _logger.Info("------- console & nlog -------");
        }
    }
}