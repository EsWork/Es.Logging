using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Es.Logging
{
    public class NLogLoggerProvider : ILoggerProvider
    {
        private readonly LogFactory _factory;
        private bool _disposed = false;

        public NLogLoggerProvider(LogFactory logFactory) {
            _factory = logFactory;
        }

        public ILogger CreateLogger(string name) {
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
