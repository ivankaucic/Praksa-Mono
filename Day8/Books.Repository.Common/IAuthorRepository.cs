using Books.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Repository.Common
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAsync();
        Task<Author> GetAsync(Guid id);
        Task<Author> PostAsync(Author author);
        Task<Author> PutAsync(System.Guid id, Author author);
        Task<bool> DeleteAsync(System.Guid id);

    }
}
