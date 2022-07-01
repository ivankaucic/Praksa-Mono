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
        List<Book> GetAll();
        Book Get(Guid id);
        Book Post(Book book);
        Book Put(System.Guid id, Book book);
        bool Delete(System.Guid id);
    }
}
