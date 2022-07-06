using Books.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Service.Common
{
    public interface IBookService
    {
        Task<List<Books.Model.Models.Book>> GetAllAsync(Paging page, Sorting sort, Filtering filter);
        Task<Books.Model.Models.Book> GetAsync(Guid id);
        Task<Books.Model.Models.Book> PostAsync(Books.Model.Models.Book book);
        Task<Books.Model.Models.Book> PutAsync(System.Guid id, Books.Model.Models.Book book);
        Task<bool> DeleteAsync(System.Guid id);
    }
}
