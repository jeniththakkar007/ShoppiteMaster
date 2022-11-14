using System;

namespace FrontPanel
{
    public partial class brands : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string brandname = this.Page.RouteData.Values["BrandName"].ToString();
                search_allproducts.getbrandsproducts(brandname);
            }
        }
    }
}