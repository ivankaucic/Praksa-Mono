using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Book.Service.Common;
using Books.Common;
using Books.Model.Models;
using Books.Repository;
using Books.Repository.Common;

namespace Books.Service
{
    public class AuthorService : IAuthorService
    {
        protected IAuthorRepository _repository; 

        public AuthorService(IAuthorRepository repository)
        {
            this._repository = repository;
        }

        public async Task<List<Author>> GetAllAsync(Paging page, Sorting sort, Filtering filter)
        {
            return await _repository.GetAllAsync(page, sort, filter);
        }

        public async Task<Author> GetAsync(Guid id)
        {
            
            return await _repository.GetAsync(id);
        }

        public async Task<Author> PostAsync(Author author)
        {
            return await _repository.PostAsync(author);
        }

        public async Task<Author> PutAsync(System.Guid id, Author author)
        {
            return await _repository.PutAsync(id, author);
        }

        public async Task<bool> DeleteAsync(System.Guid id)
        {
            return await _repository.DeleteAsync(id);
        }


    }
}
