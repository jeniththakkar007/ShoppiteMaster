using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer.Models;

namespace FrontPanel.Donation
{
    public partial class IPNdonation : System.Web.UI.Page
    {

        //string SMTP = "mail.bookevening.com";
        //string BCC = "naunareviews@gmail.com";
        //string EmailFrom = "alert@bookevening.com";
        //string Password = "Software@1";


        string SMTP = "mail.theblacktrade.com";
        string BCC = "imtiaz.makhani@gmail.com";

        string EmailFrom = "noreply@theblacktrade.com";
        string Password = "Software@1";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {






                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(SMTP.ToString());
                mail.From = new MailAddress(EmailFrom.ToString());
                //Email acpe = new Email();
                mail.To.Add("imtiaz.makhani@gmail.com");



                //mail.Bcc.Add("imtiaz.makhani@gmail.com");
                //StreamReader reader = new StreamReader(Server.MapPath("~/Paypal/ConfirmationEmail.htm"));
                //string readFile = reader.ReadToEnd();
                string myString = "";
                //myString = readFile;

                myString = "Link http://ecommrece/  Read from IPN <br/>";


                mail.Subject = "IPN work donation";
                mail.IsBodyHtml = true;
                mail.Body = myString.ToString();
                SmtpServer.Port = 25;
                SmtpServer.Credentials = new System.Net.NetworkCredential(EmailFrom.ToString(), Password.ToString());
                SmtpServer.EnableSsl = false;
                object userState = mail;
                SmtpServer.SendCompleted += new SendCompletedEventHandler(SMTPClientForAsy.SmtpClient_OnCompleted);
                SmtpServer.SendAsync(mail, userState);
            }

            /// my server was not taking https route so i need to add this 3 lines in my page so that my server allow https protocol
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            ServicePointManager.DefaultConnectionLimit = 9999;

            //end of server protocal

            //Post back to either sandbox or live
            string strSandbox = "https://www.sandbox.paypal.com/cgi-bin/webscr";


            //post of live
            string strLive = "https://www.paypal.com/cgi-bin/webscr";



            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strLive);
            //Set values for the request back
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            byte[] param = Request.BinaryRead(HttpContext.Current.Request.ContentLength);
            string strRequest = Encoding.ASCII.GetString(param);
            string strResponse_copy = strRequest;  //Save a copy of the initial info sent by PayPal
            strRequest += "&cmd=_notify-validate";
            req.ContentLength = strRequest.Length;

            //for proxy
            //WebProxy proxy = new WebProxy(new Uri("http://url:port#"));
            //req.Proxy = proxy;
            //Send the request to PayPal and get the response
            StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
            streamOut.Write(strRequest);
            streamOut.Close();
            StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
            string strResponse = streamIn.ReadToEnd();
            streamIn.Close();

