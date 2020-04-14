using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Qian.Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        public IActionResult GetAuthorizeData()
        {
            var name = base.HttpContext.AuthenticateAsync().Result.Principal.Claims.FirstOrDefault(p => p.Type.Equals("Name"))?.Value;

            return new JsonResult(new
            {
                Data = "已授权",
                Type = "GetAuthorizeData"
            });
        }
    }
}