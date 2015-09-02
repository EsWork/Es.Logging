using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Logging
{
    public static class LoggerFactoryExtensions
    {
        public static void AddProvider(this ILoggerFactory factory, ILoggerProvider provider) {
            factory.AddProvider(new[] { provider });
        }

        public static ILogger CreateLogger<T>(this ILoggerFactory factory) {
            return factory.CreateLogger(typeof(T).FullName);
        }
    }

}