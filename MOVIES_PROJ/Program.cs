using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;  



class Program
{

    static void Main(string[] args)
    {
        User u1 = new User(10, "niv"); 
    }

        //// Creating movies
        //Movie movie1 = new Movie(1, "Matrix", "Sci-Fi", new DateTime(1999, 3, 31));
        //Movie movie2 = new Movie(2, "Inception", "Sci-Fi", new DateTime(2010, 7, 16));
        //Movie movie3 = new Movie(3, "The Dark Knight", "Action", new DateTime(2008, 7, 18));

        //// Creating users
        //User user1 = new User(1, "Alice");
        //User user2 = new User(2, "Bob");

        //// Adding ratings by users
        //user1.AddMovie(movie1, 4.5);
        //user1.AddMovie(movie2, 5.0);

        //user2.AddMovie(movie1, 4.0);
        //user2.AddMovie(movie3, 4.8);

        //// Displaying movie details
        ////Console.WriteLine("Movie details after ratings:");
        ////movie1.DisplayMovieDetails();
        ////movie2.DisplayMovieDetails();
        ////movie3.DisplayMovieDetails();

        ////// Checking ratings for a user
        ////Console.WriteLine("\nRatings for Alice:");
        ////Console.WriteLine($"Alice's rating for Matrix: {user1.GetRating(movie1)}");
        ////Console.WriteLine($"Alice's rating for The Dark Knight: {user1.GetRating(movie3)}"); // No rating

        ////// Updating rating for a movie by Alice
        ////user1.AddMovie(movie1, 5.0); // Updating rating
        ////Console.WriteLine("\nDetails of Matrix after updating rating:");
        ////movie1.DisplayMovieDetails();

        ////// Removing Bob's rating for Matrix
        ////Console.WriteLine("\nRemoving Bob's rating for Matrix...");
        ////movie1.RemoveRating(2); // Removing rating for user 2 (Bob)
        ////movie1.DisplayMovieDetails();
        //user1.DisplayWatchedMovies();
    
}
