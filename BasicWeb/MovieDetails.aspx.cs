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
    public partial class MovieDetails : System.Web.UI.Page
    {
        public string Mid, directors = "", genre = "",Fid,FimageURL,Fname;
        public List<Movies> movie_info = new List<Movies>();
        public List<Cast> movie_cast = new List<Cast>();
        public List<Review> movie_review = new List<Review>();
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //ImageUser.ImageUrl = "/images/User/hridoy.jpg";
            if (Request.QueryString.AllKeys.Contains("Mid") || Request.QueryString.AllKeys.Contains("action"))
            {
                Mid = Request.QueryString["Mid"];
                if (check_movie_validity())
                {
                    load_movie_info();
                    load_movie_cast();
                    load_movie_review();
                    load_movie_directors();
                    load_movie_genre();
                    MovieName.Text = movie_info[0].Name + " (" + movie_info[0].ReleaseYear + ")";
                    MovieDescription.Text = movie_info[0].StoryLine;
                    if (Session["id"] == null || Session["id"].ToString().Equals(""))
                    {
                        
                    }
                    else
                    {
                        if (check_watchList_button())
                        {
                            btnAddtoWatch.Text = "Cancel from Watch List";
                        }
                    }
                }
                else
                {
                    Response.Redirect("Error.aspx");
                }

                /*string action = Request.QueryString["action"];

                if (action.Equals("add"))
                {
                    //add_to_cart(pro_id);
                }*/
                //Response.Write("<script>alert('" + Mid + "');</script>");
            }
            else
            {
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnSuggestFriend_Click(object sender, EventArgs e)
        {
            SearchBox.Visible = true;
            btnSearchButton.Visible = true;
        }

        public bool check_movie_validity()
        {
            try
            {
                movie_info.Clear();
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }

                string query = @"Select * from Movies where Mid = " + Mid;
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    con.Close();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        public void load_movie_info()
        {
            try
            {
                movie_info.Clear();
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }

                string query = @"Select Name,Category, [Description],
                    PosterURL,PhotoURL,ReleaseYear,StudioName,Runtime,Ratings,NoOfReview,NoOfView,
                    TrailerURL,EmbedURL,[Language],StoryLine  from Movies inner join MovieGenre on
                    MovieGenre.Mid = Movies.Mid inner join Genre on Genre.Gid = MovieGenre.Gid where
                    Movies.Mid=" + Mid;
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        movie_info.Add(new Movies(reader["Name"].ToString(), reader["Category"].ToString(),
                            reader["Description"].ToString(), reader["PosterURL"].ToString(), reader["PhotoURL"].ToString(),
                            reader["ReleaseYear"].ToString(), reader["StudioName"].ToString(), reader["RunTime"].ToString(),
                            reader["Ratings"].ToString(), reader["NoOfReview"].ToString(), reader["NoOfView"].ToString(), reader["TrailerURL"].ToString(),
                            reader["EmbedURL"].ToString(), reader["Language"].ToString(), reader["StoryLine"].ToString()));
                    }
                }
                con.Close();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        public void load_movie_cast()
        {
            try
            {
                movie_cast.Clear();
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }

                string query = @"Select [Cast].Cid,[Cast].Name,MovieCast.RoleName from [Cast] inner join MovieCast
on MovieCast.Cid = [Cast].Cid where MovieCast.Mid = " + Mid;
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        movie_cast.Add(new Cast(reader["Cid"].ToString(), reader["Name"].ToString(), reader["RoleName"].ToString()));
                    }
                }
                con.Close();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        public void load_movie_review()
        {
            try
            {
                movie_review.Clear();
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }

                string query = @"Select [User].Uid,[User].Name,[User].PhotoURL,Review.Rating,Review.[Message],Review.ReviewDate from Review
inner join [User] on [User].[Uid] = Review.Uid where Review.Mid = " + Mid;
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        movie_review.Add(new Review(reader["Uid"].ToString(), reader["Name"].ToString(), reader["PhotoURL"].ToString(),
                            reader["Rating"].ToString(), reader["Message"].ToString(), reader["ReviewDate"].ToString()));
                    }
                }
                con.Close();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["user"].Equals(""))
            {
                Session["link"] = "MovieDetails.aspx?Mid=" + Mid;
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (Message.Text.Equals("") || Rating.Text.Equals(""))
                {
                    Response.Write("<script>alert('Field can not be empty');</script>");
                }
                else if (!Message.Text.Equals("") && (Convert.ToInt32(Rating.Text) < 7))
                {
                    Response.Write("<script>alert('Not saved.Kesa laga mera majak');</script>");
                   // Response.AddHeader("REFRESH", "3;URL=http://MovieDetails.aspx");
                }
                else
                {
                    if (store_user_review() && update_noOfReview())
                    {
                        Response.Write("<script>alert('Successfully Saved');</script>");
                        Rating.Text = "";
                        Message.Text = "";
                        load_movie_review();
                        load_movie_info();
                    }
                    else
                    {
                        Response.Write("<script>alert('Could not Store Review');</script>");
                    }
                }
            }
        }

        public void load_movie_directors()
        {
            try
            {
                directors = "";
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }

                string query = @"Select Directors.Name from MovieDirectors inner join Directors on MovieDirectors.Did = 
Directors.Did where MovieDirectors.Mid = " + Mid;
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        directors += reader["Name"].ToString() + ", ";
                    }
                }
                con.Close();
                directors = directors.Remove(directors.Length - 2);

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
                genre = "";
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }

                string query = @"Select Genre.Title from MovieGenre inner join Genre on MovieGenre.Gid = Genre.Gid where
                    MovieGenre.Mid = " + Mid;
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        genre += reader["Title"].ToString() + ", ";
                    }
                }
                con.Close();
                genre = genre.Remove(genre.Length - 2);

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        public bool store_user_review()
        { 
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = @"Insert into Review(Mid,[Uid],Rating,[Message],ReviewDate)
                    Values(@Mid,@Uid,@Rating,@Message,@Date)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Mid", Mid);
                cmd.Parameters.AddWithValue("@Uid", Session["id"].ToString());
                cmd.Parameters.AddWithValue("@Rating", Rating.Text.Trim());
                cmd.Parameters.AddWithValue("@Message", Message.Text.Trim());
                cmd.Parameters.AddWithValue("@Date", getCurrentDate());


                if (cmd.ExecuteNonQuery() > 0)
                {
                    con.Close();
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        protected void btnAddtoWatch_Click(object sender, EventArgs e)
        {
            if (Session["id"] == null || Session["id"].ToString().Equals(""))
            {
                Session["link"] = "MovieDetails.aspx?Mid=" + Mid;
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (btnAddtoWatch.Text.Equals("Add to watch list"))
                {
                    if (store_user_watchList())
                    {
                        btnAddtoWatch.Text = "Cancel from Watch List";
                    }
                }
                else if (btnAddtoWatch.Text.Equals("Cancel from Watch List"))
                {
                    if (delete_user_watchList())
                    {
                        btnAddtoWatch.Text = "Add to watch list";
                    }
                }
                
            }
        }

        public bool update_noOfReview()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = @"Update Movies set NoOfReview = NoOfReview+1 where Mid = @Mid";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Mid", Mid);


                if (cmd.ExecuteNonQuery() > 0)
                {
                    con.Close();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
        public string getCurrentDate()
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            return dateTime.ToString("dd/MM/yyyy");
        }

        protected void btnSuggestSearchFriend_Click(object sender, EventArgs e)
        {
            check_friend_found();
            
            
                if (Fid.Equals(Session["id"].ToString()))
                {
                    Response.Write("<script>alert('You can not suggest yourself');</script>");
                    
                }
                else
                {
                    if (store_friend_suggestion())
                    {
                        ImageUser.Visible = false;
                        NameUser.Visible = false;
                        Fid = "";
                        Fname = "";
                        FimageURL = "";
                        btnSuggestSearchFriend.Visible = false;
                        SearchBox.Text = "";
                        Response.Write("<script>alert('Suggessted Successfully');</script>");
                        

                    }
                }
            
        }

        public bool store_friend_suggestion()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = @"Insert into FriendSuggestion(Mid,Sender,Receiver,Date)
                    Values(@Mid,@Uid,@Fid,@Date)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Mid", Mid);
                cmd.Parameters.AddWithValue("@Uid", Session["id"].ToString());
                cmd.Parameters.AddWithValue("@Fid", Fid);
                cmd.Parameters.AddWithValue("@Date", getCurrentDate());


                if (cmd.ExecuteNonQuery() > 0)
                {
                    con.Close();
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        public bool store_user_watchList()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = @"Insert into Queue(Mid,[Uid],[Date]) Values (@Mid,@Uid,@Date)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Mid", Mid);
                cmd.Parameters.AddWithValue("@Uid", Session["id"].ToString());
                cmd.Parameters.AddWithValue("@Date", getCurrentDate());


                if (cmd.ExecuteNonQuery() > 0)
                {
                    con.Close();
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        protected void btnSearchButton_Click(object sender, EventArgs e)
        {
            if (Session["id"] == null || Session["id"].ToString().Equals(""))
            {
                Session["link"] = "MovieDetails.aspx?Mid=" + Mid;
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (SearchBox.Text.Equals(""))
                {

                }
                else
                {
                    check_friend_found();
                    if(Fid.Equals("") && Fname.Equals("") && FimageURL.Equals(""))
                    {
                        MessageNotFound.Visible = true;
                    }
                    else
                    {
                        ImageUser.Visible = true;
                        NameUser.Visible = true;
                        ImageUser.ImageUrl = FimageURL;
                        NameUser.Text = Fname;
                        btnSuggestSearchFriend.Visible = true;
                    }
                }
                
            }
            
        }

        public void check_friend_found()
        {
            try
            {
                
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }

                string query = @"Select top 1 [Uid],Name,PhotoURL from [User] where Name Like '%"+SearchBox.Text.Trim()+"%' or Email Like '%"+SearchBox.Text.Trim()+"%'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Fid = reader["Uid"].ToString();
                        Fname = reader["name"].ToString();
                        FimageURL = reader["PhotoURL"].ToString();
                    }
                }
                con.Close();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        public bool delete_user_watchList()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = @"Delete from Queue Where Mid = "+Mid+ " and Uid = "+Session["id"].ToString();
                SqlCommand cmd = new SqlCommand(query, con);
                


                if (cmd.ExecuteNonQuery() > 0)
                {
                    con.Close();
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
        public bool check_watchList_button()
        {
            try
            {
                
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }

                string query = @"Select * from Queue where Mid = "+Mid+" and Uid = "+Session["id"].ToString();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    con.Close();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Response.Write(" < script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
    }
}