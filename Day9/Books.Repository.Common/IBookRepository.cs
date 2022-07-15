using Books.Common;
using Books.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Repository.Common
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync(Paging page, Sorting sort, Filtering filter);
        Task<Book> GetAsync(Guid id);
        Task<Book> PostAsync(Book book);
        Task<Book> PutAsync(System.Guid id, Book book);
        Task<bool> DeleteAsync(System.Guid id);
    }
}
