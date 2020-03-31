using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface IBooksService
    {
        /// <summary>
        /// 获取书籍
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="bookName"></param>
        /// <param name="authorName"></param>
        /// <returns></returns>
        Task<IEnumerable<Qian.Shop.Core.Models.Books>> GetBooks(int pageIndex, int pageSize, string bookName, string authorName,string bookType,int orderBy,bool isAsc);

        /// <summary>
        /// 获取具体书籍的详情信息
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        Task<Qian.Shop.Core.Models.Books> GetBookById(int bookId);
    }
}
