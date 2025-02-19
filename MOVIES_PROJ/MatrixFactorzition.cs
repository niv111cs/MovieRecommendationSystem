using MOVIES_PROJ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class MatrixFactorzition
    {
    public double[,] GetDataToMat()
    {
        SQL_Extraction sql = new SQL_Extraction();
        int userCount = sql.GetUserCount();
        int movieCount = sql.GetMovieCount();
        double[,] mat = new double[userCount, movieCount];

        List<User> users = sql.init_Users_data();
        for (int i = 0;i < userCount; i++)
        {
            int user_id= users[i].UserId;
            for (int j = 0;j < users[i].Watched_Movies.Count; j++)
            {
                int movie_id= users[i].Watched_Movies[j].MovieId;
                mat[user_id, movie_id] = users[i].GetRating(users[i].Watched_Movies[movie_id]);
            }
        }
        return mat;

    }

      

              


    }







