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
    public partial class About : Page
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
                        reader["Ratings"].ToString(), reader["NoOfReview"].ToString(), reader["NoOfView"].ToString(), reader["TrailerURL"].ToString()));
                }
            }
            con.Close();

        }


    }
}
