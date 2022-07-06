using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Books.Common;
using Books.Model.Models;
using Books.Repository.Common;

namespace Books.Repository
{
    public class AuthorRepository : IAuthorRepository
    {

        public async Task<List<Author>> GetAllAsync(Paging page, Sorting sort, Filtering filter)
        {
            string connString = "Data Source=DESKTOP-27CEH1K\\SQLEXPRESS;Initial Catalog=Book;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connString))
            {

                List<Author> authors = new List<Author>();

                /*da npr. na 2. stranici pocne s 3. elementom i ide do 4. elementa jer je 2 po stranici*/
                int formula = ((page.PageNumber - 1) * page.ItemsByPage);

                bool flagForAndNoAndFlip = false;

                SqlCommand command = new SqlCommand();
                command.Connection = conn;                

                StringBuilder stringBuilder = new StringBuilder("SELECT * FROM dbo.Author WHERE 1=1 ");

                //if(filter.Age != null)
                //{
                //    if (flagForAndNoAndFlip == false)
                //    {
                //        stringBuilder.Append("WHERE AGE = @age ");
                //        command.Parameters.AddWithValue("@age", filter.Age);
                //        flagForAndNoAndFlip = true;
                //    }
                //    else
                //    {
                //        stringBuilder.Append("AND WHERE AGE = @age ");
                //        command.Parameters.AddWithValue("@age", filter.Age);
                //    }
                //}

                if(filter.Age != null)
                {
                    stringBuilder.Append("AND WHERE AGE = @age ");
                    command.Parameters.AddWithValue("@age", filter.Age);
                }

                //if (filter.AgeIsLower != null)
                //{
                //    if (flagForAndNoAndFlip == false)
                //    {
                //        stringBuilder.Append("WHERE AGE < @ageIsHigher ");
                //        command.Parameters.AddWithValue("@ageIsHigher", filter.AgeIsHigher);
                //        flagForAndNoAndFlip = true;
                //    }
                //    else
                //    {
                //        stringBuilder.Append("AND WHERE AGE = @ageIsHigher ");
                //        command.Parameters.AddWithValue("@ageIsHigher", filter.AgeIsHigher);
                //    }
                //}
                if (filter.AgeIsHigher != null)
                {
                    stringBuilder.Append("AND WHERE AGE < @ageIsHigher ");
                    command.Parameters.AddWithValue("@ageIsHigher", filter.AgeIsHigher);
                }

                //    if (filter.AgeIsHigher != null)
                //{
                //    if (flagForAndNoAndFlip == false)
                //    {
                //        stringBuilder.Append("WHERE AGE > @ageIsLower ");
                //        command.Parameters.AddWithValue("@ageIsLower", filter.AgeIsLower);
                //        flagForAndNoAndFlip = true;
                //    }
                //    else
                //    {
                //        stringBuilder.Append("AND WHERE AGE > @ageIsLower ");
                //        command.Parameters.AddWithValue("@ageIsLower", filter.AgeIsLower);
                //    }
                //}
                if (filter.AgeIsLower != null)
                {
                    stringBuilder.Append("AND WHERE AGE > @ageIsLower ");
                    command.Parameters.AddWithValue("@ageIsLower", filter.AgeIsLower);
                }


                //    if (filter.Nationality != null)
                //{
                //    if (flagForAndNoAndFlip == false)
                //    {
                //        stringBuilder.Append("WHERE Nationality = @nationality ");
                //        command.Parameters.AddWithValue("@Nationality", filter.Nationality);
                //        flagForAndNoAndFlip = true;
                //    }
                //    else
                //    {
                //        stringBuilder.Append("AND WHERE Nationality = @nationality ");
                //        command.Parameters.AddWithValue("@Nationality", filter.Nationality);
                //    }
                //}

                if (filter.Nationality != null)
                {
                    stringBuilder.Append("AND WHERE Nationality = @Nationality ");
                    command.Parameters.AddWithValue("@Nationality", filter.Nationality);
                }

                stringBuilder.Append(string.Format("ORDER BY {0} {1} ", sort.OrderBy, sort.SortBy));
                stringBuilder.Append("OFFSET @formula ROWS FETCH NEXT @itemsByPage ROWS ONLY;");
                
                command.Parameters.AddWithValue("@formula", formula);
                command.Parameters.AddWithValue("@itemsByPage", page.ItemsByPage);

                command.CommandText = stringBuilder.ToString();

                await conn.OpenAsync();
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
                await conn.OpenAsync();
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
                await conn.OpenAsync();
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
                        await conn.OpenAsync();
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
                await conn.OpenAsync();

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
                await conn.OpenAsync();
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
                await conn.OpenAsync();
                await command.ExecuteNonQueryAsync();
                return true;
            }


        }

    }
}
