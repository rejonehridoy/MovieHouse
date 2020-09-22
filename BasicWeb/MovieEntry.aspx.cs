using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BasicWeb
{
    public partial class MovieEntry : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        string MovieId = "",CastId="",DirectorId="";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            store_new_movie();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //check the text boxes
            if (tbMovieName.Text == "" || tbRunTime.Text == "" || tbRating.Text == "" || tbEmbedURL.Text == ""
                || tbTrailerURL.Text == "" || tbDescription.Text == "" || tbStoryLine.Text == "")
            {
                Response.Write("<script>alert('Text Box must not be empty');</script>");
            }
            else
            {
                if(Path.GetFileName(FileUpload1.PostedFile.FileName) == "" && Path.GetFileName(FileUpload2.PostedFile.FileName) == "")
                {
                    // update without any poster and picture, mark this as 1
                    update_movie_info(1);
                }
                else if(Path.GetFileName(FileUpload1.PostedFile.FileName) != "" && Path.GetFileName(FileUpload2.PostedFile.FileName) == "")
                {
                    //poster is avaiable but picture not avaiable, mark this as 2
                    update_movie_info(2);
                }
                else if(Path.GetFileName(FileUpload1.PostedFile.FileName) == "" && Path.GetFileName(FileUpload2.PostedFile.FileName) != "")
                {
                    // poster is not avaiable but picture is avaiable, mark this as 3
                    update_movie_info(3);
                }
                else
                {
                    //both poster and picture are avaiable, mark this as 4
                    update_movie_info(4);
                }
                
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if(tbMid.Text == "")
            {
                Response.Write("<script>alert('Movie ID text box is empty');</script>");
            }
            else
            {
                Delete_movie_info(tbMid.Text);
            }
        }
        public void store_new_movie()
        {
            if (check_emptyField_MovieEntry())
            {
                // certain text boxes are empty
                Response.Write("<script>alert('Any Useful Textbox should not be empty');</script>");
            }
            else
            {
                // no useful fields are empty,now store the info in the database
                try
                {
                    //string filepath = "~/book_inventory/books1.png";
                    string Poster_filename = "images/" + Path.GetFileName(FileUpload1.PostedFile.FileName);
                    string Picture_filename = "images/" + Path.GetFileName(FileUpload2.PostedFile.FileName);
                    //FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                    //filepath = "~/book_inventory/" + filename;


                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    string query = @"Insert into Movies(Name,Category,Description,PosterURL,PhotoURL,ReleaseYear,Runtime,
StudioName,Ratings,Language,TrailerURL,StoryLine,EmbedURL) Values(@Name,@Category,@Description,
@PosterURL,@PhotoURL,@ReleaseYear,@Runtime,@StudioName,@Ratings,@Language,@TrailerURL,@StoryLine,@EmbedURL)";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@Name", tbMovieName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Category", ddlCategory.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@Description", tbDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@PosterURL", Poster_filename);
                    cmd.Parameters.AddWithValue("@PhotoURL", Picture_filename);
                    cmd.Parameters.AddWithValue("@ReleaseYear", ddlReleaseYear.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@Runtime", tbRunTime.Text.Trim());
                    cmd.Parameters.AddWithValue("@StudioName", ddlStudioName.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@Ratings", tbRating.Text.Trim());
                    cmd.Parameters.AddWithValue("@TrailerURL", tbTrailerURL.Text.Trim());
                    cmd.Parameters.AddWithValue("@StoryLine", tbStoryLine.Text.Trim());
                    cmd.Parameters.AddWithValue("@EmbedURL", tbEmbedURL.Text.Trim());
                    cmd.Parameters.AddWithValue("@Language", ddlLanguage.SelectedItem.Value);


                    cmd.ExecuteNonQuery();
                    con.Close();
                    store_movie_genre();
                    Response.Write("<script>alert('Movie added successfully.');</script>");
                    GridView1.DataBind();
                    //Clear_all_Text();
                    lbGenre.ClearSelection();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            
        }
        public bool check_emptyField_MovieEntry()
        {
            if(ddlCategory.SelectedIndex < 0)
                ddlCategory.Items.FindByValue("Hollywood").Selected = true;

            if(ddlLanguage.SelectedIndex < 0)
                ddlLanguage.Items.FindByValue("English").Selected = true;

            if(ddlReleaseYear.SelectedIndex < 0)
                ddlReleaseYear.Items.FindByValue("2020").Selected = true;

            if (ddlStudioName.SelectedIndex < 0)
                ddlStudioName.Items.FindByValue("Marvel Cinematic Universe").Selected = true;

            if (tbMovieName.Text == "" || tbRunTime.Text == ""  || tbRating.Text == "" || 
                tbTrailerURL.Text == "" || tbEmbedURL.Text == "" || tbDescription.Text == "" || 
                tbStoryLine.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void store_movie_genre()
        {
            try
            {
                string MovieId = get_Inserted_Mid();
                foreach (int i in lbGenre.GetSelectedIndices())
                {
                    
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    string query = @"Insert into MovieGenre(Gid,Mid) Values(@Gid,@Mid)";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@Gid", lbGenre.Items[i].Value);
                    cmd.Parameters.AddWithValue("@Mid",MovieId);
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
            catch(Exception ex)
            {

            }
            
            
        }
        public string get_Inserted_Mid()
        {
            string Mid = "";
            try
            {
                
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = @"Select Mid from Movies where TrailerURL LIKE '"+tbTrailerURL.Text.Trim()+"'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    Mid = dt.Rows[0]["Mid"].ToString();
                    //TextBox2.Text = dt.Rows[0]["book_name"].ToString();
                    //TextBox3.Text = dt.Rows[0]["publish_date"].ToString();
                    //TextBox9.Text = dt.Rows[0]["edition"].ToString();
                    //TextBox10.Text = dt.Rows[0]["book_cost"].ToString().Trim();
                    //TextBox11.Text = dt.Rows[0]["no_of_pages"].ToString().Trim();
                    //TextBox4.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    //TextBox5.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    //TextBox6.Text = dt.Rows[0]["book_description"].ToString();
                    //TextBox7.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString()));

                    //DropDownList1.SelectedValue = dt.Rows[0]["language"].ToString().Trim();
                    //DropDownList2.SelectedValue = dt.Rows[0]["publisher_name"].ToString().Trim();
                    //DropDownList3.SelectedValue = dt.Rows[0]["author_name"].ToString().Trim();

                    //ListBox1.ClearSelection();
                    //string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(',');
                    //for (int i = 0; i < genre.Length; i++)
                    //{
                    //    for (int j = 0; j < ListBox1.Items.Count; j++)
                    //    {
                    //        if (ListBox1.Items[j].ToString() == genre[i])
                    //        {
                    //            ListBox1.Items[j].Selected = true;

                    //        }
                    //    }
                    //}

                    //global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                    //global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                    //global_issued_books = global_actual_stock - global_current_stock;
                    //global_filepath = dt.Rows[0]["book_img_link"].ToString();

                }
                else
                {
                    Response.Write("<script>alert('Invalid Movie ID');</script>");
                }
                con.Close();
                return Mid;

            }
            catch (Exception ex)
            {
                return Mid;
            }   
        }
        public void update_movie_info(int key)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                SqlCommand cmd;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = "";

                if (key == 1)
                {
                    query = @"update Movies set Name = @Name, [Language] = @Language, Category = @Category, StudioName = @StudioName, 
                    ReleaseYear = @ReleaseYear, [Description] = @Description, StoryLine = @StoryLine, TrailerURL = @TrailerURL,
                    EmbedURL = @EmbedURL , Ratings = @Ratings , Runtime = @Runtime where mid = @mid";
                    cmd = new SqlCommand(query, con);

                }
                else if (key == 2)
                {
                    query = @"update Movies set Name = @Name, [Language] = @Language, Category = @Category, StudioName = @StudioName, 
                    ReleaseYear = @ReleaseYear, [Description] = @Description, StoryLine = @StoryLine, TrailerURL = @TrailerURL,
                    EmbedURL = @EmbedURL , Ratings = @Ratings, PosterURL = @PosterURL , Runtime = @Runtime where mid = @mid";
                    cmd = new SqlCommand(query, con);
                    string Poster_filename = "images/" + Path.GetFileName(FileUpload1.PostedFile.FileName);
                    cmd.Parameters.AddWithValue("@PosterURL", Poster_filename);
                }
                else if (key == 3)
                {
                    query = @"update Movies set Name = @Name, [Language] = @Language, Category = @Category, StudioName = @StudioName, 
                    ReleaseYear = @ReleaseYear, [Description] = @Description, StoryLine = @StoryLine, TrailerURL = @TrailerURL,
                    EmbedURL = @EmbedURL , Ratings = @Ratings, PhotoURL = @PhotoURL , Runtime = @Runtime where mid = @mid";
                    cmd = new SqlCommand(query, con);
                    string Picture_filename = "images/" + Path.GetFileName(FileUpload2.PostedFile.FileName);
                    cmd.Parameters.AddWithValue("@PhotoURL", Picture_filename);
                }
                else
                {
                    query = @"update Movies set Name = @Name, [Language] = @Language, Category = @Category, StudioName = @StudioName, 
                    ReleaseYear = @ReleaseYear, [Description] = @Description, StoryLine = @StoryLine, TrailerURL = @TrailerURL,
                    EmbedURL = @EmbedURL , Ratings = @Ratings, PosterURL = @PosterURL, PhotoURL = @PhotoURL , Runtime = @Runtime where mid = @mid";
                    cmd = new SqlCommand(query, con);
                    string Poster_filename = "images/" + Path.GetFileName(FileUpload1.PostedFile.FileName);
                    string Picture_filename = "images/" + Path.GetFileName(FileUpload2.PostedFile.FileName);
                    cmd.Parameters.AddWithValue("@PosterURL", Poster_filename);
                    cmd.Parameters.AddWithValue("@PhotoURL", Picture_filename);
                }
                cmd.Parameters.AddWithValue("@Name", tbMovieName.Text.Trim());
                cmd.Parameters.AddWithValue("@Category", ddlCategory.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@Description", tbDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@ReleaseYear", ddlReleaseYear.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@Runtime", tbRunTime.Text.Trim());
                cmd.Parameters.AddWithValue("@StudioName", ddlStudioName.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@Ratings", tbRating.Text.Trim());
                cmd.Parameters.AddWithValue("@TrailerURL", tbTrailerURL.Text.Trim());
                cmd.Parameters.AddWithValue("@StoryLine", tbStoryLine.Text.Trim());
                cmd.Parameters.AddWithValue("@EmbedURL", tbEmbedURL.Text.Trim());
                cmd.Parameters.AddWithValue("@Language", ddlLanguage.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@mid", tbMid.Text);

                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();
                Response.Write("<script>alert('Updated Successfully');</script>");

            }
            catch(Exception e)
            {
                Response.Write("<script>alert('"+e.Message+"');</script>");
            }
        }
        public void Delete_movie_info(string mid)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = @"delete Movies where Mid = '" + mid + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Movie Deleted Successfully');</script>");
            }
            catch(Exception e)
            {
                Response.Write("<script>alert('" + e.Message + "');</script>");
            }
        }
        public void LinkButton_Command(Object sender, CommandEventArgs e)
        {
            String MID = e.CommandArgument.ToString();

            Response.Redirect("MovieDetails.aspx?Mid=" + MID);
        }
        protected void GridView4_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ActiveStatus")
            {

                int id = Convert.ToInt32(e.CommandArgument);
                Change_User_Status(id, "Active");

            }
            if(e.CommandName == "DisableStatus")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Change_User_Status(id, "Disable");
            }
            if (e.CommandName == "DeleteUser")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Delete_User(id);
            }
            
        }
        public void Change_User_Status(int id,String status)
        {
            try
            {
                //checking the previous status of the given id
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = @"Select Status from [User] where Uid = '" + id + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count >= 1)
                {
                    String stat = dt.Rows[0]["Status"].ToString();
                    //if previous status and new status are not same then we will update the status
                    if(stat != status)
                    {
                        SqlConnection con1 = new SqlConnection(strcon);
                        if (con1.State == ConnectionState.Closed)
                            con1.Open();
                        string query1 = @"Update [User] Set Status = '"+status+"' where Uid = "+id;
                        SqlCommand cmd1 = new SqlCommand(query1, con1);
                        cmd1.ExecuteNonQuery();
                        con1.Close();
                        GridView4.DataBind();
                    }
                }

                }catch(Exception e)
            {

            }
        }
        public void Delete_User(int id)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = @"delete [User] where Uid = '" + id + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                GridView4.DataBind();
                Response.Write("<script>alert('Deleted User Successfully');</script>");
            }
            catch(Exception e)
            {

            }
            
        }
        protected void btnSearchMovieName_Click(object sender, EventArgs e)
        {
            if(tbMovieID.Text != null || tbMovieID.Text != "")
            {
                //Fetch movie name from database
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    string query = @"Select Mid,Name,ReleaseYear from Movies where Mid = '" + tbMovieID.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        MovieId = dt.Rows[0]["Mid"].ToString();
                        string MovieName = dt.Rows[0]["Name"].ToString();
                        string ReleaseYear = dt.Rows[0]["ReleaseYear"].ToString();
                        tbShowMovieName.Text =  MovieName + " (" + ReleaseYear + ")";

                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid');</script>");
                        tbShowMovieName.Text = "";
                        MovieId = "";
                    }
                    con.Close();
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                tbShowMovieName.Text = "";
                MovieId = "";
            }
            
        }
        protected void btnMovieIDGo_Click(object sender, EventArgs e)
        {
            //Upper section Movie ID Go function,don't misunderstand
            if(tbMid.Text == null || tbMid.Text == "")
            {
                //clear all text box and unselect all dropdown list
                Clear_all_Text();
            }
            else
            {
                //fetch data from database with valid Mid and show them in text box and dropdownlist
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    string query = @"Select Mid,Name,Language,Category,StudioName,ReleaseYear,Runtime,Ratings,[Description],StoryLine,
TrailerURL,EmbedURL from Movies where Mid = '" + tbMid.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        tbMovieName.Text = dt.Rows[0]["Name"].ToString();
                        tbRunTime.Text = dt.Rows[0]["RunTime"].ToString();
                        tbRating.Text = dt.Rows[0]["Ratings"].ToString();
                        tbEmbedURL.Text = dt.Rows[0]["EmbedURL"].ToString();
                        tbTrailerURL.Text = dt.Rows[0]["TrailerURL"].ToString();
                        tbDescription.Text = dt.Rows[0]["Description"].ToString();
                        tbStoryLine.Text = dt.Rows[0]["StoryLine"].ToString();
                        ddlLanguage.ClearSelection(); 
                        ddlLanguage.Items.FindByValue(dt.Rows[0]["Language"].ToString()).Selected = true;
                        ddlCategory.ClearSelection();
                        ddlCategory.Items.FindByValue(dt.Rows[0]["Category"].ToString()).Selected = true;
                        ddlReleaseYear.ClearSelection();
                        ddlReleaseYear.Items.FindByValue(dt.Rows[0]["ReleaseYear"].ToString()).Selected = true;
                        ddlStudioName.ClearSelection();
                        ddlStudioName.Items.FindByValue(dt.Rows[0]["StudioName"].ToString()).Selected = true;

                    }
                    con.Close();
                    
                }
                catch (Exception ex)
                {

                }
            }
        }
        public void Clear_all_Text()
        {
            tbMovieName.Text = "";
            tbRunTime.Text = "";
            tbRating.Text = "";
            tbEmbedURL.Text = "";
            tbTrailerURL.Text = "";
            tbDescription.Text = "";
            tbStoryLine.Text = "";
            ddlReleaseYear.ClearSelection();
            ddlCategory.ClearSelection();
            ddlLanguage.ClearSelection();
            ddlStudioName.ClearSelection();
        }
        protected void btnAddNewCast_Click(object sender, EventArgs e)
        {
            // this method will add new cast in database
            if(tbNewCastName.Text == "")
            {
                Response.Write("<script>alert('Cast Text Box is empty');</script>");
            }
            else
            {
                //check that name is already exist in the database or not
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    string query = @"select Cid,Name from Cast where Name like '%"+ tbNewCastName.Text.Trim()+ "%'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    
                    string outputString = "";
                    con.Close();
                    if (dt.Rows.Count >= 1)
                    {
                        for(int i=0; i<dt.Rows.Count; i++)
                        {
                            outputString += dt.Rows[i]["Name"].ToString() + ", "; 
                        }
                        outputString += "Has Found";
                        Response.Write("<script>alert('" + outputString + "');</script>");
                    }
                    else
                    {
                        //no duplicate found,so store the cast info in the database
                        create_new_cast_info();
                    }
                    
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }
        public void create_new_cast_info()
        {
            string nationality = "English", age = "", Gender = "Male";
            if (!ddlNationality.SelectedValue.Equals(""))
                nationality = ddlNationality.SelectedValue.ToString();
            if (tbCastAge.Text != "")
                age = tbCastAge.Text.Trim();
            if (ddlGender.SelectedValue.Equals("Female"))
                Gender = "Female";

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = @"insert into Cast(Name,Nationality,Gender,Age) values(@Name,@Nationality,@Gender,@Age)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Name", tbNewCastName.Text.Trim());
                cmd.Parameters.AddWithValue("@Nationality", nationality);
                cmd.Parameters.AddWithValue("@Gender", Gender);
                cmd.Parameters.AddWithValue("@Age", age);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Cast info Saved successfully');</script>");
                GridView2.DataBind();
                // clear the text field
                tbNewCastName.Text = "";
                ddlNationality.ClearSelection();
                ddlGender.ClearSelection();
                tbCastAge.Text = "";
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
            }
        }
        protected void btnAddNewDirector_Click(object sender, EventArgs e)
        {
            // this method will add new director in database
            if (tbDirectorName.Text == "")
            {
                Response.Write("<script>alert('Director Text Box is empty');</script>");
            }
            else
            {
                //check that name is already exist in the database or not
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    string query = @"select Did,Name from Directors where Name like '%" + tbDirectorName.Text.Trim() + "%'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    string outputString = "";
                    con.Close();
                    if (dt.Rows.Count >= 1)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            outputString += dt.Rows[i]["Name"].ToString() + ", ";
                        }
                        outputString += "Has Found";
                        Response.Write("<script>alert('" + outputString + "');</script>");
                    }
                    else
                    {
                        //no duplicate found,so store the cast info in the database
                        create_new_director_info();
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }
        public void create_new_director_info()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = @"insert into Directors(Name) values (@Name)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", tbDirectorName.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Cast info Saved successfully');</script>");
                GridView3.DataBind();
                // clear the text field
                tbDirectorName.Text = "";
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        protected void btnSearchCastName_Click(object sender, EventArgs e)
        {
            //this method will search cast name from given cast name text box
            if(tbCastNameSearch.Text != "")
            {
                //check the given cast name is valid or not
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    string query = @"select Cid,Name from Cast where Name like '%" + tbCastNameSearch.Text.Trim() + "%'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    
                    con.Close();
                    if (dt.Rows.Count >= 1)
                    {
                        tbCastNameSearch.Text = dt.Rows[0]["Name"].ToString();
                        tbCastRoleName.Enabled = true;
                        CastId = dt.Rows[0]["Cid"].ToString();
                    }
                    else
                    {
                        tbCastRoleName.Enabled = false;
                        CastId = "";
                    }
                }
                catch(Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Cast Textbox empty');</script>");
                tbCastRoleName.Enabled = false;
                CastId = "";
            }
        }
        public void update_CastId()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = @"select Cid,Name from Cast where Name like '%" + tbCastNameSearch.Text.Trim() + "%'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();
                if (dt.Rows.Count >= 1)
                {
                    tbCastNameSearch.Text = dt.Rows[0]["Name"].ToString();
                    tbCastRoleName.Enabled = true;
                    CastId = dt.Rows[0]["Cid"].ToString();
                }
                else
                {
                    tbCastRoleName.Enabled = false;
                    CastId = "";
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        protected void btnAddCastIntoMovie_Click(object sender, EventArgs e)
        {
            //due to calling full class global variable CastId will be null,thats why we need to fetch again
            update_CastId();
            //this method will add cast in the movie
            if(tbCastRoleName.Text != "" && tbCastNameSearch.Text != "" && tbMovieID.Text != "" && CastId != "")
            {
                // check if this cast has already included in that movie
                if (check_duplicate_movieCast())
                {
                    //has duplicated Cid,Mid, i mean this Cid has already included with respect to Mid
                    Response.Write("<script>alert('This cast is already added with this movie');</script>");

                }
                else
                {
                    // has not already exist in the database,so now we can insert data into MovieCast table
                    try
                    {
                        // insert data into Moviecast table
                        SqlConnection con = new SqlConnection(strcon);
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        string query = @"insert into MovieCast(Cid,Mid,RoleName) values (@Cid,@Mid,@RoleName)";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Cid", CastId);
                        cmd.Parameters.AddWithValue("@Mid", tbMovieID.Text.Trim());
                        cmd.Parameters.AddWithValue("@RoleName", tbCastRoleName.Text.Trim());
                        cmd.ExecuteNonQuery();
                        con.Close();
                        tbCastRoleName.Text = "";
                        tbCastNameSearch.Text = "";
                        CastId = "";
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('" + ex.Message + "');</script>");
                    }
                }
                
            }
            else
            {
                Response.Write("<script>alert('Not enough info to perform this operation');</script>");
            }
        }

        protected void btnDirectorSearch_Click(object sender, EventArgs e)
        {
            //this method will search director name from given director name text box
            if (tbSearchDirectorName.Text != "")
            {
                //check the given director name is valid or not
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    string query = @"select Did,Name from Directors where Name like '%" + tbSearchDirectorName.Text.Trim() + "%'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    con.Close();
                    if (dt.Rows.Count >= 1)
                    {
                        DirectorId = dt.Rows[0]["Did"].ToString();
                        tbDirectorSearchResult.Text = dt.Rows[0]["Name"].ToString();
                        
                    }
                    else
                    {
                        tbDirectorSearchResult.Text = "Not Found";
                        DirectorId = "";
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Director Textbox empty');</script>");
                DirectorId = "";
                tbDirectorSearchResult.Text = "";
            }
        }
        public void update_DirectorId()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = @"select Did,Name from Directors where Name like '%" + tbSearchDirectorName.Text.Trim() + "%'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();
                if (dt.Rows.Count >= 1)
                {
                    DirectorId = dt.Rows[0]["Did"].ToString();
                    tbDirectorSearchResult.Text = dt.Rows[0]["Name"].ToString() + " Mid : " + tbMovieID.Text + " Did : " + DirectorId;

                }
                else
                {
                    tbDirectorSearchResult.Text = "Not Found";
                    DirectorId = "";
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        protected void btnAddDirectorIntoMovie_Click(object sender, EventArgs e)
        {
            update_DirectorId();
            //this method will add director with movie in MovieDirector Table
            if (DirectorId != "" && tbDirectorSearchResult.Text != "")
            {
                // check if this cast has already included in that movie
                if (check_duplicate_movieDirectors())
                {
                    //has duplicated Did,Mid, i mean this Did has already included with respect to Mid
                    Response.Write("<script>alert('This Director is already added with this movie');</script>");

                }
                else
                {
                    // has not already exist in the database,so now we can insert data into MovieDirector table
                    try
                    {
                        // insert data into MovieDirector table
                        SqlConnection con = new SqlConnection(strcon);
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        string query = @"insert into MovieDirectors(Did,Mid) values(@Did,@Mid)";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Did", DirectorId);
                        cmd.Parameters.AddWithValue("@Mid", tbMovieID.Text.Trim());
                        cmd.ExecuteNonQuery();
                        con.Close();
                        tbSearchDirectorName.Text = "";
                        tbDirectorSearchResult.Text = "";
                        DirectorId = "";
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('" + ex.Message + "');</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Not enough info to perform this operation');</script>");
            }
        }

        protected void btnMovieInfoSearch_Click(object sender, EventArgs e)
        {
            //this method will filter or search accoring to search key and will show in movie info table
            string query = "SELECT Movies.Mid, Movies.Name, Movies.Category, Movies.ReleaseYear, Movies.Description, Movies.NoOfView, Movies.Ratings, Movies.PosterURL, Movies.Language, Movies.Runtime, Movies.StudioName, Movies.NoOfReview from Movies ";
            if (tbMovieInfoSearch.Text == "")
            {
                query += "order by Mid desc";
            }
            else if (tbMovieInfoSearch.Text == "#na")
            {
                query += "order by Movies.Name";    //movie name according ascending order (A-Z)
            }
            else if (tbMovieInfoSearch.Text == "#nd")
            {
                query += "order by Movies.Name desc";   //movie name according descending order (Z-A)
            }
            else if (tbMovieInfoSearch.Text == "#ia")
                query += "order by Mid";                //movie id according asceding order
            else if (tbMovieInfoSearch.Text == "#id")
                query += "order by Mid desc";           //movie id according descending order
            else if (tbMovieInfoSearch.Text == "#ya")
                query += "order by ReleaseYear";        //release year according asceding order
            else if (tbMovieInfoSearch.Text == "#yd")
                query += "order by ReleaseYear desc";   //release year according descending order
            else if (tbMovieInfoSearch.Text == "#Ra")
                query += "order by Ratings";            //Rating according asceding order
            else if (tbMovieInfoSearch.Text == "#Rd")
                query += "order by Ratings desc";       //Rating according descending order
            else if (tbMovieInfoSearch.Text == "#ra")
                query += "order by Runtime";            //runtime according asceding order
            else if (tbMovieInfoSearch.Text == "#rd")
                query += "order by Runtime desc";       //runtime according descending order
            else if (tbMovieInfoSearch.Text == "#sa")
                query += "order by StudioName";         //studioname according asceding order (A-Z)
            else if (tbMovieInfoSearch.Text == "#sd")
                query += "order by StudioName desc";    //studioname according descending order (Z-A)
            else if (tbMovieInfoSearch.Text == "#va")
                query += "order by NoOfView";           //views according ascending order
            else if (tbMovieInfoSearch.Text == "#vd")
                query += "order by NoOfView";           //views according descending order
            else
            {
                string key = tbMovieInfoSearch.Text.Trim();
                query += "where name like '%" + key + "%' or Category like '%" + key + "%' or ReleaseYear like '%" + key + "%' or Description like '%" + key + "%' or Ratings like '%" + key + "%' or Language like '%" + key + "%' or Runtime like '%" + key + "%' or StudioName like '%" + key + "%' or Mid like '%" + key + "%'";
            }
            //data fetching from database
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSourceID = null;
            GridView1.DataSource = dt;
            GridView1.DataBind();
            con.Close();
        }

        protected void btnCastInfoSearch_Click(object sender, EventArgs e)
        {
            //this method will filter or search accoring to search key and will show in movie info table
            string query = "Select Cast.Cid,Cast.Name,Cast.Nationality,Cast.Gender,Cast.Age from Cast ";
            if (tbCastInfoSerachKey.Text == "")
            {
                query += "order by Cast.Name";      
            }
            else if(tbCastInfoSerachKey.Text == "#na")
            {
                query += "order by Cast.Name";
            }
            else if(tbCastInfoSerachKey.Text == "#nd")
            {
                query += "order by Cast.Name desc";
            }
            else if(tbCastInfoSerachKey.Text == "#ia")
            {
                query += "order by Cast.Cid";
            }
            else if(tbCastInfoSerachKey.Text == "#id")
            {
                query += "order by Cast.Cid desc";
            }
            else if(tbCastInfoSerachKey.Text == "#ga")
            {
                query += "order by Cast.Gender";
            }
            else if(tbCastInfoSerachKey.Text == "#gd")
            {
                query += "order by Cast.Gender desc";
            }
            else if(tbCastInfoSerachKey.Text == "#Na")
            {
                query += "order by Cast.Nationality";
            }
            else if(tbCastInfoSerachKey.Text == "#Nd")
            {
                query += "order by Cast.Nationality desc";
            }
            else if(tbCastInfoSerachKey.Text == "#aa")
            {
                query += "order by Cast.Age";
            }
            else if(tbCastInfoSerachKey.Text == "#ad")
            {
                query += "order by Cast.Age desc";
            }
            else
            {
                string key = tbCastInfoSerachKey.Text.Trim();
                query += "where Name like '%"+key+ "%' or Nationality like '%" + key + "%' or Gender like '%" + key + "%' or Age like '%" + key + "%'";
            }
            //data fetching from database
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView2.DataSourceID = null;
            GridView2.DataSource = dt;
            GridView2.DataBind();
            con.Close();
        }

        public bool check_duplicate_movieCast()
        {
            // True => has duplicated
            // False => has not duplicated
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = @"select Cid,Mid from MovieCast where Mid = "+tbMovieID.Text+" and Cid = "+CastId;
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return true;
            }
        }

        public bool check_duplicate_movieDirectors()
        {
            // True => has duplicated
            // False => has not duplicated
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = @"select Did,Mid from MovieDirectors where Mid = " + tbMovieID.Text + " and Did = " + DirectorId;
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();
                if (dt.Rows.Count >= 1)
                {
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
                return true;
            }
        }
    }
}