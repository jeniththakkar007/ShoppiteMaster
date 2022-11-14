using DataLayer.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace VendorPanel.usercontrol
{
    public partial class vendor_package_uc : System.Web.UI.UserControl
    {
        private Entities db = new Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getdata();
            }
        }

        protected void getdata()
        {
            var q = (from m in db.Vendor_Membership_Package
                     join c in db.Currencies on m.CurrencyId equals c.CurrencyId
                     orderby m.Sortoption
                     where m.IsActive == true
                     select new
                     {
                         Membershipid = m.Membershipid,
                         recurringperiod = m.RecurringPeriod,
                         title = m.Title,
                         fees = m.Fees,
                         currency = c.CurrencyName,
                         Description = m.Description,
                         unit = m.Unit
                     }

                       );

            ListView1.DataSource = q.ToList();
            ListView1.DataBind();
        }
    }
}