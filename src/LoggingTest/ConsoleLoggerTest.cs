using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Logging;
using NUnit.Framework;

namespace LoggingTest
{
    public class ConsoleLoggerTest
    {
        [Test]
        public void Create_ConsoleProvider_With_Level() {
            var provider = new ConsoleLoggerProvider(LogLevel.Debug);

            var logger = provider.CreateLogger(this.GetType().FullName);

            Assert.False(logger.IsEnabled(LogLevel.Trace));

            Assert.True(logger.IsEnabled(LogLevel.Debug));
            Assert.True(logger.IsEnabled(LogLevel.Info));
            Assert.True(logger.IsEnabled(LogLevel.Warn));
            Assert.True(logger.IsEnabled(LogLevel.Error));
            Assert.True(logger.IsEnabled(LogLevel.Fatal));
        }

        [Test]
        public void Can_Console_WritesException() {
            var logger = new ConsoleLogger(this.GetType().FullName, LogLevel.Debug);

            var exception = new InvalidOperationException("Invalid value");

            StringBuilder sb = new StringBuilder();

            var bakOut = Console.Error;

            using (var tw = new StringWriter(sb)) {

                Console.SetError(tw);

                logger.Log(LogLevel.Error, null, exception);
            }

            Assert.AreEqual("error:[LoggingTest.ConsoleLoggerTest] System.InvalidOperationException: Invalid value\r\n", sb.ToString());

            Console.SetOut(bakOut);
        }
    }
}
