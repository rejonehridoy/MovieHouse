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
    public partial class Login : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {

           if(UserEmail.Text.Equals("") || UserPassword.Text.Equals(""))
            {
                Response.Write("<script>alert('Email or password can not be empty');</script>");
            }
            else
            {
                if (login() == 1 || login() == 3)
                {
                    Response.Write("<script>alert('Login Successfull');</script>");
                    if(Session["link"] == null || Session["link"].ToString().Equals(""))
                    {
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        string Link = Session["link"].ToString();
                        Session["link"] = null;
                        Response.Redirect(Link);
                    }
                    
                }
                else if(login() == 2)
                {
                    Response.Write("<script>alert('Your Account has disabed.Please contact admin of this website');</script>");
                }
                else if(login() == 0)
                {
                    Response.Write("<script>alert('Email or Password is incorrect');</script>");
                }
                
            }
        }
        public int login()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                string query = @"select * from [User] where Email = '" + UserEmail.Text.Trim() + "' and Password = '" + UserPassword.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count>=1)
                {
                    
                    string name = dt.Rows[0]["Name"].ToString();
                    string id = dt.Rows[0]["Uid"].ToString();
                    string email = dt.Rows[0]["Email"].ToString();
                    string status = dt.Rows[0]["Status"].ToString();
                    if (status == "Active")
                    {
                        Session["user"] = name;
                        Session["id"] = id;
                        Session["email"] = email;
                        Session["status"] = status;
                        return 1;
                    }
                    else if(status == "Disable")
                    {
                        return 2;
                    }
                    else
                    {
                        Session["user"] = name;
                        Session["id"] = id;
                        Session["email"] = email;
                        Session["status"] = status;
                        return 3;
                    }
                }
                else
                {
                    return 0;
                }
                
                

            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}