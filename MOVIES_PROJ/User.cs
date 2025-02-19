using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class User
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public Dictionary<int, Movie> Watched_Movies;

    public User(int userid, string username)
    {
        UserId = userid;
        UserName = username;
        Watched_Movies = new Dictionary<int, Movie>();
    }

    public void AddMovie(Movie movie)
    {
        if (Watched_Movies.ContainsKey(movie.MovieId))
        {
            Console.WriteLine("The movie is already in the list. ");
           
        }
        else
        {
            Watched_Movies.Add(movie.MovieId, movie);
            Console.WriteLine($"The movie {movie.Title} was added");
        }
    }

    public double GetRating(Movie movie)
    {
        if (Watched_Movies.ContainsKey(movie.MovieId))
        {
            if (Watched_Movies[movie.MovieId].Ratings.ContainsKey(UserId))
            {
                return Watched_Movies[movie.MovieId].Ratings[UserId];
            }
            else
            {
                Console.WriteLine("No rating found for this user for the specified movie.");
                return -1; // Indicates that the user did not rate the movie
            }
        }
        else
        {
            Console.WriteLine("The user has not watched this movie.");
            return -1; // Indicates that the movie is not in the list
        }
    }
    public void DisplayWatchedMovies()
    {
        Console.WriteLine($"Movies watched by {UserName} and the ratings they gave:");
        foreach (KeyValuePair<int, Movie> moviePair in Watched_Movies)
        {
            Console.WriteLine($"- {moviePair.Value.Title}, Rating: {GetRating(moviePair.Value)}");
        }
    }

}