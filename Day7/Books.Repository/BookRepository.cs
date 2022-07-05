using Books.Model.Models;
using Books.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Repository
{
    public class BookRepository : IBookRepository
    {
        public async Task<List<Book>> GetAllAsync()
        {
            string connString = "Data Source=DESKTOP-27CEH1K\\SQLEXPRESS;Initial Catalog=Book;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connString))
            {

                List<Book> books = new List<Book>();

                SqlCommand command = new SqlCommand("SELECT * FROM dbo.Book;", conn);

                conn.Open();
                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        books.Add(new Book(reader.GetGuid(0), reader.GetGuid(1), reader.GetString(2), reader.GetString(3)));
                    }

                }
                else
                {
                    return books;
                }
                reader.Close();
                return books;

            }


        }

        public async Task<Book> GetAsync(Guid id)
        {
            string connString = "Data Source=DESKTOP-27CEH1K\\SQLEXPRESS;Initial Catalog=Book;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                int count = 0;
                SqlCommand command = new SqlCommand("SELECT Count(*) FROM dbo.Book WHERE BookID = @param1", conn);
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
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.Book WHERE BookID = @param1", conn);
                Book searchedBook = new Book();
                conn.Open();
                command.Parameters.AddWithValue("@param1", id);

                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        searchedBook.Id = reader.GetGuid(0);
                        searchedBook.Author = reader.GetGuid(1);
                        searchedBook.Name = reader.GetString(2);
                        searchedBook.Genre = reader.GetString(3);

                    }

                }
                reader.Close();
                return searchedBook;

            }

        }

        public async Task<Book> PostAsync(Book book)
        {

            string connString = "Data Source=DESKTOP-27CEH1K\\SQLEXPRESS;Initial Catalog=Book;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    Guid bookGuid = Guid.NewGuid();


                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"INSERT INTO dbo.Book(BookID,Author,BookName,Genre) 
                            VALUES(@param1,@param2,@param3,@param4)";

                    cmd.Parameters.AddWithValue("@param1", bookGuid);
                    cmd.Parameters.AddWithValue("@param2", book.Author);
                    cmd.Parameters.AddWithValue("@param3", book.Name);
                    cmd.Parameters.AddWithValue("@param4", book.Genre);

                    Book newBook = new Book(bookGuid, book.Author, book.Name, book.Genre);

                    try
                    {
                        conn.Open();
                        await cmd.ExecuteNonQueryAsync();
                        return newBook;
                    }
                    catch (SqlException e)
                    {
                        return newBook;
                    }

                }

            }

        }

        public async Task<Book> PutAsync(System.Guid id, Book book)
        {
            string connString = "Data Source=DESKTOP-27CEH1K\\SQLEXPRESS;Initial Catalog=Book;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connString))
            {

                SqlCommand command = new SqlCommand("SELECT BookID FROM dbo.Book WHERE BookID = @param1", conn);
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
                            cmd.CommandText = "UPDATE dbo.Book SET Author = @param1, BookName = @param2, Genre = @param3 Where BookID = @param4";
                            cmd.Parameters.AddWithValue("@param1", book.Author);
                            cmd.Parameters.AddWithValue("@param2", book.Name);
                            cmd.Parameters.AddWithValue("@param3", book.Genre);
                            cmd.Parameters.AddWithValue("@param4", id);

                            Book updatedBook = new Book(id, book.Author, book.Name, book.Genre);

                            await cmd.ExecuteNonQueryAsync();
                            return updatedBook;
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
                SqlCommand command = new SqlCommand("SELECT Count(*) FROM dbo.Book WHERE BookID = @param1", conn);
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
                SqlCommand command = new SqlCommand("DELETE FROM dbo.Book WHERE BookID = @param1", conn);
                command.Parameters.AddWithValue("@param1", id);
                conn.Open();
                await command.ExecuteNonQueryAsync();
                return true;
            }


        }

    }
}
