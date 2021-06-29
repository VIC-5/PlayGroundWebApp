using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace PlayGroundWebApp.CustumLogger
{
    public class CustomLoggerProvider : ILoggerProvider
    {
        public CustomLoggerProvider() { }

        public ILogger CreateLogger(string categoryName)
        {
            return new CustomLogger();
        }

        public void Dispose() { }
    }
}