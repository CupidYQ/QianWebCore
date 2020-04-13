using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Qian.Shop.Api.Utility;

namespace Qian.Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBLL.IBooksService _ibooksService;
        
        public BooksController(IBLL.IBooksService booksService)
        {
            _ibooksService = booksService;                  
        }

        [HttpGet("GetBooks")]
        //[TypeFilter(typeof(CustomActionFilterAttribute))] //不需要在IOC中注册服务
        [ServiceFilter(typeof(CustomActionFilterAttribute))] //需要在IOC中注册服务
        public async Task<IActionResult> GetBooks(int pageIndex, int pageSize, string bookName, string authorName,string bookType,int orderBy,bool isAsc)
        {            
            var model = await _ibooksService.GetBooks(pageIndex, pageSize,bookName, authorName, bookType,orderBy,isAsc);            
            return Ok(Common.ApiResult.Successed(model,model.Count()));
        }

        [HttpGet("GetBookById")]
        public async Task<IActionResult> GetBookById(int bookId)
        {
            var model = await _ibooksService.GetBookById(bookId);
            var res = new
            {
                code = 0,
                data = model
            };
            return Ok(res);               
        }

        [HttpGet("Test")]
        public ActionResult Test()
        {
            int i = 1;
            int k = 3;
            int m = i + k;//业务逻辑
            int l = m - m;
            int j = m / l;//其实是要来个异常
            var res = new
            {
                result = j
            };
            return Ok(res);
        }
    }
}