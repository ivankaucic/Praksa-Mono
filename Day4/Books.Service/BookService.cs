using Book.Service.Common;
using Books.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Books.Service
{
    public class BookService : IBookService
    {
       public List<Books.Model.Models.Book> GetAll()
        {
            var bookRepository = new BookRepository();
            return bookRepository.GetAll();
        }

       public Books.Model.Models.Book Get(Guid id)
        {
            var bookRepository = new BookRepository();
            return bookRepository.Get(id);
        }

        public Books.Model.Models.Book Post(Books.Model.Models.Book book)
        {
            var bookRepository = new BookRepository();
            return bookRepository.Post(book);
        }

        public Books.Model.Models.Book Put(System.Guid id, Books.Model.Models.Book book)
        {
            var bookRepository = new BookRepository();
            return bookRepository.Put(id, book);
        }

        public bool Delete(System.Guid id)
        {
            var bookRepository = new BookRepository();
            return bookRepository.Delete(id);
        }

    }
}
