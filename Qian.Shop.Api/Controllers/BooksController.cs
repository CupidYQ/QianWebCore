using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
    }
}