            if (strResponse == "VERIFIED")
            {
                //check the payment_status is Completed
                //check that txn_id has not been previously processed
                //check that receiver_email is your Primary PayPal email
                //check that payment_amount/payment_currency are correct
                //process payment

                // pull the values passed on the initial message from PayPal

                NameValueCollection these_argies = HttpUtility.ParseQueryString(strResponse_copy);


                string user_email = these_argies["payer_email"];
                string pay_stat = these_argies["payment_status"];
                //string invoice = these_argies["invoice"];
                string username = these_argies["item_name"];

                string custom = these_argies["custom"];

                string amount = these_argies["amount"];
                //string custom = these_argies["custom"];
                //string txnid = these_argies["txn_id"];
                //string item_name = these_argies["item_name"];
                //string item_number = these_argies["item_number"];

                //string last_name = these_argies["last_name"];
                //string payer_id = these_argies["payer_id"];

                //like here i am fethcing customer email and pament status same way i have to pass custom? yes
                //.
                //.  more args as needed look at the list from paypal IPN doc
                //.


                if (pay_stat.Equals("Completed"))
                {

                    //FormView1.DataBind();

                    //Session["id"] = ((Label)FormView1.FindControl("IdLabel")).Text;

                    //Session["customer"] = "Customer";
                    //Send_download_link ("yours_truly@mycompany.com",  user_email, "Your order","Thanks for your order this the downnload link ... blah blah blah" );
                    //Session["payeeemail"] = user_email.ToString();
                    //Session["paymentstatus"] = pay_stat.ToString();
                    //Session["invoice"] = invoice.ToString();
                    //Session["UserLogin"] = username.ToString();
                    Session["custom"] = custom.ToString();


                    Entities db = new Entities();


                    Guid id = Guid.Parse(custom.ToString());


                    Order_Helper oh = new Order_Helper();

                    Donation_Received dr = new Donation_Received();




                    dr.RequestFundGUID = id;
                 

                    //decimal amountdiv = decimal.Parse(amount.ToString()) / 100;

                    string perf = "1.07";

                    decimal reverseamount = decimal.Parse(amount.ToString()) / decimal.Parse(perf.ToString());


                    dr.AdministrativeAmount =  decimal.Parse(amount.ToString()) - reverseamount;

                    dr.Amount = reverseamount;
                    dr.PaymentDate = DateTime.Now;
                    dr.PaypalId = user_email.ToString();

                    db.Donation_Received.Add(dr);
                    db.SaveChanges();

                    //SqlDataSource1.UpdateParameters.Add("Paypal", user_email);
                    //SqlDataSource1.Update();


                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient(SMTP.ToString());
                    mail.From = new MailAddress(EmailFrom.ToString());
                    //Email acpe = new Email();
                    mail.To.Add("imtiaz.makhani@gmail.com");
                    //mail.Bcc.Add("imtiaz.makhani@gmail.com");



                    //mail.Bcc.Add("imtiaz.makhani@gmail.com");
                    //StreamReader reader = new StreamReader(Server.MapPath("~/Paypal/ConfirmationEmail.htm"));
                    //string readFile = reader.ReadToEnd();
                    string myString = "";
                    //myString = readFile;

                    myString = Session["custom"].ToString();


                    mail.Subject = "Donation ipn";
                    mail.IsBodyHtml = true;
                    mail.Body = myString.ToString();
                    SmtpServer.Port = 25;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(EmailFrom.ToString(), Password.ToString());
                    SmtpServer.EnableSsl = false;
                    object userState = mail;
                    SmtpServer.SendCompleted += new SendCompletedEventHandler(SMTPClientForAsy.SmtpClient_OnCompleted);
                    SmtpServer.SendAsync(mail, userState);






                    //condition logic to check the input for dicover or heave database


                    //discover website logic

                    //access 2 is for discover site
                    //access 3 is for heaven site
                    //001 item number is for discover website monthly subscription, 001 item id is define at paypal website on button generator



                    // get last id and add new one




                    //string all = Session["payeeemail"].ToString() + " " + Session["custom"].ToString() + " " + Session["txnid"].ToString() + " " + Session["item_name"].ToString() + " " + Session["item_number"].ToString() + " " + Session["last_name"].ToString() + " " + Session["payer_id"].ToString() + " " + Session["paydate"].ToString() + " " + Session["nextpaydate"].ToString() + " " + Session["plan"].ToString() + " " + Session["Cnvar1"].ToString() + " " + Session["id"].ToString();

                    //MailMessage mail = new MailMessage();
                    //SmtpClient SmtpServer = new SmtpClient(SMTP.ToString());
                    //mail.From = new MailAddress(EmailFrom.ToString());
                    ////Email acpe = new Email();
                    //mail.To.Add(Session["UserLogin"].ToString());
                    //mail.Bcc.Add("imtiaz.makhani@gmail.com");

                    //StreamReader reader = new StreamReader(Server.MapPath("~/Email/Profile.html"));
                    //string readFile = reader.ReadToEnd();
                    //string myString = "";
                    //myString = readFile;
                    ////string name = HttpUtility.UrlEncode(Encrypt(Session["UserName"].ToString().Trim()));
                    ////string technology = HttpUtility.UrlEncode(Encrypt(ddlTechnology.SelectedItem.Value));

                    //myString = myString.Replace("{#UserName}", Session["UserLogin"].ToString());
                    ////myString = myString.Replace("{#payeeemail}", Session["payeeemail"].ToString());
                    ////myString = myString.Replace("{#lname}", TextBox2.Text);
                    ////myString = myString.Replace("{#date}", DateTime.Now.ToString());

                    ////myString = myString.Replace("{#message}", TextBox4.Text);


                    //mail.Subject = "Congrats! You have sucessfully subscribed"  ;
                    //mail.IsBodyHtml = true;
                    //mail.Body = myString.ToString();
                    //SmtpServer.Port = 25;
                    //SmtpServer.Credentials = new System.Net.NetworkCredential(EmailFrom.ToString(), Password.ToString());
                    //SmtpServer.EnableSsl = false;
                    //object userState = mail;
                    //SmtpServer.SendCompleted += new SendCompletedEventHandler(SMTPClientForAsy.SmtpClient_OnCompleted);
                    //SmtpServer.SendAsync(mail, userState);
                    //end of email sending code





                }


                // more checks needed here specially your account number and related stuff
            }
            else if (strResponse == "INVALID")
            {
                //log for manual investigation


                Response.Redirect("https://thievesmarketonline.com/customer/success.aspx?PayPal=Cancel");
            }
            else
            {
                //log response/ipn data for manual investigation
            }
        }
    }
}