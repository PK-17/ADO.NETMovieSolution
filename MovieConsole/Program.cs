using System;
using BL_Movies;
using EntityLayer;
using System.Collections.Generic;

namespace MovieConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movies = new List<Movie>();
            try
            {
                BL bL = new BL();
                movies = bL.GetMoviesBL();
                foreach(var data in movies)
                {
                    Console.WriteLine($"{data.Id} --- {data.Name} --- {data.Year} --- {data.Rating}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
