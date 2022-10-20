using DataLayer.Helper;
using DataLayer.Models;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontPanel.usercontrol
{
    public partial class stripe_uc : System.Web.UI.UserControl
    {

        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void Donation(decimal fees, string vendor, string currency)
        {

            try
            {
                //getprojectcost();






                Guid id = Guid.Parse(Request.QueryString["ID"].ToString());

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

                    Description = vendor + " Donation " + id,

                };
                var service = new ChargeService();
                service.Create(options);





             

                Donation_Received dr = new Donation_Received();




                dr.RequestFundGUID = id;
                dr.Amount = decimal.Parse(fees.ToString());

                decimal amountdiv = decimal.Parse(fees.ToString()) / 100;

                decimal reverseamount = decimal.Parse(fees.ToString()) / amountdiv;


                dr.AdministrativeAmount = reverseamount;
                dr.PaymentDate = DateTime.Now;
                dr.PaypalId =this.Page.User.Identity.Name;

                db.Donation_Received.Add(dr);
                db.SaveChanges();



                Response.Redirect("~/donation/donationconfirmation");






            }
            catch (Exception ex)
            {

                lblerror.Text = ex.Message;
                lblerror.Visible = true;
            }



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


                Order_Helper oh = new Order_Helper();

                oh.Order_Update(Guid.Parse(id), "Confirmed", this.Page.User.Identity.Name, "Stripe", customer.Id);


     

                Response.Redirect("~/customer/orderconfirmation.aspx?OrderID="+ id);






            }
            catch (Exception ex)
            {

                lblerror.Text = ex.Message;
                lblerror.Visible = true;
            }



        }
    }
}