using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PlayGroundWebApp.Utilities;

namespace PlayGroundWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger _logger;
        private readonly IMessageLogger _message;

        public IndexModel(ILogger<IndexModel> logger , IMessageLogger message)
        {
            _logger = logger;
            _message = message;
        }

        public void OnGet()
        {
            System.Diagnostics.Trace.TraceInformation("Trace Information test");
            _logger.LogInformation("IndexModel OnGet Method!");
            _logger.LogError("Error Test");

            _message.Write("IndexModel OnGet Method");
        }
    }
}