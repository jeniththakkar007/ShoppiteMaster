using DataLayer.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace FrontPanel.usercontrol
{
    public partial class review_view_uc : System.Web.UI.UserControl
    {
        private Entities db = new Entities();
        private Product_Helper ph = new Product_Helper();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getreview();
            }
        }

        protected void getreview()
        {
            string urlpath = this.Page.RouteData.Values["URL"].ToString();
            int id = ph.Get_ProductId(urlpath);
            var q = (from r in db.Reviews
                     where r.TransactionId == id && r.Module == "Product"
                     select r).ToList(); ;

            ListView1.DataSource = q.ToList();
            ListView1.DataBind();
        }
    }
}