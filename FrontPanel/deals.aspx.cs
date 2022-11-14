using System;

namespace FrontPanel
{
    public partial class deals : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                search_allproducts.getproduct();
            }
        }
    }
}