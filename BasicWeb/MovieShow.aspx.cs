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
    public partial class MovieShow : System.Web.UI.Page
    {
        string prev_year = "Select", prev_sortkey = "Most Recent";
        public List<Category> category_count = new List<Category>();
        public List<string> releseYear = new List<string>();
        public List<Movies> movie_info = new List<Movies>();
        public List<Genre> movie_genre = new List<Genre>();
        public List<string> movie_info_genre = new List<string>();
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page.IsPostBack)
            {

                int yr;
                string year = releaseYearList.SelectedItem.Text;
                string sortkey = SortList.SelectedItem.Text;

                if (!sortkey.Equals(prev_sortkey))
                {
                    releaseYearList.SelectedIndex = 0;
                }

                if (!year.Equals(prev_year))
                {
                    if (year.Equals("Select"))
                    {

                    }
                    else
                    {
                        yr = Convert.ToInt32(year);
                        for (int y = 1980; y <= 2050; y++)
                        {
                            if (yr == y)
                            {
                                load_movie_info_byYear(yr.ToString());
                            }
                        }
                    }

                }
                else
                {
                    if (sortkey.Equals("Most Recent"))
                    {
                        load_movie_info("Most Recent");
                    }
                    else if (sortkey.Equals("Most Popular"))
                    {
                        load_movie_info("Most Popular");
                    }
                    else if (sortkey.Equals("Most Viewed"))
                    {
                        load_movie_info("Most Viewed");
                    }
                    else if (sortkey.Equals("Suggested For you"))
                    {
                        load_movie_info("Suggested For you");
                    }


                }
                prev_sortkey = sortkey;
                prev_year = year;
                load_category_count();
                load_movie_genre();

            }
            else
            {

                prev_year = "Select"; prev_sortkey = "Most Recent";
                load_movie_info();
                load_category_count();
                load_releaseYear();
                load_movie_genre();

                if (Request.QueryString.AllKeys.Contains("Category"))
                {
                    string category = Request.QueryString["Category"];
                    load_movie_byCategory(category);
                }
                if (Request.QueryString.AllKeys.Contains("Gid"))
                {
                    string gid = Request.QueryString["Gid"];
                    load_movie_info_byGenre(gid);
                }
            }

        }
        public void load_category_count()
        {
            try
            {

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }

                string query = @"Select Category,COUNT(Category) as Count from Movies group by Category order by COUNT(Category) desc";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        category_count.Add(new Category(reader["Category"].ToString(),
                            reader["Count"].ToString()));

                    }
                }
                con.Close();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        public void load_movie_byCategory(string category)
        {
            try
            {
                movie_info.Clear();
                movie_info_genre.Clear();
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }

                string query = @"Select Movies.Mid,Movies.Name,Movies.Category,Movies.PosterURL,Movies.ReleaseYear,Movies.Ratings from Movies where Category = '" + category + "' order by Ratings desc";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        movie_info.Add(new Movies(reader["Mid"].ToString(), reader["Name"].ToString(),
                            reader["Category"].ToString(), reader["PosterURL"].ToString(), reader["ReleaseYear"].ToString(),
                            reader["Ratings"].ToString()));

                    }
                }
                con.Close();
                foreach (var movie in movie_info)
                {
                    load_every_genre_byId(movie.Mid);
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        public void load_movie_info_byGenre(string gid)
        {
            try
            {
                movie_info.Clear();
                movie_info_genre.Clear();
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }

                string query = @" Select Movies.Mid,Movies.Name,Movies.Category,Movies.PosterURL,Movies.ReleaseYear,Movies.Ratings from Movies inner join 
 MovieGenre on Movies.Mid = MovieGenre.Mid where MovieGenre.Gid = " + gid;
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        movie_info.Add(new Movies(reader["Mid"].ToString(), reader["Name"].ToString(),
                            reader["Category"].ToString(), reader["PosterURL"].ToString(), reader["ReleaseYear"].ToString(),
                            reader["Ratings"].ToString()));

                    }
                }
                con.Close();
                foreach (var movie in movie_info)
                {
                    load_every_genre_byId(movie.Mid);
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        public void load_releaseYear()
        {
            try
            {
                releseYear.Add("Select");
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }

                string query = @"Select distinct ReleaseYear from Movies order by ReleaseYear desc";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        releseYear.Add(reader["ReleaseYear"].ToString());

                    }
                }
                con.Close();
                releaseYearList.DataSource = releseYear; // <-- Get your data from somewhere.
                releaseYearList.DataBind();
                //releaseYearList.SelectedValue = releseYear[0].ToString();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        public void load_movie_info(string key = "")
        {
            try
            {
                string query;
                if (key.Equals("Most Recent"))
                {
                    query = @"Select Movies.Mid,Movies.Name,Movies.Category,Movies.PosterURL,Movies.ReleaseYear,Movies.Ratings from Movies order by ReleaseYear desc, Mid desc";
                }
                else if (key.Equals("Most Popular"))
                {
                    query = @"Select Movies.Mid,Movies.Name,Movies.Category,Movies.PosterURL,Movies.ReleaseYear,Movies.Ratings from Movies order by Ratings desc";
                }
                else if (key.Equals("Most Viewed"))
                {
                    query = @"Select Movies.Mid,Movies.Name,Movies.Category,Movies.PosterURL,Movies.ReleaseYear,Movies.Ratings from Movies order by NoOfView desc";
                }
                else if (key.Equals("Suggested For you"))
                {
                    // this section will show movies according to user's choices(genre)
                    //1. check if user is logged in or not.if login then fetch user choices,otherwise just show default movies
                    if (Session["user"] == null || Session["user"].ToString() == "")
                    {
                        query = @"Select Movies.Mid,Movies.Name,Movies.Category,Movies.PosterURL,Movies.ReleaseYear,Movies.Ratings from Movies order by ReleaseYear desc, Mid desc";
                    }
                    else
                    {
                        //user has logged in
                        /*query = @"Select Movies.Mid,Movies.Name,Movies.Category,Movies.PosterURL,Movies.ReleaseYear,Movies.Ratings from Movies where Mid in(
                        select distinct Mid from MovieGenre where MovieGenre.Gid in (select UserChoice.Gid from UserChoice where Uid = "+Session["id"].ToString()+")) order by Movies.ReleaseYear desc";*/
                        query = @"select Movies.Mid,Movies.Name,Movies.Category,Movies.PosterURL,Movies.ReleaseYear,Movies.Ratings 
                        from Movies where Mid in ((select distinct Mid from MovieGenre where MovieGenre.Gid in(
                        select Gid from UserChoice where Uid = "+Session["id"].ToString()+" )) except (select Mid from ViewHistory where ViewHistory.Uid = "+Session["id"].ToString()+")) order by Movies.ReleaseYear desc";

                    }

                }
                else
                {
                    query = @" Select Movies.Mid,Movies.Name,Movies.Category,Movies.PosterURL,Movies.ReleaseYear,Movies.Ratings from Movies order by ReleaseYear desc, Mid desc";
                }
                movie_info.Clear();
                movie_info_genre.Clear();
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }


                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        movie_info.Add(new Movies(reader["Mid"].ToString(), reader["Name"].ToString(),
                            reader["Category"].ToString(), reader["PosterURL"].ToString(), reader["ReleaseYear"].ToString(),
                            reader["Ratings"].ToString()));

                    }
                }
                con.Close();

                foreach (var movie in movie_info)
                {
                    load_every_genre_byId(movie.Mid);
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        public void load_every_genre_byId(string mid)
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
                movie_info_genre.Add(tempGenre);

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        public void load_movie_genre()
        {
            try
            {
                movie_genre.Clear();
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }

                string query = @"Select distinct MovieGenre.Gid,Genre.Title,COUNT(MovieGenre.Gid) as MovieCount from MovieGenre inner join Genre
                on MovieGenre.Gid = Genre.Gid group by MovieGenre.Gid,Genre.Title";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        movie_genre.Add(new Genre(reader["Gid"].ToString(), reader["Title"].ToString(),
                            reader["MovieCount"].ToString()));

                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        public void load_movie_info_byYear(string year)
        {
            try
            {
                movie_info.Clear();
                movie_info_genre.Clear();
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }

                string query = @"Select Movies.Mid,Movies.Name,Movies.Category,Movies.PosterURL,Movies.ReleaseYear,Movies.Ratings from Movies where ReleaseYear = " + year + " order by Ratings desc";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        movie_info.Add(new Movies(reader["Mid"].ToString(), reader["Name"].ToString(),
                            reader["Category"].ToString(), reader["PosterURL"].ToString(), reader["ReleaseYear"].ToString(),
                            reader["Ratings"].ToString()));

                    }
                }
                con.Close();
                foreach (var movie in movie_info)
                {
                    load_every_genre_byId(movie.Mid);
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void releaseYearList_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
    }
}