using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;
using Books.Model.Models;
using Books.Service;

namespace Books.WebApi.Controllers
{
    public class AuthorController : ApiController
    {
        public AuthorController()
        {

        }

        string connString = "Data Source=DESKTOP-27CEH1K\\SQLEXPRESS;Initial Catalog=Book;Integrated Security=True";
        // GET api/values
        [HttpGet]
        [Route("author_list")]
        public HttpResponseMessage GetAll()
        {

            AuthorService authorService = new AuthorService();
            var result = authorService.GetAll();
            if(result == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Database is empty.");
            }

            else return Request.CreateResponse(HttpStatusCode.OK, result);


        }

        // GET api/values/5
        [HttpGet]
        [Route("author_list_by_id")]
        public HttpResponseMessage Get([FromUri] System.Guid id)
        {
            AuthorService authorService = new AuthorService();
            var result = authorService.Get(id);
            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No one with that ID in database.");
            }

            else return Request.CreateResponse(HttpStatusCode.OK, result);

        }
    

        // POST api/values
        [HttpPost]
        [Route("add_author_to_database")]
        public HttpResponseMessage Post([FromBody] Author author)
        {

            AuthorService authorService = new AuthorService();
            var result = authorService.Post(author);
            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Couldn't put new author in database.");
            }

            else return Request.CreateResponse(HttpStatusCode.OK, result);

        }

        // PUT api/values/5
        [HttpPut]
        [Route("update_author_item")]
        public HttpResponseMessage Put([FromUri] System.Guid id, [FromBody] Author author)
        {
            AuthorService authorService = new AuthorService();
            var result = authorService.Put(id, author);
            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No one with that ID in database.");
            }

            else return Request.CreateResponse(HttpStatusCode.OK, result);


        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("delete_author")]
        public HttpResponseMessage Delete(System.Guid id)
        {
            AuthorService authorService = new AuthorService();
            var result = authorService.Delete(id);
            if (result == false)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No one with that ID in database.");
            }

            else return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
