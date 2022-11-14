using DataLayer.Helper;
using DataLayer.Models;
using System;
using System.Linq;

namespace VendorPanel
{
    public partial class Lockout : System.Web.UI.Page
    {
        private Entities db = new Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getvendorfees();
                check_status();
            }
        }

        protected void getvendorfees()
        {
            Website_Setup_Helper ws = new Website_Setup_Helper();

            lblfees.Text = ws.Vendormembershipstatus_return("VendorMembership");
            lblcurrencyname.Text = ws.Website_description_return("Currency");

            lbltitle.Text = ws.Website_description_return("VendorMembership");
        }

        protected void check_status()
        {
            if (Request.QueryString["Status"] != null)
            {
                string status = Request.QueryString["Status"].ToString();
                int id = 0;

                Profile_Helper ph = new Profile_Helper();
                int profileid = ph.profile_return_id(this.Page.User.Identity.Name);
                if (Request.QueryString["ID"] != null)
                {
                    id = int.Parse(Request.QueryString["ID"].ToString());
                }

                if (status == "Pending")
                {
                    lblmessage.CssClass = "alert alert-warning";
                    lblmessage.Text = "Subscription payment is pending.";
                }
                else if (status == "Expired")
                {
                    if (id != 0)
                    {
                        Users_Membership ms = db.Users_Membership.FirstOrDefault(u => u.MembershipId == id && u.ProfileId == profileid);

                        if (ms != null)
                        {
                            lblmessage.CssClass = "alert alert-danger";
                            lblmessage.Text = "Your subscription was expired on " + DateTime.Parse(ms.EndDate.ToString()).ToString("dd MMM, yyyy");

                            if (ms.Cancellationdate != null)
                            {
                                lblmessage.Text = "You cancelled your subscription on " + DateTime.Parse(ms.Cancellationdate.ToString()).ToString("dd MMM, yyyy");
                                lblmessage.CssClass = "alert alert-info";
                            }
                        }
                    }
                }
                else if (status == "Cancelled")
                {
                    if (id != 0)
                    {
                        Users_Membership ms = db.Users_Membership.FirstOrDefault(u => u.MembershipId == id && u.ProfileId == profileid);

                        if (ms != null)
                        {
                            lblmessage.Text = "You cancelled your subscription on " + DateTime.Parse(ms.Cancellationdate.ToString()).ToString("dd MMM, yyyy");
                            lblmessage.CssClass = "alert alert-info";
                        }
                    }
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
        }
    }
}