using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontPanel.customer
{
    public partial class MyWishList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Page.User.Identity.Name != "")
                {
                    search_allproducts.wishlist();
                }

                else
                {

                    Response.Redirect("~/Error/Error?Error=Wishlist");
                }

            }
        }
    }
}