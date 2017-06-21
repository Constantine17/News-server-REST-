using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using News_server.Users;
using System.Diagnostics;

namespace News_server
{
    public partial class Login : System.Web.UI.Page
    {
        //string user = "admin";
       // string password = "admin";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            //if (!Page.IsValid) return;
            InquiryToUsersDatabase inquiry = new InquiryToUsersDatabase();

            if(inquiry.LogIn(Login1.UserName, Login1.Password))
            {
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, false);
                Response.Redirect(@"/Restricted\Main_panel.aspx");
            }
        }
    }
}