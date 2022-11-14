using DataLayer.Models;
using System;

namespace FrontPanel.cashfree
{
    public partial class response : System.Web.UI.Page
    {
        private Entities db = new Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["OrderID"] != null && Request.QueryString["Status"] != null)
                {
                    if (Request.QueryString["Status"] == "success")
                    {
                        updatemembership();
                        Response.Redirect("~/cashfree/success");
                    }
                    if (Request.QueryString["Status"] == "cancel")
                    {
                        Response.Redirect("~/cashfree/cancel");
                    }
                }
            }
        }

        protected void updatemembership()
        {
            if (Request.QueryString["OrderID"] != null)
            {
                string orderid = Request.QueryString["OrderID"].ToString();

                Response.Redirect("~/customer/orderconfirmation?OrderID=" + orderid);
            }
            else
            {
                Response.Redirect("~/cashfree/cancel");
            }

            //string orderid = Request.QueryString["order_id"].ToString();

            //int id = int.Parse(item_name.ToString());
        }
    }
}