using Books.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Model.Models
{
    public class Book : IBook
    {       
        
        public System.Guid Id { get; set; }
        public System.Guid Author { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }

        public Book(System.Guid guid, System.Guid author,string bookName,string genre)
        {
            this.Id = guid;
            this.Name = bookName;
            this.Author = author;
            this.Genre = genre;
        }
        public Book()
        {

        }

        public Book(System.Guid author, string bookName, string genre)
        {
            this.Author = author;
            this.Name = bookName;
            this.Genre = genre;
        }
      
    }
}
