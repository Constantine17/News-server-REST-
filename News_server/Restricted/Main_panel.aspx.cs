using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News_server.Restricted
{
    public partial class Main_panel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Control_users_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"/Restricted\Control_users.aspx");
        }

        protected void Searh_speders_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"/Restricted\Control_spiders.aspx");
        }
    }
}