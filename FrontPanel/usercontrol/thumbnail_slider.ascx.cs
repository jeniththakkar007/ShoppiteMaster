using DataLayer.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace FrontPanel.usercontrol
{
    public partial class thumbnail_slider : System.Web.UI.UserControl
    {
        private Entities db = new Entities();
        private Product_Helper ph = new Product_Helper();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void getrecentlyviewed(string title)
        {
            //var q = db.f_getproducts().OrderByDescending(u => u.InsertDate).Where(u => u.maincatid == id).ToList().Take(10).OrderBy(u => Guid.NewGuid());
            UserRegisterHelper ur = new UserRegisterHelper();
            var orgid = ph.GetOrgID();

            string ip = ur.getuserip();

            var q = (from allproducts in db.f_getproducts_Recentlyviewed(ip, orgid)
                     select new
                     {
                         Productid = allproducts.ProductId,
                         urlpath = allproducts.URLPath,
                         image = allproducts.image,
                         ProductName = allproducts.ProductName,
                         Price = allproducts.Price,
                         currencyname = allproducts.CurrencyName,
                         totalpick = allproducts.totalpick
                     }

                     );

            //var q = (from allproducts in db.f_getproducts()

            //         join rpv in db.Product_Recently_Viewed on allproducts.ProductId equals rpv.ProductId
            //         orderby Guid.NewGuid(), allproducts.InsertDate descending
            //         where rpv.IP==ip
            //         select new
            //         {
            //             Productid=allproducts.ProductId,
            //             urlpath=allproducts.URLPath,
            //             image=allproducts.image,
            //             ProductName = allproducts.ProductName,
            //             Price=allproducts.Price,
            //             currencyname=allproducts.CurrencyName,
            //             totalpick = allproducts.totalpick
            //         }

            //         ).Distinct().Take(15);

            if (q != null)
            {
                lbltitle.Text = title;
            }

            ListView1.DataSource = q.ToList();
            ListView1.DataBind();
        }

        public void getlastcatdata(int id)
        {
            
            var q = db.f_getproducts_By_CategoryID(id).OrderByDescending(u => u.InsertDate).ToList().Take(10).OrderBy(u => Guid.NewGuid());

            ListView1.DataSource = q.ToList();
            ListView1.DataBind();
        }

        public void getmegaoffers(int id, string title)
        {
            //var q = dh.Product_All().OrderByDescending(u => u.ModifiedDate ?? u.InsertDate).Where(u => u.StatusId == id).ToList().Take(10);

            //var q = db.f_getproducts().Distinct().OrderByDescending(u => u.ModifiedDate ?? u.InsertDate).ToList().Take(10);

            var orgid = ph.GetOrgID();

            var q = (from allproducts in db.f_getproducts_By_getmegaoffers(orgid)

                     orderby Guid.NewGuid(), allproducts.ModifiedDate ?? allproducts.InsertDate descending
                     select new
                     {
                         Productid = allproducts.ProductId,
                         urlpath = allproducts.URLPath,
                         image = allproducts.image,
                         ProductName = allproducts.ProductName,
                         Price = allproducts.Price,
                         currencyname = allproducts.CurrencyName,
                         totalpick = allproducts.totalpick
                     }

                     ).Distinct().Take(id);

            if (q != null)
            {
                lbltitle.Text = title;
            }

            ListView1.DataSource = q.ToList();
            ListView1.DataBind();
        }

        public void getnewarrivals(int id, string title)
        {
            //var q = dh.Product_All().OrderByDescending(u => u.ModifiedDate ?? u.InsertDate).Where(u => u.StatusId == id).ToList().Take(10);

            //var q = db.f_getproducts().Distinct().OrderByDescending(u => u.ModifiedDate ?? u.InsertDate).ToList().Take(10);
            var orgid = ph.GetOrgID();

            var q = (from allproducts in db.f_getproducts_By_getmegaoffers(orgid)

                     orderby Guid.NewGuid(), allproducts.ModifiedDate ?? allproducts.InsertDate descending

                     //where allproducts.deals.Contains("New-Arrival")
                     select new
                     {
                         Productid = allproducts.ProductId,
                         urlpath = allproducts.URLPath,
                         image = allproducts.image,
                         ProductName = allproducts.ProductName,
                         Price = allproducts.Price,
                         currencyname = allproducts.CurrencyName,
                         totalpick = allproducts.totalpick
                     }

                     ).Distinct().Take(id);

            if (q != null)
            {
                lbltitle.Text = title;
            }

            ListView1.DataSource = q.ToList();
            ListView1.DataBind();
        }

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string id = ((Label)e.Item.FindControl("lblid")).Text;

            if (e.CommandName == "lk")
            {
                ph.Wishlist_Crud_Like(int.Parse(id), Page.User.Identity.Name);
            }
        }

        protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Label id = ((Label)e.Item.FindControl("lblid"));

                LinkButton lnk = ((LinkButton)e.Item.FindControl("lnkhomestatus"));

                // Display the e-mail address in italics.
                ph.getwishliststatus_ByIP(int.Parse(id.Text));

                if (ph.wishlisthstatus == "True")
                {
                    lnk.CssClass = "p-like";
                }

                if (Order_Helper.currency_code != "")
                {
                    Label lblprice = ((Label)e.Item.FindControl("lblprice"));
                    Label lblcurrency = ((Label)e.Item.FindControl("lblcurrency"));

                    lblcurrency.Text = Order_Helper.currency_code;

                    decimal coversionprice = decimal.Parse(lblprice.Text) * decimal.Parse(Order_Helper.currency_value.ToString());
                    //lblprice.Text = String.Format("#,##0.00", coversionprice);

                    lblprice.Text = coversionprice.ToString("#,##0.00");
                }
            }
        }
    }
}