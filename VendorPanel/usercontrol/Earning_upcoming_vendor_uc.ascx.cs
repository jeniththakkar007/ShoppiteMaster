using DataLayer.Models;
using System;
using System.Linq;

namespace VendorPanel.usercontrol
{
    public partial class Earning_upcoming_vendor_uc : System.Web.UI.UserControl
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
            var q = db.f_disbursement(orgid).Where(u => u.sellerusername == this.Page.User.Identity.Name && u.disbursementamount == 0).Sum(u => u.balancedisbursment);

            lbldisbursementamount.Text = q.ToString();
        }
    }
}