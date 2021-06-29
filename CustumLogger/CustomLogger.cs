using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace PlayGroundWebApp.CustumLogger
{
    public class CustomLogger : ILogger
    {
        public CustomLogger()
        { }

        public IDisposable BeginScope<TState>(TState state)
        {
            return default;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel != LogLevel.None;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            Console.WriteLine("** Custom Logger begin **");
            Console.WriteLine(formatter(state, exception));
            Console.WriteLine("** Custom Logger end **");
        }
    }
}
