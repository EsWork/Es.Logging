using NLog;

namespace Es.Logging
{
    public class NLogLoggerProvider : ILoggerProvider
    {
        private readonly LogFactory _factory;
        private bool _disposed = false;

        public NLogLoggerProvider() {
        }

        public NLogLoggerProvider(LogFactory logFactory) {
            _factory = logFactory;
        }

        public ILogger CreateLogger(string name) {
            if(_factory == null) {
                //usage XmlLoggingConfiguration
                //e.g LogManager.Configuration = new XmlLoggingConfiguration(fileName, true);
                return new Logger(LogManager.GetLogger(name));
            }
            return new Logger(_factory.GetLogger(name));
        }

        public void Dispose() {
            if (!_disposed) {
                _factory.Flush();
                _factory.Dispose();
                _disposed = true;
            }
        }
    }
}