using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace PlayGroundWebApp.Utilities
{
    public class MessageLogger : IMessageLogger
    {
        private readonly ILogger _logger;

        public MessageLogger(ILogger<MessageLogger> logger)
        {
            _logger = logger;
        }

        public void Write(string message)
        {
            _logger.LogInformation(1000 , $"{message} by MessageLogger. (Information)");
            _logger.LogError(9999 , $"{message} by MessageLogger. (Error)");
        }
    }
}