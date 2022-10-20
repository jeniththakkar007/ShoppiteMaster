using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontPanel
{
    public partial class cart : System.Web.UI.Page
    {


        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["OrderID"] != null)
                {
                    HiddenField1.Value = Session["OrderID"].ToString();

                    getdata(Guid.Parse(HiddenField1.Value));
                   
                }
            }
        }



        protected void updateorder(object sender, EventArgs e)
        {

            foreach (ListViewItem item in ListView1.Items)
            {
                Label lblorderid = (Label)item.FindControl("lblorderid");
                TextBox txtqty = (TextBox)item.FindControl("TextBox2");

                int id=int.Parse(lblorderid.Text);

                Order_Basic ob = db.Order_Basic.FirstOrDefault(u => u.OrderId == id);

                ob.QTY = int.Parse(txtqty.Text);
                db.SaveChanges();

            }



            getdata(Guid.Parse(HiddenField1.Value));
            uc_ordersummury.gettotalamount(Guid.Parse(HiddenField1.Value));

        }


        protected void getdata(Guid orderid)
        {
            var allproducts = db.f_getproducts();

            //var q = db.f_order_detail(Id).Where(u => u.OrderStatus == "Cart");

            var q = (from p in db.f_order_detail(orderid)
                   
                     where p.OrderStatus == "Cart"
                     select new
                     {
                         Orderid = p.id,
                         ProductName = p.ProductName,
                         Price = p.Price,
                         Image = p.image,
                         Qty = p.QTY,
                         Total = p.totalPrice,
                         CurrencyName = p.CurrencyName,
                         Tax = p.Tax ,
                         vat = p.VAT ,
                         ordervariation = p.OrderVariation,
                         shipping=p.DeliveryFees
                     }
                       );



            ListView1.DataSource = q.ToList().Distinct();
            ListView1.DataBind();

        }


       

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string orderid = ((Label)e.Item.FindControl("lblorderid")).Text;
            if (e.CommandName == "del")
            {

                int id = int.Parse(orderid);

                Order_Basic ob = db.Order_Basic.FirstOrDefault(u => u.OrderId == id);


                db.Order_Basic.Remove(ob);
                db.SaveChanges();

                getdata(Guid.Parse(HiddenField1.Value));
               uc_ordersummury.gettotalamount(Guid.Parse(HiddenField1.Value));



                if(ListView1.Items.Count <1)
                {

                    Response.Redirect("~/default");
                }
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if(Page.User.Identity.Name=="")
            {

                Session["OrderID"] = HiddenField1.Value;

                Response.Redirect("~/Account/guestlogin");
            }

            else
            {
                Session["OrderID"] = HiddenField1.Value;
                Response.Redirect("~/customer/shippingdetail");
            }
        }

      
    }
}