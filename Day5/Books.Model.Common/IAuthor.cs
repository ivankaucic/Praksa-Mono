using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Model.Common
{
    public interface IAuthor
    {
        System.Guid AuthorID { get; set; }
        string AuthorName { get; set; }
        int Age { get; set; }
        string Nationality { get; set; }
    }
    
       
}
