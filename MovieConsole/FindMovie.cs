using System;
using System.Collections.Generic;
using System.Text;
using EntityLayer;
using BL_Movies;

namespace MovieConsole
{
    class FindMovie
    {
        static void Main()
        {
            int id;
            Console.WriteLine("Enter Movie to Search");
            id = Convert.ToInt32(Console.ReadLine());
            try
            {
                BL bL = new BL();
                Movie movie = bL.FindMovieBL(id);
                Console.WriteLine($"{movie.Id} --- {movie.Name} --- {movie.Year} --- {movie.Rating}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
