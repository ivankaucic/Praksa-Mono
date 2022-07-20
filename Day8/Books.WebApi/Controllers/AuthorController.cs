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
using Book.Service.Common;
using Books.Common;

namespace Books.WebApi.Controllers
{
    public class AuthorController : ApiController
    {
        protected IAuthorService _service;

        public AuthorController(IAuthorService service)
        {
            this._service = service;
        }
        // GET api/values
        [HttpGet]
        [Route("author_list")]
        public async Task<HttpResponseMessage> GetAllAsync(int pageNumber, int itemsByPage, string orderBy, string sortBy,
                                                                int? age, int? ageIsLower, int? ageIsHigher, string nationality)
        {
            List<Author> authors = new List<Author>();
            List<AuthorRest> authorsRest = new List<AuthorRest>();

            Paging page = new Paging(pageNumber, itemsByPage);
            Sorting sort = new Sorting(orderBy, sortBy);
            Filtering filter = new Filtering(age, ageIsLower, ageIsHigher, nationality);

            authors = await _service.GetAllAsync(page, sort, filter);

            if (authors == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Database is empty.");
            }

            else 
            { 
                foreach(Author author in authors)
                {
                    authorsRest.Add(new AuthorRest(author.AuthorID,author.AuthorName, author.Age, author.Nationality));
                }
                return Request.CreateResponse(HttpStatusCode.OK, authorsRest); 
            }


        }

        // GET api/values/5
        [HttpGet]
        [Route("author_list_by_id")]
        public async Task<HttpResponseMessage> GetAsync([FromUri] System.Guid id)
        {
            
            var result = await _service.GetAsync(id);
            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No one with that ID in database.");
            }

            else 
            {
                AuthorRest authorById = new AuthorRest(result.AuthorID,result.AuthorName, result.Age, result.Nationality);
                return Request.CreateResponse(HttpStatusCode.OK, authorById); 
            }

        }
    

        // POST api/values
        [HttpPost]
        [Route("add_author_to_database")]
        public async Task<HttpResponseMessage> PostAsync([FromBody] Author author)
        {

            Author newAuthor = new Author(author.AuthorID, author.AuthorName, author.Age, author.Nationality);
            
            var result = await _service.PostAsync(newAuthor);
            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Couldn't put new author in database.");
            }

            else return Request.CreateResponse(HttpStatusCode.OK, newAuthor);

        }

        // PUT api/values/5
        [HttpPut]
        [Route("update_author_item")]
        public async Task<HttpResponseMessage> PutAsync([FromUri] System.Guid id, [FromBody] Author author)
        {            
            var result = await _service.PutAsync(id, author);
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
            var result = await _service.DeleteAsync(id);
            if (result == false)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No one with that ID in database.");
            }

            else return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }

    public class AuthorRest
    {
        public Guid Id;
        public string AuthorName { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }

        public AuthorRest(Guid id,string authorName, int authorAge, string authorNationality)
        {
            this.Id = id;
            this.AuthorName = authorName;
            this.Age = authorAge;
            this.Nationality = authorNationality;
        }
        
    }


}
