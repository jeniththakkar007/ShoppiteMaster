using DataLayer.Models;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VendorPanel.customer
{
    public partial class MyOrders : System.Web.UI.Page
    {
        private Entities db = new Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            HiddenField1.Value = this.Page.User.Identity.Name;

            if (!IsPostBack)
            {
                getdata();
            }

            if (Page.User.Identity.Name == "")
            {
                Response.Redirect("~/default");
            }
        }

        //protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    getdata();
        //}

        protected void getdata()
        {
            Profile_Helper ph = new Profile_Helper();

            int id = ph.profile_return_id(this.Page.User.Identity.Name);

            var q = (from om in db.f_order_master()
                     join ob in db.Order_Basic on om.OrderGUID equals ob.OrderGUID
                     join p in db.Product_Basic on ob.ProductId equals p.ProductId
                     orderby om.orderdate descending
                     where p.ProfileId == id && ob.OrderStatus == "Confirmed"
                     select om
                       );

            //var q = db.f_order_master().OrderByDescending(u => u.orderdate);

            //var q = db.f_Orders_All().Where(u => u.SellerID == id && u.orderdeliverystatus == RadioButtonList1.SelectedValue).OrderByDescending(u => u.InsertDate);

            ListView1.DataSource = q.ToList();
            ListView1.DataBind();
        }

        protected void ListView2_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string orderid = ((Label)e.Item.FindControl("Label11")).Text;
            if (e.CommandName == "action")
            {
                HiddenField2.Value = orderid;

                int id = int.Parse(orderid);

                Order_Status os = db.Order_Status.OrderByDescending(u => u.OrderStatusId).FirstOrDefault(u => u.OrderId == id);

                if (os != null)
                {
                    RadioButtonList1.SelectedValue = os.OrderStatus ?? "Pending";
                }
                else
                {
                    RadioButtonList1.SelectedValue = "Pending";
                }

                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup1();", true);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Order_Status os = new Order_Status();

            os.OrderId = int.Parse(HiddenField2.Value);
            os.OrderStatus = RadioButtonList1.SelectedValue;
            os.StatusDate = DateTime.Now;
            os.Remarks = txtreason.Text;
            os.Insertby = DateTime.Now.ToString();
            db.Order_Status.Add(os);
            db.SaveChanges();

            HiddenField2.Value = "0";

            getdata();

            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Order Status Updated Successfully');", true);
        }
    }
}