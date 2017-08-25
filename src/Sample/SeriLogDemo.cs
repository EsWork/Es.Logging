using System;
using System.Collections.Generic;
using System.Text;
using Es.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace Sample
{
    public class LoggerEnricher : ILogEventEnricher
    {
        public const string LoggerPropertyName = "Logger";

        /// <summary>
        /// Enrich the log event.
        /// </summary>
        /// <param name="logEvent">The log event to enrich.</param>
        /// <param name="propertyFactory">Factory for creating new properties to add to the event.</param>
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var loggerName = "Default";

            LogEventPropertyValue sourceContext;
            if (logEvent.Properties.TryGetValue(Constants.SourceContextPropertyName, out sourceContext))
            {
                var sv = sourceContext as ScalarValue;
                if (sv != null && sv.Value is string)
                {
                    loggerName = (string)sv.Value;
                }
            }

            logEvent.AddPropertyIfAbsent(new LogEventProperty(LoggerPropertyName, new ScalarValue(loggerName)));
        }
    }

    class SeriLogDemo
    {
        private readonly LoggerFactory _logFactory;

        public SeriLogDemo()
        {
            _logFactory = new LoggerFactory();

            const string DefaultOutputTemplate = "[{Timestamp:yyyy-MM-dd HH:mm:ss zzz}] {Logger} {Level:w} {Message:l}{NewLine}{Exception}";

            Log.Logger = new LoggerConfiguration()
                .Enrich.With<LoggerEnricher>()
                .WriteTo.Console(
                  outputTemplate: DefaultOutputTemplate,
                  formatProvider: null,
                  standardErrorFromLevel: null,
                  theme: SystemConsoleTheme.Literate,
                  restrictedToMinimumLevel: LogEventLevel.Verbose)
                  .MinimumLevel.Verbose()
                  .CreateLogger();

            _logFactory.AddSerilog(Log.Logger);
        }

        [Demo]
        public void WriteLog()
        {
            var log = _logFactory.CreateLogger<SeriLogDemo>();

            log.Trace("Trace....");
            log.Debug("Verbose...");
            log.Info("Information....");
            log.Error("Error...");
            log.Warn("Warning...");
            log.Fatal("Fatal...");

            var exception = new InvalidOperationException("Invalid value");

            log.Error(exception);

            int a = 10, b = 0;
            try
            {
                Log.Logger.Debug("Dividing {A} by {B}", a, b);
                Console.WriteLine(a / b);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }
    }
}
