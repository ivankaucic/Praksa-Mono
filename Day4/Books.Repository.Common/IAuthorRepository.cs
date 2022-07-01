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
        List<Author> GetAll();
        Author Get(Guid id);
        Author Post(Author author);
        Author Put(System.Guid id, Author author);
        bool Delete(System.Guid id);

    }
}
