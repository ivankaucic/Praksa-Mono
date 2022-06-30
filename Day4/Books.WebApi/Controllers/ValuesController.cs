using Books.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Books.WebApi.Controllers
{
    

    public class ValuesController : ApiController
    {

        static List<Book> bookshelf = new List<Book>();

        public ValuesController()
        {
            
        }

        [HttpGet]//data anotacija
        [Route("fill_bookshelf")]//isto data anotacija
        public HttpResponseMessage InitializeList()
        {
            if(bookshelf.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.Created, bookshelf);
            }
            else
            {
                bookshelf.Add(new Book { Name = "The Little Prince", Author = "Antoine de Saint-Exupery", Id = 1 });
                bookshelf.Add(new Book { Name = "Catcher in the rye", Author = "J. D. Salinger", Id = 2 });
                bookshelf.Add(new Book { Name = "Lord of the Flies", Author = "William Golding", Id = 3 });
                return Request.CreateResponse(HttpStatusCode.OK, bookshelf);
            }
            
        }

        // GET api/values
        [HttpGet]
        [Route("book_list")]
        public HttpResponseMessage Get()
        {
            if(bookshelf.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, bookshelf);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, bookshelf);
            }
        }

        // GET api/values/5
        [HttpGet]
        [Route("book_list_by_id")]
        public HttpResponseMessage Get([FromUri]int id)
        {
            Book book = bookshelf.Where(x => x.Id == id).FirstOrDefault();
            if (book == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, book);
            }
            else { return Request.CreateResponse(HttpStatusCode.OK, book); }
        }

        // POST api/values
        [HttpPost]
        [Route("add_book_to_booklist")]
        public HttpResponseMessage Post([FromBody]Book book)
        {
            int flag = 0;
            foreach(Book books in bookshelf)
            {
                if(books.Id == book.Id)
                {
                    flag = 1;
                    return Request.CreateResponse(HttpStatusCode.Conflict, bookshelf);
                    
                }
            }
            if (flag == 0)
            {
                bookshelf.Add(book);
                return Request.CreateResponse(HttpStatusCode.OK, bookshelf);

            }
            else return Request.CreateResponse(HttpStatusCode.NotFound, bookshelf);

        }

        // PUT api/values/5
        [HttpPut]
        [Route("update_book_item")]
        public HttpResponseMessage Put([FromUri]int id,[FromUri]string bookName)
        {
            Book book = bookshelf.Where(x => x.Id == id).FirstOrDefault();
            if (book == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, bookshelf);
            }
            else
            {
                book.Name = bookName;
                return Request.CreateResponse(HttpStatusCode.OK, bookshelf);
            }
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            Book book = bookshelf.Where(x => x.Id == id).FirstOrDefault();
            if (book == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, bookshelf);
            }
            else
            {
                bookshelf.Remove(book);
                return Request.CreateResponse(HttpStatusCode.OK, bookshelf);
            }
        }
    }
}
