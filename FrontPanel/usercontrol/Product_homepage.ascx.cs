using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontPanel.usercontrol
{
    public partial class Product_homepage : System.Web.UI.UserControl
    {

        Entities db = new Entities();
        Product_Helper ph = new Product_Helper();
        protected void Page_Load(object sender, EventArgs e)
        {

            //if(!IsPostBack)
            //{

            //    getparentcat();
            //}

        }

        protected void ListView2_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string id = ((Label)e.Item.FindControl("lblid")).Text;

            if (e.CommandName == "lk")
            {
                

                ph.Wishlist_Crud_Like(int.Parse(id), Page.User.Identity.Name);

                getparentcat();
            }            
        }


        protected void ListView2_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {

                Label id = ((Label)e.Item.FindControl("lblid"));

                LinkButton lnk = ((LinkButton)e.Item.FindControl("lnkhomeproduct"));

                // Display the e-mail address in italics.
                ph.getwishliststatus_ByIP(int.Parse(id.Text));

                if(ph.wishlisthstatus=="True")
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

        public void getparentcat()
        {


            var q=(from c in db.category_master
                       where c.IsPublished==true && c.IsShowHomePage==true && c.parent_category_id==0
                   select c).ToList() ;


            ListView1.DataSource = q.ToList();
            ListView1.DataBind();
        }
    }
}