using DataLayer.Models;
using System;
using System.Linq;
using System.Web;

namespace FrontPanel.Donation
{
    public partial class Donate : System.Web.UI.Page
    {
        private Entities db = new Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    Guid id = Guid.Parse(Request.QueryString["ID"].ToString());

                    HiddenField1.Value = id.ToString();
                    var q = db.f_Donation_BYID().Where(u => u.RequestFundGUID == id);

                    foreach (var item in q)
                    {
                        lbltitle.Text = item.Title;
                        lbldescription.Text = item.Description;
                        lblpaypalid.Text = item.paypalid;
                        lblcurrency.Text = "USD";
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            PaymentGateway_Helper pgh = new PaymentGateway_Helper();

            string host = "http://" + HttpContext.Current.Request.Url.Host;
            string successurl = host + "/donation/donationconfirmation?ID=" + HiddenField1.Value;
            string cancelurl = host + "/donation/cancel?OrderID=" + HiddenField1.Value;
            string ipn = host + "/donation/ipndonation.aspx";

            pgh.Paypal_send(lblpaypalid.Text, true, this.Page.User.Identity.Name, decimal.Parse(lblamount.Text), HiddenField1.Value, "USD", successurl, cancelurl, ipn);
        }

        protected void txtamount_TextChanged(object sender, EventArgs e)
        {
            decimal perc = decimal.Parse(txtamount.Text) * 7;

            decimal adminfees = perc / 100;

            lbladministrativefees.Text = adminfees.ToString();

            decimal totalfees = decimal.Parse(lbladministrativefees.Text) + decimal.Parse(txtamount.Text);

            lblamount.Text = totalfees.ToString();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            //stripe_uc.Donation(decimal.Parse(txtamount.Text), "", "USD");

            stripe_uc.Donation(decimal.Parse(txtamount.Text), "", "USD");
        }
    }
}