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
       public async Task<List<Books.Model.Models.Book>> GetAllAsync()
        {
            var bookRepository = new BookRepository();
            return await bookRepository.GetAllAsync();
        }

       public async Task<Books.Model.Models.Book> GetAsync(Guid id)
        {
            var bookRepository = new BookRepository();
            return await bookRepository.GetAsync(id);
        }

        public async Task<Books.Model.Models.Book> PostAsync(Books.Model.Models.Book book)
        {
            var bookRepository = new BookRepository();
            return await bookRepository.PostAsync(book);
        }

        public async Task<Books.Model.Models.Book> PutAsync(System.Guid id, Books.Model.Models.Book book)
        {
            var bookRepository = new BookRepository();
            return await bookRepository.PutAsync(id, book);
        }

        public async Task<bool> DeleteAsync(System.Guid id)
        {
            var bookRepository = new BookRepository();
            return await bookRepository.DeleteAsync(id);
        }

    }
}
