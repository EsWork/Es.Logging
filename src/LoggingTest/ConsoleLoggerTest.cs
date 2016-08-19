using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Logging;
using Xunit;

namespace LoggingTest
{
    public class ConsoleLoggerTest
    {
        [Fact]
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
    }
}
