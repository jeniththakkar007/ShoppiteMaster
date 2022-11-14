using DataLayer.Models;

using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace MyAdmin
{
    public partial class updateproducts : System.Web.UI.Page
    {
        private Entities db = new Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var q = (from p in db.Product_Basic
                         select new { productname = p.ProductName, productid = p.ProductId }).ToList();

                ListView1.DataSource = q.ToList();
                ListView1.DataBind();
            }
        }

        protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                // Display the e-mail address in italics.

                Label id = ((Label)e.Item.FindControl("Label2"));

                Label pn = ((Label)e.Item.FindControl("Label1"));

                int eid = int.Parse(id.Text);

                CreateURLPath_Helper ch = new CreateURLPath_Helper();
                Product_Basic pb = db.Product_Basic.FirstOrDefault(u => u.ProductId == eid);

                pb.URLPath = ch.createurlpath(pn.Text);
                db.SaveChanges();
            }
        }
    }
}