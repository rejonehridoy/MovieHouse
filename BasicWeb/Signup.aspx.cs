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
    public partial class Signup : System.Web.UI.Page
    {
        public string photourl;
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        

        bool checkMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from [User] where Email='" + Email.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
        void signUpNewMember()
        {
            //Response.Write("<script>alert('Testing');</script>");
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO [User](Name,Email,Password,Gender,Phone,PhotoURL,CreationDate,Status) values(@Name,@Email,@Password,@Gender,@Phone,@PhotoURL,@CreationDate,@Status)", con);
                cmd.Parameters.AddWithValue("@Name", Name.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", Email.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", Password.Text.Trim());
                cmd.Parameters.AddWithValue("@Gender", Gender.Text.Trim());
                cmd.Parameters.AddWithValue("@Phone", Phone.Text.Trim());
                cmd.Parameters.AddWithValue("@PhotoURL", photourl.Trim());
                cmd.Parameters.AddWithValue("@CreationDate", getCurrentDate());
                cmd.Parameters.AddWithValue("@Status", "Pending");


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void SignupButton_Click(object sender, EventArgs e)
        {
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            photourl = "images/User/" + filename;
            if (Name.Text.Equals("") || Email.Text.Equals("") || Phone.Text.Equals("") || Password.Text.Equals("") ||
                Gender.Text.Equals("") || filename.Equals(""))
            {
                Response.Write("<script>alert('No field can be empty');</script>");
            }
            else
            {
                if (checkMemberExists())
                {

                    Response.Write("<script>alert('This Email has already registered');</script>");
                }
                else {
                    signUpNewMember();
                }
            }
            

        }

        public string getCurrentDate()
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            return dateTime.ToString("dd/MM/yyyy");
        }
    }
}