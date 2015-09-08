using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Logging
{
    public static class ConsoleLoggerFactoryExtensions
    {
        public static ILoggerFactory AddConsole(this ILoggerFactory factory, LogLevel minLevel) {
            factory.AddProvider(new ConsoleLoggerProvider(minLevel));
            return factory;
        }
    }
}
