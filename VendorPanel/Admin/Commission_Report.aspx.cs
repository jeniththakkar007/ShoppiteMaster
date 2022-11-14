using DataLayer.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace VendorPanel.Admin
{
    public partial class Commission_Report : System.Web.UI.Page
    {
        private Entities db = new Entities();
        private Product_Helper ph = new Product_Helper();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getdata();
            }
        }

        protected void getdata()
        {
            var orgid = ph.GetOrgID();
            var q = db.f_disbursement(orgid).Where(u => u.sellerusername == this.Page.User.Identity.Name).OrderByDescending(u => u.InsertDate).ToList();

            if (RadioButtonList1.SelectedValue == "Paid Disbursement")
            {
                q = q.Where(u => u.disbursementamount > 0).ToList();
            }
            else if (RadioButtonList1.SelectedValue == "Balance Disbursement")
            {
                q = q.Where(u => u.disbursementamount <= 0).ToList();
            }

            GridView1.DataSource = q.ToList();
            GridView1.DataBind();
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getdata();
        }
    }
}