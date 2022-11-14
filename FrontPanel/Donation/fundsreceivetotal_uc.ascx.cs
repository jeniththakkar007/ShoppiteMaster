using DataLayer.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace FrontPanel.Donation
{
    public partial class fundsreceivetotal_uc : System.Web.UI.UserControl
    {
        private Entities db = new Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void getdonationtotal()
        {
            var q = db.f_donation_total().ToList();

            foreach (var item in q)
            {
                lbltotaldonation.Text = item.totaldonation.ToString();
            }
        }
    }
}