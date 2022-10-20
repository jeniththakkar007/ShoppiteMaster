using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminPanel.Admin
{
    public partial class DonationReport : System.Web.UI.Page
    {


        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            getdata();
        }

        protected void getdata()
        {

            var q=(from dr in db.Donation_Received
                     orderby dr.PaymentDate descending
                   select new
                   {


                       totalamount = dr.Amount + dr.AdministrativeAmount,
                       administrativefund = dr.AdministrativeAmount,
                       Communittyfund = dr.Amount ,
                       paymentdate=dr.PaymentDate,
                       paypalid=dr.PaypalId
                          

                   }
                       
                       
                       );
            ListView1.DataSource = q.ToList();
            ListView1.DataBind();
        }
    }
}