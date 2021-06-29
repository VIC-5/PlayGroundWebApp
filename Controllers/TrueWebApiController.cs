using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PlayGroundWebApp.Models;
using PlayGroundWebApp.Utilities;

namespace PlayGroundWebApp.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class TrueWebApiController : ControllerBase
    {
        private readonly IViewRenderService _viewRenderService;

        public TrueWebApiController(IViewRenderService viewRenderService)
        {
            _viewRenderService = viewRenderService;
        }

        public async Task<IActionResult> GetUser()
        {
            var viewStr = await _viewRenderService.RenderToString("TrueWebApi/User", "Great!");

            return Ok(viewStr);

            throw new NotImplementedException();
        }

        public class ReturnedValue
        {
            public string Test1 { get; set; }
            public string Test2 { get; set; }
        }

        public async Task<IActionResult> GetText(ReturnedValue test)
        {
            var test1str = test.Test1;
            var test2str = test.Test2;
            //var viewStr = await _viewRenderService.RenderToString("/Controllers/Views/User.cshtml", test1str);
            var viewStr = await _viewRenderService.RenderToString("TrueWebApi/User", test1str);

            return Ok(viewStr);
        }

        public class GetUserInfoParams
        {
            public int Id { get; set; }
            public bool Enable { get; set; }
        }

        public async Task<IActionResult> GetUserInfo(GetUserInfoParams param)
        {
            var userInfo = new UserInfo
            {
                Name = "test john",
                Age = 34
            };

            var viewStr = await _viewRenderService.RenderToString("TrueWebApi/UserInfo", userInfo);

            return Ok(viewStr);
        }
    }
}