using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Es.Logging
{
    public static class Log4Extensions
    {
        public static ILoggerFactory AddLog4net(this ILoggerFactory factory) {
            factory.AddProvider(new Log4LoggerProvider());
            return factory;
        }
    }
}
