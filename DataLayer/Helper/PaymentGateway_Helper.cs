using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;


    public class PaymentGateway_Helper
    {

        public void Paypal_send(string paypalid, bool IsLive, string clientusername, decimal totalamount, string custom, string currrency, string successreturnurl, string cancelreturnurl, string ipn)
        {

            string paypal = paypalid;







            string sellerpaypalid = paypal.ToString();

            if (sellerpaypalid != "")
            {
                string redirecturl = "";

                if (IsLive == false)
                {
                    //Mention URL to redirect content to paypal site
                    redirecturl += "https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_xclick&business=" + sellerpaypalid;
                    //ConfigurationManager.AppSettings["paypalemail"].ToString();
                }

                else
                {

                    redirecturl += "https://www.paypal.com/cgi-bin/webscr?cmd=_xclick&business=" + sellerpaypalid;
                }

                //First name i assign static based on login details assign this value
                redirecturl += "&first_name=test";

                //City i assign static based on login user detail you change this value
                redirecturl += "&city=bhubaneswar";

                //State i assign static based on login user detail you change this value
                redirecturl += "&state=Odisha";

                //redirecturl += "&invoice=" + Session["orderId"].ToString();

                //Product Name
                redirecturl += "&item_name=" + clientusername;

                //Product Name
                redirecturl += "&amount=" + totalamount;

                //Phone No
                redirecturl += "&night_phone_a=6789";

                //Product Name
                redirecturl += "&custom=" + custom;

                //Address 
                redirecturl += "&address1=" + "";

                //Business contact id
                // redirecturl += "&business=k.tapankumar@gmail.com";

                //Shipping charges if any
                redirecturl += "&shipping=0";

                //Handling charges if any
                redirecturl += "&handling=0";

                //Tax amount if any
                redirecturl += "&tax=0";

                //Add quatity i added one only statically 
                redirecturl += "&quantity=1";

                //Currency code 
                redirecturl += "&currency=" + currrency;
                //redirecturl += "&tx=" + Session["orderId"].ToString();
                redirecturl += "&at=" + ConfigurationManager.AppSettings["token"].ToString();

                //Success return page url



                redirecturl += "&return=" + successreturnurl;


                //Failed return page url
                //redirecturl += "&cancel_return=" +
                //  ConfigurationManager.AppSettings["FailedURL"].ToString();

                redirecturl += "&cancel_return=" + cancelreturnurl;

                //notify url

                redirecturl += "&notify_url=" + ipn;
                 //ConfigurationManager.AppSettings["PAYPAL_NOTIFICATION_URL"].ToString();

                HttpContext.Current.Response.Redirect(redirecturl);
            }
        }
        
    }
