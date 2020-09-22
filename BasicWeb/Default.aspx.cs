using BasicWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BasicWeb
{
    public partial class _Default : Page
    {
        public List<Movies> movies_list = new List<Movies>();
        public List<Movies> movies_popular = new List<Movies>();
        public List<Movies> movies_latest = new List<Movies>();
        public List<Movies> movies_mostViewd = new List<Movies>();
        public List<Review> movies_Review = new List<Review>();
        public List<string> movie_popular_info_genre = new List<string>();
        public List<string> movie_latest_info_genre = new List<string>();
        public List<string> movie_mostViwed_info_genre = new List<string>();
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            load_movies_slider();
            load_movies_popular();
            load_movies_latest();
            load_movies_mostViewd();
            load_latest_Review();

            if (Request.QueryString.AllKeys.Contains("Mid") || Request.QueryString.AllKeys.Contains("action"))
            {
                string Mid = Request.QueryString["Mid"];
                /*string action = Request.QueryString["action"];

                if (action.Equals("add"))
                {
                    //add_to_cart(pro_id);
                }*/
                
            }
        }

        void load_movies_slider()
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }
            // loading main slider section  
            string query = "Select * from Movies order by Movies.Mid desc";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    movies_list.Add(new Movies(reader["Mid"].ToString(), reader["Name"].ToString(), reader["Category"].ToString(),
                        reader["Description"].ToString(), reader["PosterURL"].ToString(), reader["PhotoURL"].ToString(),
                        reader["ReleaseYear"].ToString(), reader["StudioName"].ToString(), reader["RunTime"].ToString(),
                        reader["Ratings"].ToString(), reader["NoOfReview"].ToString(), reader["NoOfView"].ToString(),reader["TrailerURL"].ToString()));
                }
            }
            con.Close();
            
        }

        void load_movies_popular()
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }
            // loading popular section
            string query2 = @"Select Movies.Mid,Movies.Name,Movies.Category,Movies.PosterURL,Movies.Ratings,Movies.PhotoURL,Movies.TrailerURL from Movies order by Movies.Ratings desc";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            if (reader2.HasRows)
            {
                while (reader2.Read())
                {

                    movies_popular.Add(new Movies(reader2["Mid"].ToString(), reader2["Name"].ToString(),reader2["Category"].ToString(), reader2["PosterURL"].ToString(),
                         reader2["Ratings"].ToString(), reader2["PhotoURL"].ToString(), reader2["TrailerURL"].ToString()));
                }
            }
            con.Close();
            foreach (var movie in movies_popular)
            {
                load_popular_every_genre_byId(movie.Mid);
            }
        }
        public void load_mostViewd_every_genre_byId(string mid)
        {
            try
            {

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                string tempGenre = "";
                string query = @"Select Genre.Title from MovieGenre inner join Genre on MovieGenre.Gid = Genre.Gid where MovieGenre.Mid = " + mid;
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        tempGenre += reader["Title"].ToString() + ", ";
                    }
                }
                con.Close();
                tempGenre = tempGenre.Remove(tempGenre.Length - 2);
                movie_mostViwed_info_genre.Add(tempGenre);

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        public void load_popular_every_genre_byId(string mid)
        {
            try
            {

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                string tempGenre = "";
                string query = @"Select Genre.Title from MovieGenre inner join Genre on MovieGenre.Gid = Genre.Gid where MovieGenre.Mid = " + mid;
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        tempGenre += reader["Title"].ToString() + ", ";
                    }
                }
                con.Close();
                tempGenre = tempGenre.Remove(tempGenre.Length - 2);
                movie_popular_info_genre.Add(tempGenre);

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        public void load_latest_every_genre_byId(string mid)
        {
            try
            {

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                string tempGenre = "";
                string query = @"Select Genre.Title from MovieGenre inner join Genre on MovieGenre.Gid = Genre.Gid where MovieGenre.Mid = " + mid;
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        tempGenre += reader["Title"].ToString() + ", ";
                    }
                }
                con.Close();
                tempGenre = tempGenre.Remove(tempGenre.Length - 2);
                movie_latest_info_genre.Add(tempGenre);

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void load_movies_latest()
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }
            
            string query2 = @"Select Movies.Mid,Movies.Name,Movies.Category,Movies.PosterURL,Movies.Ratings,Movies.PhotoURL,Movies.TrailerURL from Movies order by Movies.Mid desc";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            if (reader2.HasRows)
            {
                while (reader2.Read())
                {

                    movies_latest.Add(new Movies(reader2["Mid"].ToString(), reader2["Name"].ToString(), reader2["Category"].ToString(), reader2["PosterURL"].ToString(),
                         reader2["Ratings"].ToString(),reader2["PhotoURL"].ToString(),reader2["TrailerURL"].ToString()));
                }
            }
            con.Close();
            foreach (var movie in movies_latest)
            {
                load_latest_every_genre_byId(movie.Mid);
            }
        }


        void load_movies_mostViewd()
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }
            // loading popular section
            string query2 = @"Select Movies.Mid,Movies.Name,Movies.Category,Movies.PosterURL,Movies.Ratings,Movies.PhotoURL,Movies.TrailerURL from Movies order by Movies.NoOfView desc";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            if (reader2.HasRows)
            {
                while (reader2.Read())
                {

                    movies_mostViewd.Add(new Movies(reader2["Mid"].ToString(), reader2["Name"].ToString(), reader2["Category"].ToString(), reader2["PosterURL"].ToString(),
                         reader2["Ratings"].ToString(), reader2["PhotoURL"].ToString(), reader2["TrailerURL"].ToString()));
                }
            }
            con.Close();
            foreach (var movie in movies_mostViewd)
            {
                load_mostViewd_every_genre_byId(movie.Mid);
            }
        }

        public void load_latest_Review()
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }
            string query2 = @"select top 5 Movies.Mid,Movies.Name as MovieName,Movies.ReleaseYear,Movies.PosterURL,Movies.PhotoURL,[User].Uid,[User].Name,
 Review.Rid,Review.Message,Review.Rating,Review.ReviewDate from Movies inner join Review on Movies.Mid =
 Review.Mid inner join [User] on [User].Uid = Review.Uid order by Review.Rid desc";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            if (reader2.HasRows)
            {
                while (reader2.Read())
                {

                    movies_Review.Add(new Review(reader2["Mid"].ToString(), reader2["MovieName"].ToString(),
                        reader2["ReleaseYear"].ToString(), reader2["PosterURL"].ToString(), reader2["PhotoURL"].ToString(),
                        reader2["Uid"].ToString(), reader2["Name"].ToString(), reader2["Rid"].ToString(),
                        reader2["Message"].ToString(), reader2["Rating"].ToString(), reader2["ReviewDate"].ToString()));
                }
            }
            con.Close();
        }

    }
}