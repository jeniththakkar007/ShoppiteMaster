using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontPanel
{
    public partial class store : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {

                string storename=this.Page.RouteData.Values["Shopname"].ToString();
                search_allproducts.getstoreproducts(storename);
            }

        }
    }
}