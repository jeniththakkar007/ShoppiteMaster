using DataLayer.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace FrontPanel.usercontrol
{
    public partial class slider_detail : System.Web.UI.UserControl
    {
        private Entities db = new Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Page.RouteData.Values["URL"] != null)
                {
                    HiddenField1.Value = this.Page.RouteData.Values["URL"].ToString();

                    Product_Basic p = db.Product_Basic.FirstOrDefault(u => u.ProductId + "-" + u.URLPath == HiddenField1.Value);

                    Guid Id = Guid.Parse(p.ProductGUID.ToString());

                    getimages(Id);
                }
            }
        }

        protected void getimages(Guid Id)
        {
            var ci = (from p in db.Product_Basic
                      where p.ProductGUID == Id
                      select new
                      {
                          Image = p.CoverImage
                      }

                        );

            var pi = (from productimages in db.Product_Images
                      where productimages.ProductGUID == Id
                      select new
                      {
                          Image = productimages.Image
                      }

                       );

            var q = ci.Union(pi).ToList();

            ListView1.DataSource = q.ToList();
            ListView1.DataBind();
        }
    }
}