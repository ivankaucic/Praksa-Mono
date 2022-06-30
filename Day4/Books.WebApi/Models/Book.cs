using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.WebApi.Models
{
    public class Book
    {
        public string Name { get; set; } = "";
        public string Author { get; set; } = "";
        public int Id { get; set; } = 0;
    }
}