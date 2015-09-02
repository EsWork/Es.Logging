using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Logging;
using Es.Logging.Console;
using NUnit.Framework;

namespace LoggingTest
{
    public class LoggerTest
    {
        [Test]
        public void Can_AddProvider_Create_Logger() {
            ILoggerFactory factory = new LoggerFactory();

            var provicer1 = new ConsoleLoggerProvider(LogLevel.Error);
            var provicer2 = new ConsoleLoggerProvider(LogLevel.Debug);

            factory.AddProvider(new[] { provicer1, provicer2 });

            var logger = factory.CreateLogger(this.GetType().Name);

            Assert.True(logger.IsEnabled(LogLevel.Debug));
        }

        [Test]
        public void Can_Create_Logger_And_Append_Provider_() {
            ILoggerFactory factory = new LoggerFactory();

            var provicer1 = new ConsoleLoggerProvider(LogLevel.Error);

            factory.AddProvider(provicer1);

            var logger = factory.CreateLogger<LoggerTest>();

            Assert.False(logger.IsEnabled(LogLevel.Debug));

            var provicer2 = new ConsoleLoggerProvider(LogLevel.Debug);

            //append provider
            factory.AddProvider(provicer2);

            Assert.True(logger.IsEnabled(LogLevel.Debug));
        }
    }
}
