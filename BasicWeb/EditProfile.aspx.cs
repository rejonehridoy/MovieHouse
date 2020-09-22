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
    public partial class EditProfile : System.Web.UI.Page
    {
        public string id,name,email,password,phone,photourl;
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user"] == null || Session["user"].ToString().Equals(""))
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                id = Session["id"].ToString();
                load_user_info();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (password.Equals(OldPassword.Text))
            {
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                if(!filename.Equals("")) photourl = "images/User/" + filename;
                if (!Name.Text.Equals("")) name = Name.Text;
                if (!Contacts.Text.Equals("")) phone = Contacts.Text;
                if (!NewPassword.Text.Equals(""))
                {
                    if (NewPassword.Text.Equals(RetypePassword.Text))
                    {
                        password = NewPassword.Text;
                        update_user_info();
                        Response.Write("<script>alert('Profile Updated Successfully using new password\n');</script>");
                        Response.Redirect("Profile.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Password didnot matched,Please type correctly');</script>");
                    }
                }
                else
                {
                    update_user_info();
                    Response.Write("<script>alert('Profile Updated Successfully using current password');</script>");
                    Response.Redirect("Profile.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('Empty Current password field or didnot match Current password');</script>");
            }
            
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Name.Text = "";
            Contacts.Text = "";
            OldPassword.Text = "";
            NewPassword.Text = "";
            RetypePassword.Text = "";
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
                string query = "Select Name,Email,Password,Phone,PhotoURL from [User] where Uid = '" + id + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        name = dr.GetValue(0).ToString();
                        email = dr.GetValue(1).ToString();
                        password = dr.GetValue(2).ToString();
                        phone = dr.GetValue(3).ToString();
                        photourl = dr.GetValue(4).ToString();
                        
                    }
                }
                else {
                    Response.Write("<script>alert('Account info not found');</script>");
                }

                //Name.Text = name;
                //Contacts.Text = phone;

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</scrpit>");
            }
        }

        public void update_user_info()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string query = @"Update [User] set Name = @Name,[Password] = @Password,PhotoURL = @PhotoURL,Phone = @Phone where Uid = @Uid";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Name", name.Trim());
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@PhotoURL", photourl);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Uid", id);

                cmd.ExecuteNonQuery();
                con.Close();
                Session["user"] = name.Trim();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
}
    }
}