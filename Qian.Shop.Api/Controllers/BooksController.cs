using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Qian.Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBLL.IBooksService _ibooksService;
        private readonly ILogger<BooksController> _logger; 
        public BooksController(IBLL.IBooksService booksService,ILogger<BooksController> logger)
        {
            _ibooksService = booksService;
            _logger = logger;
            _logger.LogInformation("BooksController 被构造。。。。。");
        }

        [HttpGet("GetBooks")]
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