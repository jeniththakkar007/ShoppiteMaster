using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VendorPanel.Admin
{
    public partial class Order_detail : System.Web.UI.Page
    {

        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                getorderdata();
            }
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            Guid id = Guid.Parse(Request.QueryString["ID"].ToString());

            var q = (from ob in db.Order_Basic
                     where ob.OrderStatus == "Confirmed" && ob.OrderGUID == id
                     select ob).ToList();

            foreach (var item in q)
            {

                int orderid = int.Parse(item.OrderId.ToString());
                Order_Status os = new Order_Status();

                os.OrderId = orderid;
                os.OrderStatus = RadioButtonList1.SelectedValue;
                os.StatusDate = DateTime.Now;
                os.Remarks = txtreason.Text;
                os.Insertby = DateTime.Now.ToString();
                db.Order_Status.Add(os);
                db.SaveChanges();



                Order_Basic ob = db.Order_Basic.FirstOrDefault(u => u.OrderId == orderid);

                if (ob!=null)
                {
                    ob.LastOrderStatus = RadioButtonList1.SelectedValue;
                    db.SaveChanges();
                }

            }




            getorderdata();


            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Order Status Updated Successfully');", true);
        }

        protected void getorderdata()
        {
            Guid id = Guid.Parse(Request.QueryString["ID"].ToString());
            var q = db.f_order_detail(id);


            ListView1.DataSource = q.ToList();
            ListView1.DataBind();


            lbltotal.Text = q.Sum(u => u.totalPrice).ToString();

            //order status
            var orderstatus = (from ob in db.Order_Basic
                               join os in db.Order_Status on ob.OrderId equals os.OrderId
                               where ob.OrderGUID == id
                               select new
                               {
                                   orderstatus = os.OrderStatus,
                                   orderremarks=os.Remarks
                                  

                               }
                               
                               ).Take(1);

            foreach (var item in orderstatus)
            {
                RadioButtonList1.SelectedValue = item.orderstatus;
                lblorderstatus.Text = item.orderstatus;
                lblremarks.Text = item.orderremarks;


            }



            //order id


            var orderdetail = (from ob in db.Order_Basic
                             
                               where ob.OrderGUID == id
                               select new
                               {
                                 
                                   orderguid = ob.OrderGUID.ToString().Substring(0, 5),
                                   paymentmode = ob.PaymentMode,
                                   orderdate = ob.InsertDate

                               }

                             ).Take(1);

            foreach (var item in orderdetail)
            {
              
                lblorderid.Text = item.orderguid;
                lblpaymenttype.Text = item.paymentmode;
                lbldate.Text = DateTime.Parse(item.orderdate.ToString()).ToString("MMM dd,yyyy");
            }




            ///get shipping info
            Order_Shipping oshipping = db.Order_Shipping.OrderByDescending(u=>u.ShippingId).FirstOrDefault(u => u.OrderGUID == id);


            if (oshipping != null)
            {
                string shipping = oshipping.FirstName + " " + oshipping.LastName + "<br/>" + oshipping.Address + " " + oshipping.Zipcode + "<br/>" + oshipping.Phone + "<br/>" + oshipping.Email;

                lblshipping.Text = shipping;
            }


            //get vendor info

            var vendorinfo = (from ob in db.Order_Basic
                              join pb in db.Product_Basic on ob.ProductId equals pb.ProductId
                              join up in db.Users_Profile on pb.ProfileId equals up.ProfileId
                              where ob.OrderGUID==id
                              select up).Take(1);

            foreach (var item in vendorinfo)
            {

                string vendordetail = item.ShopName + " " + item.Address + "<br/>" + item.UserName + "<br/>" +item.ContactNumber;

                lblsellerdetail.Text = vendordetail;

            }

        }
    }
}