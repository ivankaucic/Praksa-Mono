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
        public List<Author> GetAll()
        {
            var authorRepository = new AuthorRepository();
            return authorRepository.GetAll();
        }

        public Author Get(Guid id)
        {
            var authorRepository = new AuthorRepository();
            return authorRepository.Get(id);
        }

        public Author Post(Author author)
        {
            var authorRepository = new AuthorRepository();
            return authorRepository.Post(author);
        }

        public Author Put(System.Guid id, Author author)
        {
            var authorRepository = new AuthorRepository();
            return authorRepository.Put(id, author);
        }

        public bool Delete(System.Guid id)
        {
            var authorRepository = new AuthorRepository();
            return authorRepository.Delete(id);
        }


    }
}
