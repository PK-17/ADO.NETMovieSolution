using System;
using DAL_Movies;
using EntityLayer;
using System.Collections.Generic;

namespace BL_Movies
{
    public class BL
    {
        public bool AddMovieBL(Movie movie)
        {
            try
            {
                if(movie.Name == null)
                {
                    throw new Exception("Movie name cannot be null");
                } else if(movie.Year<2000)
                {
                    throw new Exception("Old Movies Data is not accepted");
                } else if(movie.Rating < 1 || movie.Rating>5)
                {
                    throw new Exception("Invalid Rating (Should be in Range 1-5)");
                } else
                {
                    DAL dAL = new DAL();
                    dAL.AddMovie(movie);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public Movie FindMovieBL(int id)
        {
            Movie movie = new Movie();
            DAL dAL = new DAL();
            try
            {
                if(id<0)
                {
                    throw new Exception("Id is negative");
                }
                movie = dAL.FindMovie(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return movie;
        }
        public List<Movie> GetMoviesBL()
        {
            List<Movie> movies = null;
            try
            {
                DAL dAL = new DAL();
                movies = dAL.GetMovies();
                if(movies.Count == 0)
                {
                    throw new Exception("No Movies Present");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return movies;
        }
    }
}
