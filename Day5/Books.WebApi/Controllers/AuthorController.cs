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
using System.Threading.Tasks;

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
        public async Task<HttpResponseMessage> GetAllAsync()
        {
            List<Author> authors = new List<Author>();
            List<AuthorRest> booksRest = new List<AuthorRest>();
            AuthorService authorService = new AuthorService();
            authors = await authorService.GetAllAsync();
            if(authors == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Database is empty.");
            }

            else return Request.CreateResponse(HttpStatusCode.OK, authors);


        }

        // GET api/values/5
        [HttpGet]
        [Route("author_list_by_id")]
        public async Task<HttpResponseMessage> GetAsync([FromUri] System.Guid id)
        {
            AuthorService authorService = new AuthorService();
            var result = await authorService.GetAsync(id);
            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No one with that ID in database.");
            }

            else 
            {
                AuthorRest authorById = new AuthorRest(result.AuthorName, result.Age, result.Nationality);
                return Request.CreateResponse(HttpStatusCode.OK, authorById); 
            }

        }
    

        // POST api/values
        [HttpPost]
        [Route("add_author_to_database")]
        public async Task<HttpResponseMessage> PostAsync([FromBody] Author author)
        {

            Author newBook = new Author(author.AuthorName, author.Age, author.Nationality);

            AuthorService authorService = new AuthorService();
            var result = await authorService.PostAsync(author);
            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Couldn't put new author in database.");
            }

            else return Request.CreateResponse(HttpStatusCode.OK, result);

        }

        // PUT api/values/5
        [HttpPut]
        [Route("update_author_item")]
        public async Task<HttpResponseMessage> PutAsync([FromUri] System.Guid id, [FromBody] Author author)
        {
            AuthorService authorService = new AuthorService();
            var result = await authorService.PutAsync(id, author);
            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No one with that ID in database.");
            }

            else return Request.CreateResponse(HttpStatusCode.OK, result);


        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("delete_author")]
        public async Task<HttpResponseMessage> DeleteAsync(System.Guid id)
        {
            AuthorService authorService = new AuthorService();
            var result = await authorService.DeleteAsync(id);
            if (result == false)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No one with that ID in database.");
            }

            else return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }

    public class AuthorRest
    {
        public string AuthorName { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }

        public AuthorRest(string authorName, int authorAge, string authorNationality)
        {
            this.AuthorName = authorName;
            this.Age = authorAge;
            this.Nationality = authorNationality;
        }
        
    }


}
