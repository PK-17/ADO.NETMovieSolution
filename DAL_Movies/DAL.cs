using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using EntityLayer;


namespace DAL_Movies
{
    public class DAL
    {
        string constr = @"server=PK17\SQLEXPRESS; initial catalog=1026Db; integrated security=true";

        public bool AddMovie(Movie movie)
        {
            try
            {
                SqlConnection connection = new SqlConnection(constr);
                string commandtext = "insert into movies(name, year, rating) values(@name, @year, @rating)";
                SqlCommand command = new SqlCommand(commandtext, connection);
                command.Parameters.AddWithValue("@name", movie.Name);
                command.Parameters.AddWithValue("@year", movie.Year);
                command.Parameters.AddWithValue("@rating", movie.Rating);
                connection.Open();
                int x = command.ExecuteNonQuery();
                if(x==0)
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public Movie FindMovie(int id)
        {
            Movie movie = new Movie();
            try
            {
                SqlConnection connection = new SqlConnection(constr);
                SqlCommand command = new SqlCommand("select * from movies where id=@id", connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if (!reader.HasRows)
                {
                    throw new Exception($"Movie {id} not present!");
                }
                else
                {
                    movie.Id = Convert.ToInt32(reader["id"]);
                    movie.Name = reader["name"].ToString();
                    movie.Year = Convert.ToInt32(reader["year"]);
                    movie.Rating = Convert.ToInt32(reader["rating"]);

                }
            } 
            catch (Exception ex)
            {
                throw ex;
            }
            return movie;
        }
        public List<Movie> GetMovies()
        {
            List<Movie> movies = new List<Movie>();
            try
            {
                SqlConnection connection = new SqlConnection(constr);
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("select * from movies", connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while(reader.Read())
                {
                    Movie mm = new Movie();
                    mm.Id = Convert.ToInt32(reader["id"]);
                    mm.Name = reader["name"].ToString();
                    mm.Year = Convert.ToInt32(reader["year"]);
                    mm.Rating = Convert.ToInt32(reader["rating"]);
                    movies.Add(mm);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return movies;
        }
    }
}
