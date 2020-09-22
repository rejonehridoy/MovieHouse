using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BasicWeb
{
    public partial class Reviews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void LinkButton_Command(Object sender, CommandEventArgs e)
        {
            // view details link button command
            String MID = e.CommandArgument.ToString();

            Response.Redirect("MovieDetails.aspx?Mid=" + MID);
        }
    }
}