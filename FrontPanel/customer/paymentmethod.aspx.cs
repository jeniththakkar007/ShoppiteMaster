using DataLayer.Helper;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontPanel.customer
{
    public partial class paymentmethod : System.Web.UI.Page
    {

        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                getpaymentgateway();
            }
        }


        protected void getpaymentgateway()
        {
            var q=(from ws in db.Website_Setup
                 where ws.Type == "Payment Gateway" && ws.IsActive==true
                       select ws);



            RadioButtonList1.DataTextField = "Itemname";
            RadioButtonList1.DataValueField = "Itemname";

            RadioButtonList1.DataSource = q.ToList();
            RadioButtonList1.DataBind();
           
        }

        public class CurrencyRate
        {
            public string Disclaimer { get; set; }
            public string License { get; set; }
            public int TimeStamp { get; set; }
            public string Base { get; set; }
            public Dictionary<string, decimal> Rates { get; set; }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue == "Paypal")
            {
                PaymentGateway_Helper ph = new PaymentGateway_Helper();
                Website_Setup_Helper ws = new Website_Setup_Helper();

                string host = "http://" + HttpContext.Current.Request.Url.Host;
                string successurl = host + "/customer/orderconfirmation?OrderID=" + uc_ordersummury.OS_HiddenField1;
                string cancelurl = host + "/customer/cancel?OrderID=" + uc_ordersummury.OS_HiddenField1;
                string ipn = host + "/IPN.aspx";



                ///HTG does not support by paypal so covert it to USD
                ///



                decimal convertedfees = decimal.Parse(uc_ordersummury.OS_lbltotal);
                if (uc_ordersummury.OS_lblcurrency == "HTG")
                {

                    string json = new System.Net.WebClient()
                 .DownloadString("https://openexchangerates.org/api/latest.json?app_id=c5624ad197e141ccb5d45c919aeed097&symbols=" + uc_ordersummury.OS_lblcurrency);
                    System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    CurrencyRate rates = js.Deserialize<CurrencyRate>(json);
                    KeyValuePair<string, decimal> rate = rates.Rates.FirstOrDefault();
                    decimal currentrate = decimal.Parse(rate.Value.ToString());
                   



                     convertedfees = decimal.Parse(uc_ordersummury.OS_lbltotal) / currentrate;
                }



                ph.Paypal_send(ws.paymetgateway_return("PaypalID"),true, this.Page.User.Identity.Name, convertedfees, uc_ordersummury.OS_HiddenField1, uc_ordersummury.OS_lblcurrency, successurl, cancelurl, ipn);
            }

            else if (RadioButtonList1.SelectedValue == "Card")
            {

                //Response.Redirect("~/cashfree/cashfree?OrderID=" + uc_ordersummury.OS_HiddenField1 + "&Amount=" + uc_ordersummury.OS_lbltotal + "&Signature=" + getsignature());
                stripe_uc.stripecrud(decimal.Parse(uc_ordersummury.OS_lbltotal), "Vendor" , uc_ordersummury.OS_lblcurrency);

            }


            else if (RadioButtonList1.SelectedValue == "Cash On Delivery")
            {
                


                Order_Helper oh = new Order_Helper();

                oh.Order_Update(Guid.Parse(uc_ordersummury.OS_HiddenField1), "Confirmed", this.Page.User.Identity.Name, "Cash On Delivery", "COD");




                Response.Redirect("~/customer/orderconfirmation?OrderID=" + uc_ordersummury.OS_HiddenField1 + "&Type=COD");

            }

            else if(RadioButtonList1.SelectedValue == "Cash Free")
            {

                Response.Redirect("~/cashfree/cashfree?OrderID=" + uc_ordersummury.OS_HiddenField1 + "&Amount="+ uc_ordersummury.OS_lbltotal+ "&Signature="+ getsignature());
            }

            else if (RadioButtonList1.SelectedValue == "Moncash")
            {

                Response.Redirect("~/moncash/moncash?OrderID=" + uc_ordersummury.OS_HiddenField1 + "&Amount=" + uc_ordersummury.OS_lbltotal);
            }
        }


        protected string getsignature()
        {
            string secret = "36eb8a2ab8565a26e945edeed14e51da0edbb8cc";
            string data = "";

            SortedDictionary<string, string> formParams = new SortedDictionary<string, string>();
            formParams.Add("appId", "19021245091e8fba17e93d99812091");
            formParams.Add("orderId", uc_ordersummury.OS_HiddenField1);
            formParams.Add("orderAmount", uc_ordersummury.OS_lbltotal);
            formParams.Add("orderCurrency", "INR");
            //formParams.Add("orderNote", "Test payment");
            //formParams.Add("customerName", "Customer Name");
            //formParams.Add("customerPhone", "9900000085");
            //formParams.Add("customerEmail", "test@cashfree.com");
            //formParams.Add("returnUrl", "http://example.com");
            //formParams.Add("notifyUrl", "http://example.com");
            foreach (var kvp in formParams)
            {
                data = data + kvp.Key + kvp.Value;
            }
            //Program n = new Program();
            string signature = CreateToken(data, secret);
            //Console.WriteLine(signature);


            return signature;
        }

        private string CreateToken(string message, string secret)
        {
            secret = secret ?? "";
            var encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(secret);
            byte[] messageBytes = encoding.GetBytes(message);

            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue == "Card")
            {
                //Response.Redirect("~/cashfree/freecash?OrderID=" + uc_ordersummury.OS_HiddenField1 + "&Amount=" + uc_ordersummury.OS_lbltotal + "&Signature=" + getsignature());
                stripe_uc.Visible = true;
            }

            else
            {

                stripe_uc.Visible = false;
            }


        }

     
    }
}