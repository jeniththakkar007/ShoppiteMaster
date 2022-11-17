using DataLayer.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace FrontPanel.usercontrol
{
    public partial class header_categories : System.Web.UI.UserControl
    {
        private Entities db = new Entities();
        Product_Helper ph = new Product_Helper();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getcat();
            }
        }

        protected void getcat()
        {
            var orgid = ph.GetOrgID();
            var q = (from c in db.category_master
                     where c.parent_category_id == 0 && c.IsPublished == true && orgid == c.OrgId
                     orderby c.DisplayOrder
                     select new
                     {
                         urlpath = c.category_id + "-" + c.URLPath,
                         category_name = c.category_name,
                         category_id = c.category_id,
                         Banner = c.Banner
                     });

            ListView1.DataSource = q.ToList();
            ListView1.DataBind();
        }

        protected void ListView2_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                // Display the e-mail address in italics.

                Label lblcatename = ((Label)e.Item.FindControl("Label1"));
                Label lblhlevel = ((Label)e.Item.FindControl("Label4"));

                if (lblhlevel.Text == "0")
                {
                    lblcatename.CssClass = "cat0";
                }
                else if (lblhlevel.Text == "1")
                {
                    lblcatename.CssClass = "cat1";
                }
                else if (lblhlevel.Text == "2")
                {
                    lblcatename.CssClass = "cat2";
                }
            }
        }
    }
}