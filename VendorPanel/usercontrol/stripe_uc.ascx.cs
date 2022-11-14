using DataLayer.Helper;
using DataLayer.Models;
using Stripe;
using System;

namespace FrontPanel.usercontrol
{
    public partial class stripe_uc : System.Web.UI.UserControl
    {
        private Entities db = new Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void stripecrud(decimal fees, string vendor, string currency)
        {
            try
            {
                //getprojectcost();

                string id = Request.QueryString["ID"].ToString();

                Website_Setup_Helper ws = new Website_Setup_Helper();

                StripeConfiguration.SetApiKey(ws.paymetgateway_return("Stripe"));

                //StripeConfiguration.SetApiKey("sk_test_1bJLLNyKgee6hUNUJuji3xm9");

                int year = int.Parse(txtyear.Text);
                int month = int.Parse(txtmonth.Text);

                var optionsCard = new TokenCreateOptions
                {
                    Card = new CreditCardOptions
                    {
                        Number = txtcardnumber.Text,
                        ExpYear = year,
                        ExpMonth = month,
                        Cvc = txtcvc.Text
                    }
                };

                var servicecard = new TokenService();
                Token stripeToken = servicecard.Create(optionsCard);

                var optionscustomer = new CustomerCreateOptions
                {
                    Description = this.Page.User.Identity.Name,
                    Source = stripeToken.Id,
                    //Email=bi.EmailToReceiveInvoice
                };

                var servicecustomer = new CustomerService();
                Customer customer = servicecustomer.Create(optionscustomer);

                int a = Convert.ToInt32(fees * 100);

                var options = new ChargeCreateOptions
                {
                    Amount = a,
                    Currency = currency,
                    Customer = customer.Id,

                    Description = vendor + " Order Number " + id,
                };
                var service = new ChargeService();
                service.Create(options);

                Users_Membership um = new Users_Membership();

                /// user profile id
                Profile_Helper profile = new Profile_Helper();
                int profileid = profile.profile_return_id(this.Page.User.Identity.Name);

                //get package deails

                int packageid = int.Parse(vendor.ToString());
                Packages_Helper package = new Packages_Helper();

                package.getpackagebyid(packageid);

                int recurringperiod = int.Parse(package.recurringdays.ToString());

                DateTime startDate = DateTime.Now;
                DateTime expiryDate = startDate.AddDays(recurringperiod);

                um.ProfileId = profileid;
                um.IsFree = false;
                um.StartDate = DateTime.Parse(startDate.ToShortDateString());
                um.EndDate = DateTime.Parse(expiryDate.ToShortDateString());
                um.MembershipFee = fees;
                um.PaymentDate = DateTime.Now;
                um.PaymentStatus = "Paid";
                um.PaymentMode = "Card";
                um.ReferenceId = customer.Id;
                um.MembershipStatus = "Active";

                db.Users_Membership.Add(um);
                db.SaveChanges();

                Response.Redirect("~/default");
            }
            catch (Exception ex)
            {
                lblerror.Text = ex.Message;
                lblerror.Visible = true;
            }
        }
    }
}