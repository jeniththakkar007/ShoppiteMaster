using DataLayer.Models;
using System;
using System.Linq;

namespace VendorPanel.usercontrol
{
    public partial class Delivery_Pending_uc : System.Web.UI.UserControl
    {
        private Entities db = new Entities();
        private Product_Helper ph = new Product_Helper();

        protected void Page_Load(object sender, EventArgs e)
        {
            getdisbursement();
        }

        protected void getdisbursement()
        {
            var orgid = ph.GetOrgID();
            var q = db.f_disbursement(orgid).Where(u => u.sellerusername == this.Page.User.Identity.Name && u.orderdeliverystatus == "Pending").Count();

            lbldisbursementamount.Text = q.ToString();
        }
    }
}