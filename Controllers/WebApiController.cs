using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PlayGroundWebApp.Controllers
{
    public class WebApiController : Controller
    {
        public IActionResult GetUser()
        {

            return View("User");
        }
    }
}
