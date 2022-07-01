using Books.Model.Models;
using Books.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Books.Model.Common;

namespace Books.WebApi.Controllers
{
    public class BookController : ApiController
    {
        // GET: api/Book
        [HttpGet]
        [Route("book_list")]
        public HttpResponseMessage GetAll()
        {
            List<Book> books = new List<Book>();
            List<BookRest> booksRest = new List<BookRest>();
            BookService authorService = new BookService();
            books = authorService.GetAll();

            if (books == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Database is empty.");
            }

            else 
            { 
                foreach (Book book in books)
                {
                    booksRest.Add(new BookRest(book.Author, book.Name, book.Genre));
                }
                return Request.CreateResponse(HttpStatusCode.OK, booksRest); 
            }
        


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
        public HttpResponseMessage Post([FromBody] BookRest book)
        {
            Book newBook = new Book(book.Author, book.Name, book.Genre); /* domain */

            BookService bookService = new BookService();
            var result = bookService.Post(newBook);
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

    public class BookRest
    {

        public System.Guid Author { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }

        public BookRest(Guid author, string name, string genre)
        {
            this.Author = author;
            this.Name = name;
            this.Genre = genre;
        }


    }



}
