using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Logging
{
    public interface ILoggerFactory
    {
        ILogger CreateLogger(string name);

        void AddProvider(ILoggerProvider[] providers);
    }
}
