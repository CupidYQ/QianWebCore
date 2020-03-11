using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IDAL.IDataService;
using Qian.Shop.Core;
using Qian.Shop.Core.Models;
using Common;

namespace DAL.DataService
{
    public class BooksServiceDAL : DALService<Books>, IBooksServiceDAL
    {
        public BooksServiceDAL(QianContext context) : base(context)
        {

        }

        public Task<Books> GetBookById(int bookId)
        {
            return Task.Run(() => LoadEntites(p => p.BookId == bookId).FirstOrDefault());
        }

        public async Task<IEnumerable<Books>> GetBooks(int pageIndex, int pageSize, string bookName, string authorName,string bookType, int orderBy, bool isAsc)
        {
            
            return await Task.Run(() =>
            {
                var predicate = DynamicLinqExpressions.True<Books>().And(p => p.BookState == true);                
                if (!string.IsNullOrEmpty(bookType))
                {
                    predicate = predicate.And(p => p.BookType == bookType);
                }
                if (!string.IsNullOrEmpty(bookName))
                {
                    predicate = predicate.And(p => p.BookName.Contains(bookName));
                }
                if (!string.IsNullOrEmpty(authorName))
                {
                    predicate = predicate.And(p => p.AuthorsName.Contains(authorName));
                }
                List<Qian.Models.OrderModelField> orderModelField = new List<Qian.Models.OrderModelField>();
                switch (orderBy)
                {
                    case 0:
                        orderModelField.Add(new Qian.Models.OrderModelField { propertyName = "AddTime", isAsc = false });
                        break;
                    case 1:
                        orderModelField.AddRange
                        (
                            new List<Qian.Models.OrderModelField>
                            {
                                new Qian.Models.OrderModelField { propertyName = "MarketPrice", isAsc = isAsc },
                                new Qian.Models.OrderModelField { propertyName = "AddTime", isAsc = false }
                            }
                         );
                        break;
                    default:
                        break;
                }
                var model = LoadEntites(predicate).ExpressionOrderBy(orderModelField.ToArray()).Skip((pageIndex - 1)*pageSize).Take(pageSize);
                return model.AsEnumerable();
            });
        }
    }
}
