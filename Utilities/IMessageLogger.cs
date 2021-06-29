using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayGroundWebApp.Utilities
{
    public interface IMessageLogger
    {
        public void Write(string message);
    }
}