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
    public partial class Profile : System.Web.UI.Page
    {
        public string id, name, status, email, gender, phone, createdDate, noOfMovies, noOfHours, noOfwatchList,
            photourl, noOfReviews, noOfFriendSuggestion, @Uid;
        public List<string> user_typeList = new List<string>();
        public string[] navDrawerHeader = new string[5];
        public string[] navDrawerDetails = new string[5];
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        
        

        public bool build_sql_query_without_dataset(string query)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
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

        public DataTable build_sql_query_with_dataset(string query)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return null;
            }
        }

        protected void LinkButton2_Command(object sender, CommandEventArgs e)
        {
            //Mark as Watched in Watch List
            String MID = e.CommandArgument.ToString();
            // first i have to check if this movie i have already watchded or not
            string query = "select * from ViewHistory where Mid = " + MID + " and Uid = " + Session["id"].ToString();
            DataTable dt = build_sql_query_with_dataset(query);
            if (dt.Rows.Count > 0)
            {
                Response.Write("<script>alert('This movie has already watched by you');</script>");
            }
            else
            {
                if (remove_from_watchList(MID) && store_in_WatchedList(MID))
                {
                    GridView3.DataBind();
                    GridView1.DataBind();
                    increment_NoOfView(MID);
                    update_noOfWatch();
                    update_RuntimeWatch();
                    //update user Choice movie genre
                    update_userChoice_genre(MID);
                    load_user_typeList();
                    Response.Write("<script>alert('Successfully Added in Watched List');</script>");
                }
            }
        }
        protected void RemoveFromFriendSuggestion_Command(object sender, CommandEventArgs e)
        {
            //Remove link button in Friend Suggestion
            String FID = e.CommandArgument.ToString();
            if (remove_from_friend_suggestion(FID))
            {
                Response.Write("<script>alert('Successfully Removed from FriendSuggestion');</script>");
                GridView2.DataBind();
                load_noOfFriendSuggestion();
            }
        }

        protected void MarkAsWatchedFromFriendSuggestion_Command(object sender, CommandEventArgs e)
        {
            //Mark as Watched link button in Friend suggestion
            String MID = e.CommandArgument.ToString();

            add_movie_watchedList_from_FriendSuggestion(MID);
            

        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            //Remove linkButton in Watch List
            String MID = e.CommandArgument.ToString();
            if (remove_from_watchList(MID))
            {
                Response.Write("<script>alert('Removed Successfully from Watch List');</script>");
                GridView3.DataBind();
            }

        }

        public void add_movie_watchedList_from_FriendSuggestion(string mid)
        {
            // first i have to check if this movie i have already watchded or not
            string query = "select * from ViewHistory where Mid = " + mid + " and Uid = " + Session["id"].ToString();
            DataTable dt = build_sql_query_with_dataset(query);
            if (dt.Rows.Count > 0)
            {
                Response.Write("<script>alert('This movie has already watched by you');</script>");
            }
            else
            {
                // add to watched history in ViewHistory table
                if (store_in_WatchedList(mid))
                {
                    
                    increment_NoOfView(mid);
                    //update user Choice movie genre
                    update_userChoice_genre(mid);
                    load_user_typeList();
                    GridView3.DataBind();
                    GridView2.DataBind();
                    Response.Write("<script>alert('Successfully added to watched list');</script>");
                }

            }
        }

        protected void btnWacthedMovieInfoSearch_Click(object sender, EventArgs e)
        {
            //this method will filter or search accoring to search key and will show in movie info table
            string query = "SELECT Movies.Mid, Movies.Name, Movies.Category, Movies.ReleaseYear, Movies.Description,Movies.Runtime, Movies.NoOfView, Movies.Ratings, Movies.PosterURL, Movies.NoOfReview, CONVERT(varchar,ViewHistory.Date,105) as Date FROM Movies INNER JOIN ViewHistory ON Movies.Mid = ViewHistory.Mid WHERE ViewHistory.Uid = " + Session["id"].ToString();
            if (tbWatchedMovieInfoSearch.Text == "")
            {
                query += " order by CONVERT(DateTime, ViewHistory.Date,105) DESC";
            }
            else if (tbWatchedMovieInfoSearch.Text == "#na")
            {
                query += " order by Movies.Name";    //movie name according ascending order (A-Z)
            }
            else if (tbWatchedMovieInfoSearch.Text == "#nd")
            {
                query += " order by Movies.Name desc";   //movie name according descending order (Z-A)
            }
            else if (tbWatchedMovieInfoSearch.Text == "#ia")
                query += " order by Movies.Mid";                //movie id according asceding order
            else if (tbWatchedMovieInfoSearch.Text == "#id")
                query += " order by Movies.Mid desc";           //movie id according descending order
            else if (tbWatchedMovieInfoSearch.Text == "#ya")
                query += " order by Movies.ReleaseYear";        //release year according asceding order
            else if (tbWatchedMovieInfoSearch.Text == "#yd")
                query += " order by Movies.ReleaseYear desc";   //release year according descending order
            else if (tbWatchedMovieInfoSearch.Text == "#Ra")
                query += " order by Movies.Ratings";            //Rating according asceding order
            else if (tbWatchedMovieInfoSearch.Text == "#Rd")
                query += " order by Movies.Ratings desc";       //Rating according descending order
            else if (tbWatchedMovieInfoSearch.Text == "#ra")
                query += " order by Movies.Runtime";            //runtime according asceding order
            else if (tbWatchedMovieInfoSearch.Text == "#rd")
                query += " order by Movies.Runtime desc";       //runtime according descending order
            else if (tbWatchedMovieInfoSearch.Text == "#sa")
                query += " order by Movies.StudioName";         //studioname according asceding order (A-Z)
            else if (tbWatchedMovieInfoSearch.Text == "#sd")
                query += " order by Movies.StudioName desc";    //studioname according descending order (Z-A)
            else if (tbWatchedMovieInfoSearch.Text == "#va")
                query += " order by Movies.NoOfView";           //views according ascending order
            else if (tbWatchedMovieInfoSearch.Text == "#vd")
                query += " order by Movies.NoOfView";           //views according descending order
            else
            {
                string key = tbWatchedMovieInfoSearch.Text.Trim();
                query += " and ( Movies.name like '%" + key + "%' or Movies.Category like '%" + key + "%' or Movies.ReleaseYear like '%" + key + "%' or Movies.Description like '%" + key + "%' or Movies.Ratings like '%" + key + "%' or Movies.Language like '%" + key + "%' or Movies.Runtime like '%" + key + "%' or Movies.StudioName like '%" + key + "%' or Movies.Mid like '%" + key + "%' or ViewHistory.Date like '%" + key + "%' )";
            }
            //data fetching from database
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            nav_activation(3);              // this will activate Watched List nav
            GridView1.DataSourceID = null;
            GridView1.DataSource = dt;
            GridView1.DataBind();
            con.Close();
            
        }

        protected void btnFriendSuggestionSearch_Click(object sender, EventArgs e)
        {
            //this method will filter or search accoring to search key and will show in Friend suggestion movie info table
            string query = "SELECT Movies.Mid, Movies.Name, Movies.Category, Movies.ReleaseYear, Movies.Description, Movies.NoOfView, Movies.Ratings, Movies.PosterURL, Movies.NoOfReview, FriendSuggestion.Fid ,CONVERT(varchar,FriendSuggestion.Date,105) as Date ,[User].Name as FriendName FROM Movies INNER JOIN FriendSuggestion ON Movies.Mid = FriendSuggestion.Mid inner join [User] on [User].Uid = FriendSuggestion.Sender WHERE (FriendSuggestion.Receiver = " + Session["id"].ToString() + ") ";
            if (tbFriendSuggestionSearch.Text == "")
                query += " order by CONVERT(DateTime, FriendSuggestion.Date,105) DESC";
            else if (tbFriendSuggestionSearch.Text == "#na")
            {
                query += " order by Movies.Name";    //movie name according ascending order (A-Z)
            }
            else if (tbFriendSuggestionSearch.Text == "#nd")
            {
                query += " order by Movies.Name desc";   //movie name according descending order (Z-A)
            }
            else if (tbFriendSuggestionSearch.Text == "#ia")
                query += " order by Movies.Mid";                //movie id according asceding order
            else if (tbFriendSuggestionSearch.Text == "#id")
                query += " order by Movies.Mid desc";           //movie id according descending order
            else if (tbFriendSuggestionSearch.Text == "#ya")
                query += " order by Movies.ReleaseYear";        //release year according asceding order
            else if (tbFriendSuggestionSearch.Text == "#yd")
                query += " order by Movies.ReleaseYear desc";   //release year according descending order
            else if (tbFriendSuggestionSearch.Text == "#Ra")
                query += " order by Movies.Ratings";            //Rating according asceding order
            else if (tbFriendSuggestionSearch.Text == "#Rd")
                query += " order by Movies.Ratings desc";       //Rating according descending order
            else if (tbFriendSuggestionSearch.Text == "#va")
                query += " order by Movies.NoOfView";           //views according ascending order
            else if (tbFriendSuggestionSearch.Text == "#vd")
                query += " order by Movies.NoOfView";
            else
            {
                string key = tbFriendSuggestionSearch.Text.Trim();
                query += " and ( Movies.Name like '%" + key + "%' or Movies.Category like '%" + key + "%' or FriendSuggestion.Date like '%" + key + "%' or Movies.ReleaseYear like '%" + key + "%' or Movies.Description like '%" + key + "%' or [User].Name like '%" + key + "%')";
            }
            //data fetching from database
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            nav_activation(2);      // Friend Suggestion nav will activate
            GridView2.DataSourceID = null;
            GridView2.DataSource = dt;
            GridView2.DataBind();
            con.Close();
            
        }

        protected void btnWatchListSearch_Click(object sender, EventArgs e)
        {
            //this method will search movie info according to watch list
            string query = "SELECT Movies.Mid, Movies.Name, Movies.Category, Movies.ReleaseYear,Movies.Runtime, Movies.Description, Movies.NoOfView, Movies.Ratings, Movies.PosterURL, Movies.NoOfReview, CONVERT(varchar,Queue.Date,105) as Date FROM Movies INNER JOIN Queue ON Movies.Mid = Queue.Mid WHERE (Queue.Uid = " + Session["id"].ToString() + ") ";
            if (tbWatchListSearch.Text == "")
                query += "order by CONVERT(DateTime, Queue.Date,105) DESC";
            else if (tbWatchListSearch.Text == "#na")
            {
                query += " order by Movies.Name";    //movie name according ascending order (A-Z)
            }
            else if (tbWatchListSearch.Text == "#nd")
            {
                query += " order by Movies.Name desc";   //movie name according descending order (Z-A)
            }
            else if (tbWatchListSearch.Text == "#ia")
                query += " order by Movies.Mid";                //movie id according asceding order
            else if (tbWatchListSearch.Text == "#id")
                query += " order by Movies.Mid desc";           //movie id according descending order
            else if (tbWatchListSearch.Text == "#ya")
                query += " order by Movies.ReleaseYear";        //release year according asceding order
            else if (tbWatchListSearch.Text == "#yd")
                query += " order by Movies.ReleaseYear desc";   //release year according descending order
            else if (tbWatchListSearch.Text == "#ra")
                query += " order by Movies.Runtime";            //runtime according asceding order
            else if (tbWatchListSearch.Text == "#rd")
                query += " order by Movies.Runtime desc";       //runtime according descending order
            else if (tbWatchListSearch.Text == "#Ra")
                query += " order by Movies.Ratings";            //Rating according asceding order
            else if (tbWatchListSearch.Text == "#Rd")
                query += " order by Movies.Ratings desc";       //Rating according descending order
            else if (tbWatchListSearch.Text == "#va")
                query += " order by Movies.NoOfView";           //views according ascending order
            else if (tbWatchListSearch.Text == "#vd")
                query += " order by Movies.NoOfView";
            else
            {
                string key = tbWatchListSearch.Text.Trim();
                query += "and (Movies.Name like '%" + key + "%' or Movies.Mid like '%" + key + "%' or Movies.Category like '%" + key + "%' or Movies.ReleaseYear like '%" + key + "%' or Movies.Runtime like '%" + key + "%' or Movies.Description like '%" + key + "%' or Movies.NoOfView like '%" + key + "%' or Movies.NoOfReview like '%" + key + "%' or Queue.Date like '%" + key + "%')";

            }
            //data fetching from database
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            nav_activation(1);          // watch list nav will activate
            GridView3.DataSourceID = null;
            GridView3.DataSource = dt;
            GridView3.DataBind();
            con.Close();
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["user"].Equals(""))
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                string queryForWatchList = "SELECT Movies.Mid, Movies.Name, Movies.Category, Movies.ReleaseYear,Movies.Runtime, Movies.Description, Movies.NoOfView, Movies.Ratings, Movies.PosterURL, Movies.NoOfReview, CONVERT(varchar,Queue.Date,105) as Date FROM Movies INNER JOIN Queue ON Movies.Mid = Queue.Mid WHERE (Queue.Uid = " + Session["id"].ToString() + ") order by CONVERT(DateTime, Queue.Date,105) DESC";
                string queryForFriendSuggestion = "SELECT Movies.Mid, Movies.Name, Movies.Category, Movies.ReleaseYear, Movies.Description, Movies.NoOfView, Movies.Ratings, Movies.PosterURL, Movies.NoOfReview, FriendSuggestion.Fid ,CONVERT(varchar,FriendSuggestion.Date,105) as Date ,[User].Name as FriendName FROM Movies INNER JOIN FriendSuggestion ON Movies.Mid = FriendSuggestion.Mid inner join [User] on [User].Uid = FriendSuggestion.Sender WHERE (FriendSuggestion.Receiver = " + Session["id"].ToString() + ") order by CONVERT(DateTime, FriendSuggestion.Date,105) DESC";
                string queryForAlreadyWatched = "SELECT Movies.Mid, Movies.Name, Movies.Category, Movies.ReleaseYear, Movies.Description,Movies.Runtime, Movies.NoOfView, Movies.Ratings, Movies.PosterURL, Movies.NoOfReview, CONVERT(varchar,ViewHistory.Date,105) as Date FROM Movies INNER JOIN ViewHistory ON Movies.Mid = ViewHistory.Mid WHERE ViewHistory.Uid = " + Session["id"].ToString() + " order by CONVERT(DateTime, ViewHistory.Date,105) DESC";
                DataTable dt1 = build_sql_query_with_dataset(queryForWatchList);
                DataTable dt2 = build_sql_query_with_dataset(queryForFriendSuggestion);
                DataTable dt3 = build_sql_query_with_dataset(queryForAlreadyWatched);
                update_noOfWatch();
                update_RuntimeWatch();
                nav_activation(1);
                @Uid = Session["id"].ToString();
                GridView3.DataSourceID = null;
                GridView3.DataSource = dt1;
                GridView3.DataBind();

                GridView2.DataSourceID = null;
                GridView2.DataSource = dt2;
                GridView2.DataBind();

                GridView1.DataSourceID = null;
                GridView1.DataSource = dt3;
                GridView1.DataBind();
                //GridView1.UseAccessibleHeader = true;
                //GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                id = Session["id"].ToString();
                load_user_info();
                load_noOfWatchList();
                load_noOfReviews();
                load_noOfFriendSuggestion();
                load_user_typeList();

            }
        }
        // This method will activate a certain nav according to desire needs
        public void nav_activation(int index)
        {
            for(int i=1; i<5; i++)
            {
                if(i== index)
                {
                    navDrawerHeader[i] = " active";
                    navDrawerDetails[i] = " show active";
                }
                else
                {
                    navDrawerHeader[i] = " ";
                    navDrawerDetails[i] = " show";
                }
            }
        }

        public void update_userChoice_genre(string mid)
        {
            //1. fetch movie genre of that particular movie
            //2. check every genre that has already added to their profile(UserChoice table) or not
            //2.1 if already added that genre then just update it(increment PriorityCount of that genre)
            //2.2 else store that genre in UserChoice table with respect to Userid give PriorityCount = 1

            string query1 = "select * from MovieGenre where MovieGenre.Mid = " + mid;
            //Work 1
            DataTable genreTable =  build_sql_query_with_dataset(query1);
            for(int i=0; i<genreTable.Rows.Count; i++)
            {
                string query2 = "select * from UserChoice where Uid = "+Session["id"].ToString()+" and Gid = "+genreTable.Rows[i]["Gid"];
                DataTable userGenreResult = build_sql_query_with_dataset(query2);
                //Work 2
                if (userGenreResult.Rows.Count > 0)
                {
                    //Work 2.1
                    string query3 = "update UserChoice set PriorityCount = PriorityCount + 1 where Uid = " + Session["id"].ToString() + " and Gid = " + userGenreResult.Rows[0]["Gid"];
                    build_sql_query_without_dataset(query3);
                }
                else
                {
                    //Work 2.2
                    string query4 = "insert into UserChoice(Uid,Gid,PriorityCount) values('"+Session["id"].ToString()+"','"+ genreTable.Rows[0]["Gid"] + "',1)";
                    build_sql_query_without_dataset(query4);
                }
            }
        }
        public bool update_noOfWatch()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = @"Update [User] set NoOfWatch = (Select count(*) as CountMovie from ViewHistory where ViewHistory.Uid = " + id + ") where [User].Uid = " + id;
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

        public void increment_NoOfView(string mid)
        {
            string query = "update Movies set NoOfView = (Select NoOfView from Movies where Mid = "+mid+") + 1 where Mid = "+mid;
            build_sql_query_without_dataset(query);
        }

        public bool remove_from_friend_suggestion(string Fid)
        {
            // this method will delete friend suggestion movie from FriendSuggestion table
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = @"Delete from FriendSuggestion Where Fid = " + Fid + " and Uid = " + Session["id"].ToString();
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

        public bool update_RuntimeWatch()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = @"Update [User] set RunTimeWatch = (Select sum(Movies.Runtime) as TotalTime from Movies inner join ViewHistory on Movies.Mid = ViewHistory.Mid where ViewHistory.Uid = " + id + " ) where [User].Uid = " + id;
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
                Response.Write(" <script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        protected void btnMyReviewSearch_Click(object sender, EventArgs e)
        {
            //this method will search from MY Reviews table
            string query = "select Review.Rid,Movies.Mid,Movies.Ratings,Movies.Name,Review.Message,Review.Rating as MovieRating , CONVERT(varchar,Review.ReviewDate,105) as ReviewDate,Movies.ReleaseYear from Review inner join Movies on Movies.Mid = Review.Mid where Review.Uid =  "+Session["id"].ToString();
            if (tbMyReviewSearch.Text == "")
                query += " order by CONVERT(DateTime, Review.ReviewDate,105) DESC";
            else if (tbMyReviewSearch.Text == "#na")
                query += " order by Movies.Name";
            else if (tbMyReviewSearch.Text == "#nd")
                query += " order by Movies.Name desc";
            else if (tbMyReviewSearch.Text == "#ra")
                query += " order by Review.Rating";
            else if (tbMyReviewSearch.Text == "#rd")
                query += " order by Review.Rating desc";
            else
            {
                string key = tbMyReviewSearch.Text.Trim();
                query += " and (Movies.Mid like '%"+key+ "%' or Movies.Name like '%" + key + "%' or Movies.ReleaseYear like '%" + key + "%' or Review.ReviewDate like '%" + key + "%' or Review.Message like '%" + key + "%' or Review.Rating like '%" + key + "%')";
            }
            //data fetching from database
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            nav_activation(4);          // watch list nav will activate
            GridView4.DataSourceID = null;
            GridView4.DataSource = dt;
            GridView4.DataBind();
            con.Close();
        }

        public void load_user_info()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                string query = "Select Name,Email,Gender,Phone,Status,CreationDate,NoOfWatch,RunTimeWatch,PhotoURL from [User] where Uid = '" + id + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        name = dr.GetValue(0).ToString();
                        email = dr.GetValue(1).ToString();
                        gender = dr.GetValue(2).ToString();
                        phone = dr.GetValue(3).ToString();
                        status = dr.GetValue(4).ToString();
                        createdDate = dr.GetValue(5).ToString();
                        noOfMovies = dr.GetValue(6).ToString();
                        noOfHours = dr.GetValue(7).ToString();
                        photourl = dr.GetValue(8).ToString();
                    }
                }
                else {
                    Response.Write("<script>alert('Account info not found');</script>");
                }
                //modify noOfHours convert in hour and min

                int hour, min, temp;
                temp = Convert.ToInt32(noOfHours);
                hour = temp / 60;
                min = Convert.ToInt32(noOfHours) - hour * 60;
                noOfHours = hour + " Hours " + min + " min";

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</scrpit>");
            }
        }

        public void load_noOfWatchList()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                string query = "Select count(*) as NoOfMoviesInWatchList from Queue where Uid= '" + id + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        noOfwatchList = dr.GetValue(0).ToString();

                    }
                }
                else {
                    Response.Write("<script>alert('Account info not found');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</scrpit>");
            }
        }
        public void load_noOfReviews()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                string query = "Select count(*) as NoOfReview from Review where Uid= '" + id + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        noOfReviews = dr.GetValue(0).ToString();

                    }
                }
                else {
                    Response.Write("<script>alert('Account info not found');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</scrpit>");
            }
        }

        public void load_noOfFriendSuggestion()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                string query = "Select count(*) as NoOfSuggestion from FriendSuggestion where Receiver = '" + id + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        noOfFriendSuggestion = dr.GetValue(0).ToString();

                    }
                }
                else {
                    Response.Write("<script>alert('Account info not found');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</scrpit>");
            }
        }

        public void load_user_typeList()
        {
            try
            {
                user_typeList.Clear();
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                string query = "Select Genre.Title from UserChoice inner join Genre on UserChoice.Gid = Genre.Gid where UserChoice.Uid = '" + id + "' order by PriorityCount desc";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        user_typeList.Add(dr.GetValue(0).ToString());

                    }
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</scrpit>");
            }
        }

        public bool remove_from_watchList(string mid)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = @"Delete from Queue Where Mid = " + mid + " and Uid = " + Session["id"].ToString();
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

        public bool store_in_WatchedList(string mid)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = @"Insert into ViewHistory(Mid,[Uid],[Date]) Values (@Mid,@Uid,@Date)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Mid", mid);
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

        public void LinkButton_Command(Object sender, CommandEventArgs e)
        {
            // view details link button command
            String MID = e.CommandArgument.ToString();

            Response.Redirect("MovieDetails.aspx?Mid=" + MID);
        }

        public void MyReviewsRemove_Command(Object sender, CommandEventArgs e)
        {
            // view details link button command
            String RID = e.CommandArgument.ToString();

            // Delete Review from database
            //1. Firstly Delete remove using Rid from Review table
            //2. Decrement noOfReview in Movies table
            //3. Update NoOfReview in the profile/ call load_noOfReviews();
            decrement_noOfReviews(RID);
            delete_movie_review(RID);
            load_noOfReviews();
            nav_activation(4);
            GridView4.DataBind();
            
        }

        public void MyReviewsViewDetails_Command(Object sender, CommandEventArgs e)
        {
            // view details link button command
            String MID = e.CommandArgument.ToString();

            Response.Redirect("MovieDetails.aspx?Mid=" + MID);
        }
        public void delete_movie_review(string rid)
        {
            string query = "delete Review where Rid = "+rid;
            build_sql_query_without_dataset(query);
        }
        public void decrement_noOfReviews(string rid)
        {
            // firstly get movie id from Review Table
            string query1 = "select Mid from Review where Rid = "+rid;
            string mid = build_sql_query_with_dataset(query1).Rows[0]["Mid"].ToString();

            // decrement noOfReviwes from Movies table
            string query2 = "update Movies set NoOfReview = (Select NoOfReview from Movies where Mid = "+mid+") - 1 where Mid = "+mid;
            build_sql_query_without_dataset(query2);
        }

        public string getCurrentDate()
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            return dateTime.ToString("dd-MM-yyyy");
        }
    }

}