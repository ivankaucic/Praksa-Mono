using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Book.Service.Common;
using Books.Model.Models;
using Books.Repository;

namespace Books.Service
{
    public class AuthorService : IAuthorService
    {
        public async Task<List<Author>> GetAllAsync()
        {
            var authorRepository = new AuthorRepository();
            return await authorRepository.GetAllAsync();
        }

        public async Task<Author> GetAsync(Guid id)
        {
            var authorRepository = new AuthorRepository();
            return await authorRepository.GetAsync(id);
        }

        public async Task<Author> PostAsync(Author author)
        {
            var authorRepository = new AuthorRepository();
            return await authorRepository.PostAsync(author);
        }

        public async Task<Author> PutAsync(System.Guid id, Author author)
        {
            var authorRepository = new AuthorRepository();
            return await authorRepository.PutAsync(id, author);
        }

        public async Task<bool> DeleteAsync(System.Guid id)
        {
            var authorRepository = new AuthorRepository();
            return await authorRepository.DeleteAsync(id);
        }


    }
}
