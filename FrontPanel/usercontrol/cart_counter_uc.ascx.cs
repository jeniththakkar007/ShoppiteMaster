using DataLayer.Models;
using System;
using System.Linq;

namespace FrontPanel.usercontrol
{
    public partial class cart_counter_uc : System.Web.UI.UserControl
    {
        private Entities db = new Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["OrderID"] != null)
            {
                Guid id = Guid.Parse(Session["OrderID"].ToString());
                getcartcount(id);
            }
        }

        protected void getcartcount(Guid id)
        {
            var q = (from o in db.Order_Basic
                     where o.OrderGUID == id && o.OrderStatus == "Cart"
                     select o).Count();

            if (q != null)
            {
                lblcount.Text = q.ToString();
                LinkButton1.Enabled = true;
            }
            else
            {
                lblcount.Text = string.Empty;
                LinkButton1.Enabled = false;
            }

            if (lblcount.Text == "0")
            {
                LinkButton1.Enabled = false;
            }
        }
    }
}