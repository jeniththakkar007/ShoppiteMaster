using DataLayer.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace FrontPanel.usercontrol
{
    public partial class homepage_brands : System.Web.UI.UserControl
    {
        private Entities db = new Entities();
        private Product_Helper ph = new Product_Helper();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!IsPostBack)
            //{
            //    getbrands();
            //}
        }

        public string Br_lblselectedbrand
        {
            get { return lblselectedbrand.Text; }
            set { lblselectedbrand.Text = value; }
        }

        public void getbrands()
        {
            var orgid = ph.GetOrgID();
            var q = (from b in db.Brands
                     join pb in db.Product_Brands on b.BrandId equals pb.BrandId
                     where b.BrandImage != string.Empty && b.BrandImage != null && b.OrgId == orgid
                     orderby Guid.NewGuid()
                     select b).Distinct().Take(12);

            //q = q.OrderBy(t => Guid.NewGuid()).Take(12).ToList();

            ListView1.DataSource = q.ToList();
            orgid = ph.GetOrgID();
            ListView1.DataBind();
        }

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string brandname = ((Label)e.Item.FindControl("Label1")).Text;
            string brandurlpath = ((Label)e.Item.FindControl("Label2")).Text;
            string brandid = ((Label)e.Item.FindControl("Label3")).Text;
            if (e.CommandName == "view")
            {
                //if (this.Page.Title.Contains("Search"))
                //{
                //    lblselectedbrand.Text = brandname;
                //}
                //if (this.Page.Title.Contains("Home"))
                //{
                Response.RedirectToRoute("Brand", new { BrandName = brandid + "-" + brandurlpath.Replace(" ", "-").Replace("/", "-").Replace("&", "").Replace(" ", "") });
                //}
            }
        }
    }
}