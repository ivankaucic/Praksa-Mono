using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.WebApi.Models
{
    public class Author
    {
        public System.Guid AuthorID { get; set; }
        public string AuthorName { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }

        public Author(System.Guid guid, string authorName, int authorAge, string authorNationality)
        {
            this.AuthorID = guid;
            this.AuthorName = authorName;
            this.Age = authorAge;
            this.Nationality = authorNationality;
        }
        public Author()
        {

        }
    }
}