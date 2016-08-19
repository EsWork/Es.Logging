using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Logging;


namespace Sample
{
    public class LoggerManagerDemo
    {
        ILogger _logger = LoggerManager.GetLogger("LoggerManagerDemo");

        [Demo]
        public void Aggregate_And_AppendProvider() {

            //def console
            LoggerManager.Factory.AddConsole(LogLevel.Trace);

            _logger.Info("------- console -------");

            var config = new NLog.Config.LoggingConfiguration();

            var consoleTarget = new NLog.Targets.ColoredConsoleTarget();
            config.AddTarget("console", consoleTarget);

            var rule1 = new NLog.Config.LoggingRule("*", NLog.LogLevel.Trace, consoleTarget);
            config.LoggingRules.Add(rule1);

            var factory = new NLog.LogFactory(config);

            //append NLog
            LoggerManager.Factory.AddNLog(factory);

            _logger.Info("------- console & nlog -------");
        }
    }
}
