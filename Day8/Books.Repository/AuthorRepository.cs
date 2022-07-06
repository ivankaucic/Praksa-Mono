using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Books.Model.Models;
using Books.Repository.Common;

namespace Books.Repository
{
    public class AuthorRepository : IAuthorRepository
    {

        public async Task<List<Author>> GetAllAsync()
        {
            string connString = "Data Source=DESKTOP-27CEH1K\\SQLEXPRESS;Initial Catalog=Book;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connString))
            {

                List<Author> authors = new List<Author>();

                SqlCommand command = new SqlCommand("SELECT * FROM dbo.Author;", conn);

                conn.Open();
                SqlDataReader reader = await command.ExecuteReaderAsync();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        authors.Add(new Author(reader.GetGuid(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3)));
                    }

                }
                else
                {
                    return authors;
                }
                reader.Close();
                return authors;

            }


        }

        public async Task<Author> GetAsync(Guid id)
        {
            string connString = "Data Source=DESKTOP-27CEH1K\\SQLEXPRESS;Initial Catalog=Book;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                int count = 0;
                SqlCommand command = new SqlCommand("SELECT Count(*) FROM dbo.Author WHERE AuthorID = @param1", conn);
                conn.Open();
                command.Parameters.AddWithValue("@param1", id);
                count = (int)await command.ExecuteScalarAsync();

                if (count == 0)
                {
                    return null;
                }
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.Author WHERE AuthorID = @param1", conn);
                Author searchedAuthor = new Author();
                conn.Open();
                command.Parameters.AddWithValue("@param1", id);

                SqlDataReader reader = await command.ExecuteReaderAsync();
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
                return searchedAuthor;

            }

        }

        public async Task<Author> PostAsync(Author author)
        {

            string connString = "Data Source=DESKTOP-27CEH1K\\SQLEXPRESS;Initial Catalog=Book;Integrated Security=True";

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

                    Author newAuthor = new Author(authorGuid, author.AuthorName, author.Age, author.Nationality);

                    try
                    {
                        conn.Open();
                        await cmd.ExecuteNonQueryAsync();
                        return newAuthor;
                    }
                    catch (SqlException e)
                    {
                        return newAuthor;
                    }

                }

            }

        }

        public async Task<Author> PutAsync(System.Guid id, Author author)
        {
            string connString = "Data Source=DESKTOP-27CEH1K\\SQLEXPRESS;Initial Catalog=Book;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connString))
            {

                SqlCommand command = new SqlCommand("SELECT AuthorID FROM dbo.Author WHERE AuthorID = @param1", conn);
                command.Parameters.AddWithValue("@param1", id);
                conn.Open();

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
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

                            Author updatedAuthor = new Author(id, author.AuthorName, author.Age, author.Nationality);

                            await cmd.ExecuteNonQueryAsync();
                            return updatedAuthor;
                        }
                    }
                    else return null;
                }


            }



        }

        public async Task<bool> DeleteAsync(System.Guid id)
        {

            string connString = "Data Source=DESKTOP-27CEH1K\\SQLEXPRESS;Initial Catalog=Book;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                int count = 0;
                SqlCommand command = new SqlCommand("SELECT Count(*) FROM dbo.Author WHERE AuthorID = @param1", conn);
                conn.Open();
                command.Parameters.AddWithValue("@param1", id);

                count = (int)await command.ExecuteScalarAsync();

                if (count == 0)
                {
                    return false;
                }

            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand("DELETE FROM dbo.Author WHERE AuthorID = @param1", conn);
                command.Parameters.AddWithValue("@param1", id);
                conn.Open();
                await command.ExecuteNonQueryAsync();
                return true;
            }


        }

    }
}
