using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontPanel.Error
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if(!IsPostBack)
            {

                if(Request.QueryString["Error"]!=null)
                {
                    string value = Request.QueryString["Error"].ToString();


                    if(value=="UserLogin")
                    {

                        lblerror.Text = "You are already logged in as customer. Logout to Register as Vendor.";
                    }

                    else if(value=="Wishlist")
                    {

                        lblerror.Text = "You are logged in to manage your wishlist. Please login to check wishlist items.";
                    }
                    
                }                
                
            }

        }
    }
}