using System;
using System.Collections.Generic;
using System.Text;
using EntityLayer;
using BL_Movies;

namespace MovieConsole
{
    class AddMovie
    {
        static void Main()
        {
            try
            {
                Movie movie = new Movie();
                Console.WriteLine("Enter Movie Name");
                movie.Name = Console.ReadLine();
                Console.WriteLine("Enter Movie Year");
                movie.Year = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Movie Rating");
                movie.Rating = Convert.ToInt32(Console.ReadLine());
                BL bL = new BL();
                bL.AddMovieBL(movie);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
