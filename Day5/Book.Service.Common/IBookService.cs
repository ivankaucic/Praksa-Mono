using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Service.Common
{
    public interface IBookService
    {
        List<Books.Model.Models.Book> GetAll();
        Books.Model.Models.Book Get(Guid id);
        Books.Model.Models.Book Post(Books.Model.Models.Book book);
        Books.Model.Models.Book Put(System.Guid id, Books.Model.Models.Book book);
        bool Delete(System.Guid id);
    }
}
