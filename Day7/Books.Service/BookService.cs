using Book.Service.Common;
using Books.Common;
using Books.Repository;
using Books.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Books.Service
{
    public class BookService : IBookService
    {

        protected IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            this._repository = repository;
        }

       public async Task<List<Books.Model.Models.Book>> GetAllAsync(Paging page, Sorting sort, Filtering filter)
        {
            return await _repository.GetAllAsync(page, sort, filter);
        }

       public async Task<Books.Model.Models.Book> GetAsync(Guid id)
        {           
            return await _repository.GetAsync(id);
        }

        public async Task<Books.Model.Models.Book> PostAsync(Books.Model.Models.Book book)
        {            
            return await _repository.PostAsync(book);
        }

        public async Task<Books.Model.Models.Book> PutAsync(System.Guid id, Books.Model.Models.Book book)
        {
            return await _repository.PutAsync(id, book);
        }

        public async Task<bool> DeleteAsync(System.Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

    }
}
