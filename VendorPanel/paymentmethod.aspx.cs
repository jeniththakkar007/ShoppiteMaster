using DataLayer.Helper;
using DataLayer.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace VendorPanel
{
    public partial class paymentmethod : System.Web.UI.Page
    {
        private Entities db = new Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getpaymentgateway();
                getpackagedetails();
                if (Request.QueryString["ID"] == null)
                {
                    Response.Redirect("~/Lockout");
                }
            }
        }

        protected void getpackagedetails()
        {
            int packageid = int.Parse(Request.QueryString["ID"].ToString());

            Vendor_Membership_Package vmp = db.Vendor_Membership_Package.FirstOrDefault(u => u.Membershipid == packageid);

            if (vmp != null)
            {
                if (vmp.Membershiptype == "Free")
                {
                    ///Free package
                    ///

                    int recurringperiod = int.Parse(vmp.RecurringPeriod.ToString());

                    Users_Membership um = new Users_Membership();

                    Profile_Helper profile = new Profile_Helper();
                    int profileid = profile.profile_return_id(this.Page.User.Identity.Name);

                    DateTime startDate = DateTime.Now;
                    DateTime expiryDate = startDate.AddDays(recurringperiod);

                    um.ProfileId = profileid;
                    um.IsFree = false;
                    um.StartDate = DateTime.Parse(startDate.ToShortDateString());
                    um.EndDate = DateTime.Parse(expiryDate.ToShortDateString());
                    um.MembershipFee = 0;
                    um.PaymentDate = DateTime.Now;
                    um.PaymentStatus = "Paid";
                    um.PaymentMode = "Card";
                    um.ReferenceId = "Free";
                    um.MembershipStatus = "Active";

                    db.Users_Membership.Add(um);
                    db.SaveChanges();

                    Response.Redirect("~/default");
                }
            }
        }

        protected void getpaymentgateway()
        {
            var q = (from ws in db.Website_Setup
                     where ws.Type == "Payment Gateway" && ws.ItemName != "Cash On Delivery"
                     select ws);

            RadioButtonList1.DataTextField = "Itemname";
            RadioButtonList1.DataValueField = "Itemname";

            RadioButtonList1.DataSource = q.ToList();
            RadioButtonList1.DataBind();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Website_Setup_Helper ws = new Website_Setup_Helper();
            int packageid = int.Parse(Request.QueryString["ID"].ToString());
            Packages_Helper package = new Packages_Helper();

            package.getpackagebyid(packageid);

            string fees = package.fees.ToString();
            string currency = package.currency;
            string recurringperiod = package.recurringdays.ToString();

            if (RadioButtonList1.SelectedValue == "Paypal")
            {
                PaymentGateway_Helper ph = new PaymentGateway_Helper();

                Profile_Helper profile = new Profile_Helper();
                int profileid = profile.profile_return_id(this.Page.User.Identity.Name);

                string host = "http://" + HttpContext.Current.Request.Url.Host;
                string successurl = host + "/Default";
                string cancelurl = host + "/Default";
                string ipn = host + "/ipnvendor.aspx";

                ph.Paypal_send(ws.paymetgateway_return("PaypalID"), true, packageid.ToString(), decimal.Parse(fees.ToString()), profileid.ToString(), currency, successurl, cancelurl, ipn);
            }
            else if (RadioButtonList1.SelectedValue == "Card")
            {
                stripe_uc.stripecrud(decimal.Parse(fees.ToString()), packageid.ToString(), currency);
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue == "Card")
            {
                stripe_uc.Visible = true;
            }
            else
            {
                stripe_uc.Visible = false;
            }
        }
    }
}