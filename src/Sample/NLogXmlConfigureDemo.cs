using System;
using System.Threading;
using System.Threading.Tasks;
using Es.Logging;
using NLog;

namespace Sample
{
    public class NLogXmlConfigureDemo
    {
        private readonly LoggerFactory _logFactory;

        public NLogXmlConfigureDemo()
        {
            _logFactory = new LoggerFactory();

            string filename = "";
#if NETFULL
            filename = AppDomain.CurrentDomain.BaseDirectory + "NLog.xml";
#else
            filename = AppContext.BaseDirectory + "/NLog.xml";
#endif
            _logFactory.AddNLog(filename);
        }

        [Demo]
        public void WriteLog()
        {
            var log = _logFactory.CreateLogger("ConsoleDemo");

            log.Trace("Trace....");
            log.Debug("Verbose...");
            log.Info("Information....");
            log.Error("Error...");
            log.Warn("Warning...");
            log.Fatal("Fatal...");

            var exception = new InvalidOperationException("Invalid value");

            log.Error(exception);
        }

        [Demo]
        public void WriteLog2()
        {
            var log = _logFactory.CreateLogger("ConsoleDemo");
            var menu = new ManualResetEvent(false);
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