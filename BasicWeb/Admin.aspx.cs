using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BasicWeb
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(tbAdminID.Text.Trim() == "admin" && tbPassword.Text == "admin")
            {
                Response.Redirect("MovieEntry.aspx");
            }
            else
            {
                Response.Write("<script>alert('ID or password is incorrect');</script>");
            }
        }
    }
}