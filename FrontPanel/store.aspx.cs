using System;

namespace FrontPanel
{
    public partial class store : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string storename = this.Page.RouteData.Values["Shopname"].ToString();
                search_allproducts.getstoreproducts(storename);
            }
        }
    }
}