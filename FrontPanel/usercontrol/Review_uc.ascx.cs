using DataLayer.Models;
using System;

namespace FrontPanel.usercontrol
{
    public partial class Review_uc : System.Web.UI.UserControl
    {
        private Entities db = new Entities();
        private Product_Helper ph = new Product_Helper();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.User.Identity.Name != null)
            {
                try
                {
                    string urlpath = this.Page.RouteData.Values["URL"].ToString();
                    int id = ph.Get_ProductId(urlpath);

                    Review r = new Review();

                    r.Comments = TextBox1.Text;
                    r.TransactionId = int.Parse(id.ToString());
                    r.Module = "Product";
                    r.UserName = this.Page.User.Identity.Name;
                    r.Star = int.Parse(Rating1.CurrentRating.ToString());
                    r.InsertDate = DateTime.Parse(DateTime.Now.ToString());

                    db.Reviews.Add(r);
                    db.SaveChanges();

                    Response.Redirect(Request.RawUrl);
                }
                catch
                {
                    Response.Redirect(Request.RawUrl);
                }
            }
            else
            {
                Response.Redirect("~/account/login");
            }
        }
    }
}