using Common;
using IBLL;
using IDAL;
using Qian.Shop.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Logic
{
    public class BooksServiceBLL : IBooksService
    {
        private IDAL.IDataService.IBooksServiceDAL _dalService;
        public BooksServiceBLL(IDAL.IDataService.IBooksServiceDAL dalService)
        {
            this._dalService = dalService;
        }

        public async Task<Books> GetBookById(int bookId)
        {
            return await _dalService.GetBookById(bookId);
        }

        public async Task<IEnumerable<Books>> GetBooks(int pageIndex, int pageSize, string bookName, string authorName, string bookType, int orderBy = 0, bool isAsc = true)
        {
            return await _dalService.GetBooks(pageIndex, pageSize, bookName, authorName, bookType, orderBy, isAsc);            
        }
    }
}
