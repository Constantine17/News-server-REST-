using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News_server.Restricted
{
    public partial class Control_users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"/Restricted\Main_panel.aspx");
        }
    }

}