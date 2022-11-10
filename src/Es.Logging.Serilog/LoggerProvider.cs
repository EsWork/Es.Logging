using Serilog;
using Serilog.Core;
using System;

namespace Es.Logging
{
    /// <summary>
    ///  Provider logger for Serilog.
    /// </summary>
    public class LoggerProvider : ILoggerProvider
    {
        private readonly Serilog.ILogger _logger;
        private readonly Action _dispose;

        /// <summary>
        /// <see cref="LoggerProvider"/> with default ILogger.
        /// </summary>
        /// <param name="logger"><see cref="Serilog.ILogger"/></param>
        public LoggerProvider(Serilog.ILogger logger)
        {
            _logger = logger;

            if (logger != null)
                _dispose = () => (logger as IDisposable)?.Dispose();
            else
                _dispose = Log.CloseAndFlush;
        }

        /// <summary>
        /// Create a logger with the name <paramref name="name"/>.
        /// </summary>
        /// <param name="name">Name of the logger to be created.</param>
        /// <returns>New Logger</returns>
        public ILogger CreateLogger(string name)
        {
            return new Logger(_logger.ForContext(Constants.SourceContextPropertyName, name));
        }

        /// <summary>
        ///  Clean
        /// </summary>
        public void Dispose()
        {
            _dispose?.Invoke();
        }
    }
}