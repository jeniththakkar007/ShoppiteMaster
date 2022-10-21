using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


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

        internal void Button1Click(DropDownList categories)
        {
            string Cs = "Data Source=103.150.186.216;Initial Catalog=Shoppite_master;User ID=sa;password=Z8Lix[jg3K@R74";

            SqlConnection sc = new SqlConnection(Cs);
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }
        //public Button Button1Click
        //{
        //    get;
        //    set;
        //}
    }
}