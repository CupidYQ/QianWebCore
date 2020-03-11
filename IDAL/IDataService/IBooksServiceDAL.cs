using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDAL.IDataService
{
    public interface IBooksServiceDAL
    {
        Task<IEnumerable<Qian.Shop.Core.Models.Books>> GetBooks(int pageIndex, int pageSize, string bookName, string authorName, string bookType, int orderBy, bool     );

        Task<Qian.Shop.Core.Models.Books> GetBookById(int bookId);
    }
}
