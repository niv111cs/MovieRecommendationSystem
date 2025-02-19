using System;
using System.Collections.Generic;
using System.Linq;


public class Movie
{
    public int MovieId { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public DateTime ReleaseDate { get; set; }
    public double AverageRating { get; set; }
    public Dictionary<int, double> Ratings;

    public Movie(int movieId, string title, string genre, DateTime releaseDate)
    {
        MovieId = movieId;
        Title = title;
        Genre = genre;
        ReleaseDate = releaseDate;
        AverageRating = 0.0;
        Ratings = new Dictionary<int, double>();
    }

    public void AddRating(int userId, double rating)
    {
        if (rating < 0 || rating > 5)
        {
            throw new ArgumentException("Rating must be between 0 and 5.");
        }

        if (Ratings.ContainsKey(userId))
        {
            AverageRating = (this.Ratings.Count * AverageRating + rating - Ratings[userId]) / (this.Ratings.Count);
            Ratings[userId] = rating;
        }
        else
        {
            AverageRating = (this.Ratings.Count * AverageRating + rating) / (this.Ratings.Count + 1);
            Ratings.Add(userId, rating);
        }
    }

    public void RemoveRating(int userId)
    {
        if (Ratings.ContainsKey(userId))
        {
            if (this.Ratings.Count > 0)
            {
                AverageRating = (this.Ratings.Count * AverageRating - Ratings[userId]) / (this.Ratings.Count - 1);
                Ratings.Remove(userId);
            }
        }
        else
        {
            Console.WriteLine("Rating for this user does not exist.");
        }
    }

    public void DisplayMovieDetails()
    {
        Console.WriteLine($"Movie ID: {MovieId}");
        Console.WriteLine($"Tit" +
            $"le: {Title}");
        Console.WriteLine($"Genre: {Genre}");
        Console.WriteLine($"Release Date: {ReleaseDate.ToShortDateString()}");
        Console.WriteLine($"Average Rating: {AverageRating:F1}");
    }
}

