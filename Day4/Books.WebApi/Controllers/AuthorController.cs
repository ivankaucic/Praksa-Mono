using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using Books.WebApi.Models;
using System.Data;

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
                     

            using (SqlConnection conn = new SqlConnection(connString)) 
            {

                List<Author> authors = new List<Author>();

                SqlCommand command = new SqlCommand("SELECT * FROM dbo.Author;", conn);

                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        authors.Add(new Author(reader.GetGuid(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3)));
                    }
                    
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "No rows found!");
                }
                reader.Close();
                return Request.CreateResponse(HttpStatusCode.OK, authors);
              
            }
            
            
        }

        // GET api/values/5
        [HttpGet]
        [Route("author_list_by_id")]
        public HttpResponseMessage Get([FromUri] System.Guid id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                int count = 0;
                SqlCommand command = new SqlCommand("SELECT Count(*) FROM dbo.Author WHERE AuthorID = @param1", conn);
                conn.Open();
                command.Parameters.AddWithValue("@param1", id);
                count = (int)command.ExecuteScalar();

                if (count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Autor s ovim ID-om ne postoji");
                }
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.Author WHERE AuthorID = @param1", conn);
                Author searchedAuthor = new Author();
                conn.Open();
                command.Parameters.AddWithValue("@param1", id);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        searchedAuthor.AuthorID = reader.GetGuid(0);
                        searchedAuthor.AuthorName = reader.GetString(1);
                        searchedAuthor.Age = reader.GetInt32(2);
                        searchedAuthor.Nationality = reader.GetString(3);
                    }
               
                }
                reader.Close();
                return Request.CreateResponse(HttpStatusCode.OK, searchedAuthor);

            }

        }
    

        // POST api/values
        [HttpPost]
        [Route("add_author_to_database")]
        public HttpResponseMessage Post([FromBody] Author author)
        {

            using (SqlConnection conn = new SqlConnection(connString)) 
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    Guid authorGuid = Guid.NewGuid();
                   

                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"INSERT INTO dbo.Author(AuthorID,AuthorName,Age,Nationality) 
                            VALUES(@param1,@param2,@param3,@param4)";

                    cmd.Parameters.AddWithValue("@param1", authorGuid);
                    cmd.Parameters.AddWithValue("@param2", author.AuthorName);
                    cmd.Parameters.AddWithValue("@param3", author.Age);
                    cmd.Parameters.AddWithValue("@param4", author.Nationality);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        return Request.CreateResponse(HttpStatusCode.OK,"Added in dbo.Author database");
                    }
                    catch (SqlException e)
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "Error, can't add in dbo.Author database");
                    }

                }

            }

        }

        // PUT api/values/5
        [HttpPut]
        [Route("update_author_item")]
        public HttpResponseMessage Put([FromUri] System.Guid id, [FromBody] Author author)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                
                SqlCommand command = new SqlCommand("SELECT AuthorID FROM dbo.Author WHERE AuthorID = @param1", conn);
                command.Parameters.AddWithValue("@param1", id);
                conn.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            reader.Close();
                            cmd.Connection = conn;
                            cmd.CommandText = "UPDATE dbo.Author SET AuthorName = @param1, Age = @param2, Nationality = @param3 Where AuthorID = @param4";
                            cmd.Parameters.AddWithValue("@param1", author.AuthorName);
                            cmd.Parameters.AddWithValue("@param2", author.Age);
                            cmd.Parameters.AddWithValue("@param3", author.Nationality);
                            cmd.Parameters.AddWithValue("@param4", id);


                            cmd.ExecuteNonQuery();
                            return Request.CreateResponse(HttpStatusCode.OK, "Updejtano!");
                        } 
                    }
                    else return Request.CreateResponse(HttpStatusCode.NotFound, "Ovaj ID nema svog autora!");
                }


            }

        

        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("delete_author")]
        public HttpResponseMessage Delete(System.Guid id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                int count = 0;
                SqlCommand command = new SqlCommand("SELECT Count(*) FROM dbo.Author WHERE AuthorID = @param1", conn);
                conn.Open();
                command.Parameters.AddWithValue("@param1", id);

                count = (int)command.ExecuteScalar();

                if (count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Autor s ovim ID-om ne postoji");
                }

            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand("DELETE FROM dbo.Author WHERE AuthorID = @param1", conn);
                command.Parameters.AddWithValue("@param1", id);
                conn.Open();
                command.ExecuteNonQuery();
                return Request.CreateResponse(HttpStatusCode.OK, "Autor je izbrisan iz baze!");
            }
                

        }
    }
}
