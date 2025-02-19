using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

namespace MOVIES_PROJ

{

    public class SQL_Extraction
    {

      

        private string connectionString = "Server=(localdb)\\mssqllocaldb;Database=MovieDB;Trusted_Connection=True;";

       

        public List<User> init_Users_data()
        {
            List<User> users = new List<User>();
            List<Movie> movies = movie_data();


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT UserID, UserName FROM Users";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int userId = reader.GetInt32(0); // קריאת UserID
                                string userName = reader.GetString(1); // קריאת UserName
                                users.Add(new User(userId, userName));
                                get_watched_movies(movies, users[users.Count-1]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to fetch users: " + ex.Message);
                }
            }

            return users;
        }
        public void get_watched_movies(List<Movie> movies,User user)
        {
            for (int i = 0; i < movies.Count; i++)
            {
               if( movies[i].Ratings.ContainsKey(user.UserId))
                {
                    user.AddMovie(movies[i]);
                }
            }
        }
        public List<Movie> movie_data()
        {
            List <Movie> movies = new List<Movie>();
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                string query = "select * from Movies";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int movieid = reader.GetInt32(0);
                            string title = reader.GetString(1);
                            string genere = reader.GetString(2);
                            DateTime releasedate = reader.GetDateTime(3);
                            movies.Add(new Movie(movieid, title, genere, releasedate));
                            Get_Ratings(movies[movies.Count - 1]);
                        }
                    }
                }


            }
            return movies;


        }
        public void Get_Ratings(Movie movie)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                    connection.Open();
                    string query = "select Rating,UserId from Ratings where MovieId = " + movie.MovieId;

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                double rating1 = reader.GetDouble(0);
                                int userId1 = reader.GetInt32(1); // קריאת UserID
                                movie.AddRating(userId1, rating1);

                            }
                        }
                    }
                
                
            }




            
        }
        public int GetUserCount()
        {
            int userCount = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Users"; // שליפת כמות המשתמשים

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    userCount = (int)command.ExecuteScalar();
                }
            }
            return userCount;
        }

        public int GetMovieCount()
        {
            int movieCount = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Movies"; // שליפת כמות הסרטים

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    movieCount = (int)command.ExecuteScalar();
                }
            }
            return movieCount;
        }

    }
}
