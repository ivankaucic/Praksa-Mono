using Books.Model.Models;
using Books.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Books.WebApi.Controllers
{
    public class BookController : ApiController
    {
        // GET: api/Book
        [HttpGet]
        [Route("book_list")]
        public HttpResponseMessage GetAll()
        {

            BookService authorService = new BookService();
            var result = authorService.GetAll();
            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Database is empty.");
            }

            else return Request.CreateResponse(HttpStatusCode.OK, result);


        }

        // GET: api/Book/5
        [HttpGet]
        [Route("book_list_by_id")]
        public HttpResponseMessage Get([FromUri] System.Guid id)
        {
            BookService bookService = new BookService();
            var result = bookService.Get(id);
            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No book with that ID in database.");
            }

            else return Request.CreateResponse(HttpStatusCode.OK, result);

        }

        // POST: api/Book
        [HttpPost]
        [Route("add_book_to_database")]
        public HttpResponseMessage Post([FromBody] Book book)
        {

            BookService bookService = new BookService();
            var result = bookService.Post(book);
            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Couldn't put new author in database.");
            }

            else return Request.CreateResponse(HttpStatusCode.OK, result);

        }

        // PUT: api/Book/5
        [HttpPut]
        [Route("update_book_item")]
        public HttpResponseMessage Put([FromUri] System.Guid id, [FromBody] Book book)
        {
            BookService bookService = new BookService();
            var result = bookService.Put(id, book);
            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No one with that ID in database.");
            }

            else return Request.CreateResponse(HttpStatusCode.OK, result);


        }

        // DELETE: api/Book/5
        [HttpDelete]
        [Route("delete_book")]
        public HttpResponseMessage Delete(System.Guid id)
        {
            BookService bookService = new BookService();
            var result = bookService.Delete(id);
            if (result == false)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No one with that ID in database.");
            }

            else return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
