using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontPanel.customer
{
    public partial class shippingdetail : System.Web.UI.Page
    {


        Entities db = new Entities();
        Product_Helper ph = new Product_Helper();
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

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            uc_shipping.insertshipping();

            Response.Redirect("~/customer/paymentmethod?ID=" + HiddenField1.Value);
        }



        protected void getdata(Guid orderid)
        {
            var orgID = ph.GetOrgID();
            var q = (from p in db.f_order_detail(orderid,orgID)

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
                         Tax = p.Tax,
                         vat = p.VAT,
                         ordervariation = p.OrderVariation,
                         shipping = p.DeliveryFees
                     }
                     );




            ListView1.DataSource = q.ToList();
            ListView1.DataBind();

        }
    }
}