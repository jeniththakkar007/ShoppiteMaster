using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontPanel.usercontrol
{
    public partial class homepage_statusproducts : System.Web.UI.UserControl
    {

        Entities db = new Entities();
        Product_Helper ph = new Product_Helper();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{

            //    getproductstatus();
            //}
        }



        public void getproductstatus()
        {

            var orgId = ph.GetOrgID();
            var q = db.SP_Status_HasProducts(orgId);

            //var q = (from stat in db.Status
            //         join productstatus in db.Product_Status on stat.StatusId equals productstatus.StatusId
            //         join pr in db.f_getproducts() on productstatus.ProductGUID equals pr.ProductGUID
            //         orderby stat.Status1 ascending
            //         where stat.ShowOnFront == true
            //         select stat).Distinct().ToList();


            ListView1.DataSource = q.ToList();
            ListView1.DataBind();
        }


        protected void ListView2_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string id = ((Label)e.Item.FindControl("lblid")).Text;

            if (e.CommandName == "lk")
            {


                ph.Wishlist_Crud_Like(int.Parse(id), Page.User.Identity.Name);

                getproductstatus();
            }
        }


        protected void ListView2_ItemDataBound(object sender, ListViewItemEventArgs e)
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