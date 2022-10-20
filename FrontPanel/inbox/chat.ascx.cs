using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontPanel.inbox
{
    public partial class chat : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.User.Identity.Name =="")
            {

                chaterror.Visible = true;
                lblerror.Text = "Please login to use chat feature";
                lblerror.CssClass = "nologin";

               
            }

            else
            {
                chaterror.Visible = false;

                if (Request.QueryString["ID"] == null)
                {


                    chaterror.Visible = true;
                    lblerror.Text = "Please select recipient to chat with.";
                    lblerror.CssClass = "nodata";
                }
            }
        }
    }
}