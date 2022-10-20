using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminPanel
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                if(Page.User.Identity.Name=="")
                {

                    Response.Redirect("~/account/login");
                }

                else

                {

                    if (Page.User.Identity.Name == "Admin" || Page.User.Identity.Name == "admin")
                    {


                    }

                    else

                    {
                        Response.Redirect("~/account/login");
                    }
                }
            }
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut();
        }
    }
}