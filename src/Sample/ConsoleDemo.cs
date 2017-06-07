using System;
using System.Threading;
using System.Threading.Tasks;
using Es.Logging;

namespace Sample
{
    public class ConsoleDemo
    {
        private readonly LoggerFactory _logFactory;

        public ConsoleDemo()
        {
            _logFactory = new LoggerFactory();
            _logFactory.AddConsole(LogLevel.Trace, true);
        }

        [Demo]
        public void WriteLog()
        {
            var log = _logFactory.CreateLogger("ConsoleDemo");

            for (int i = 0; i < 100; i++)
            {
                log.Trace("Trace....");
                log.Debug("Debug...");
                log.Info("Information....");
                log.Error("Error...");
                log.Warn("Warning...");
                log.Fatal("Fatal...");


                var exception = new InvalidOperationException("Invalid value");

                log.Error(exception);
            }

            Thread.Sleep(2000);
        }


        [Demo]
        public void WriteLog2()
        {
            var log = _logFactory.CreateLogger("ConsoleDemo");
            var menu = new  ManualResetEvent(false);
            for (int i = 0; i < 1000; i++)
            {
                Task.Run(() => {
                    menu.WaitOne();
                    log.Trace("Trace....");
                    log.Debug("Debug...");
                    log.Info("Information....");
                    log.Error("Error...");
                    log.Warn("Warning...");
                    log.Fatal("Fatal...");

                    var exception = new InvalidOperationException("Invalid value");

                    log.Error(exception);
                });
            
               
            }

            menu.Set();

            Thread.Sleep(2000);
        }
    }
}