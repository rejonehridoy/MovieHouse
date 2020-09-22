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
    public partial class Search : System.Web.UI.Page
    {
        string searcKey;
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.AllKeys.Contains("key") || Request.QueryString.AllKeys.Contains("action"))
            {
                searcKey = Request.QueryString["key"];

                Session["key"] = searcKey;
                fetch_searched_data(searcKey);

            }
            else
            {
                Response.Redirect("Error.aspx");
            }
        }
        public void LinkButton_Command(Object sender, CommandEventArgs e)
        {
            String MID = e.CommandArgument.ToString();
            Response.Redirect("MovieDetails?Mid=" + MID);
        }

        public void fetch_searched_data(string key)
        {

            SqlConnection con = new SqlConnection(strcon);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            string query = @"SELECT Movies.Mid, Movies.Name, Movies.Category, Movies.ReleaseYear, Movies.Description, Movies.NoOfView, Movies.Ratings, Movies.PosterURL, Movies.Language, Movies.Runtime, Movies.StudioName, Movies.NoOfReview from Movies where name like '%" + key + "%' or Category like '%" + key + "%' or ReleaseYear like '%" + key + "%' or Description like '%" + key + "%' or Ratings like '%" + key + "%' or Language like '%" + key + "%' or Runtime like '%" + key + "%' or StudioName like '%" + key + "%' or Mid like '%" + key + "%'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSourceID = null;
            GridView1.DataSource = dt;
            GridView1.DataBind();
            con.Close();
        }
    }
}