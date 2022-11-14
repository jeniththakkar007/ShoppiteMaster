using DataLayer.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace AdminPanel.Admin
{
    public partial class VendorPackage_view : System.Web.UI.Page
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
            var q = (from vmp in db.Vendor_Membership_Package
                     join c in db.Currencies on vmp.CurrencyId equals c.CurrencyId
                     select new
                     {
                         ID = vmp.Membershipid,
                         MembershipType = vmp.Membershiptype,
                         Title = vmp.Title,
                         Description = vmp.Description,
                         RecurringPeriod = vmp.RecurringPeriod,
                         CurrencyName = c.CurrencyName,
                         Fees = vmp.Fees,
                         CreatedDate = vmp.InsertDate,
                         IsActive = vmp.IsActive
                     }

                       );

            GridView1.DataSource = q.ToList();
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("~/admin/vendorpackages?ID=" + GridView1.SelectedDataKey.Value);
        }
    }
}