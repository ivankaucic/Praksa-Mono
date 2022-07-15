using Books.Model.Models;
using Books.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Books.Model.Common;
using System.Threading.Tasks;
using Book.Service.Common;
using Books.Common;

namespace Books.WebApi.Controllers
{
    public class BookController : ApiController
    {
        protected IBookService _service;

        public BookController(IBookService service)
        {
            this._service = service;
        }
        // GET: api/Book
        [HttpGet]
        [Route("book_list")]
        public async Task<HttpResponseMessage> GetAllAsync(int pageNumber, int itemsByPage, string orderBy, string sortBy,
                                                                string genre)
        {
            List<Books.Model.Models.Book> books = new List<Books.Model.Models.Book>();
            List<BookRest> booksRest = new List<BookRest>();

            Paging page = new Paging(pageNumber, itemsByPage);
            Sorting sort = new Sorting(orderBy, sortBy);
            Filtering filter = new Filtering(genre);

            books = await _service.GetAllAsync(page, sort, filter);

            if (books == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Database is empty.");
            }

            else 
            { 
                foreach (Books.Model.Models.Book book in books)
                {
                    booksRest.Add(new BookRest(book.Author, book.Name, book.Genre));
                }
                return Request.CreateResponse(HttpStatusCode.OK, booksRest); 
            }
        


        }

        // GET: api/Book/5
        [HttpGet]
        [Route("book_list_by_id")]
        public async Task<HttpResponseMessage> GetAsync([FromUri] System.Guid id)
        {           
            var result = await _service.GetAsync(id);
            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No book with that ID in database.");
            }

            else {
                BookRest bookById = new BookRest(result.Author, result.Name, result.Genre);
                return Request.CreateResponse(HttpStatusCode.OK, bookById); 
            }

        }

        // POST: api/Book
        [HttpPost]
        [Route("add_book_to_database")]
        public async Task<HttpResponseMessage> PostAsync([FromBody] BookRest book)
        {
            Books.Model.Models.Book newAuthor = new Books.Model.Models.Book(book.Author, book.Name, book.Genre);
       
            var result = await _service.PostAsync(newAuthor);
            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Couldn't put new author in database.");
            }

            else return Request.CreateResponse(HttpStatusCode.OK, newAuthor);

        }

        // PUT: api/Book/5
        [HttpPut]
        [Route("update_book_item")]
        public async Task<HttpResponseMessage> PutAsync([FromUri] System.Guid id, [FromBody] Books.Model.Models.Book book)
        {
            var result = await _service.PutAsync(id, book);
            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No one with that ID in database.");
            }

            else return Request.CreateResponse(HttpStatusCode.OK, result);


        }

        // DELETE: api/Book/5
        [HttpDelete]
        [Route("delete_book")]
        public async Task<HttpResponseMessage> DeleteAsync(System.Guid id)
        {
            var result = await _service.DeleteAsync(id);
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
