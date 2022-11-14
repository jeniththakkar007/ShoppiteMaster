using DataLayer.Helper;
using DataLayer.Models;
using System;
using System.IO;
using System.Net.Mail;
using System.Web;

namespace leaveittome.usercontrol
{
    public partial class contact : System.Web.UI.UserControl
    {
        private Entities db = new Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Website_Setup_Helper wsh = new Website_Setup_Helper();

            wsh.setupemail();

            string SMTP = wsh.smtp;
            string BCC = wsh.bcc; ;
            string EmailFrom = wsh.emailfrom;
            string Password = wsh.password;

            //string SMTP = "mail.theblacktrade.com";
            //string BCC = "imtiaz.makhani@gmail.com";

            //string EmailFrom = "noreply@theblacktrade.com";
            //string Password = "Software@1";
            //Ports = (int)dview.Table.Rows[0]["Port"];

            string host = HttpContext.Current.Request.Url.Host;
            // localhost
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(SMTP.ToString());
            mail.From = new MailAddress(EmailFrom.ToString());
            //Email acpe = new Email();
            mail.To.Add(BCC);
            mail.CC.Add(BCC.ToString());

            StreamReader reader = new StreamReader(Server.MapPath("~/email/Contact.html"));
            string readFile = reader.ReadToEnd();
            string myString = "";
            myString = readFile;
            myString = myString.Replace("{#Name}", TextBox1.Text);
            myString = myString.Replace("{#Email}", TextBox2.Text);

            myString = myString.Replace("{#Phone}", TextBox3.Text);
            myString = myString.Replace("{#Message}", TextBox4.Text);

            //myString = myString.Replace("{#Address}", Address.ToString());
            //myString = myString.Replace("{#State}", StateId.ToString());

            //myString = myString.Replace("{#City}", City.ToString());
            //myString = myString.Replace("{#ZC}", Zipcode.ToString());

            //myString = myString.Replace("{#TF}", Timeframe.ToString());
            //myString = myString.Replace("{#Budget}", EstimatedBudget.ToString());

            //myString = myString.Replace("{#Description}", Description.ToString());
            //myString = myString.Replace("{#InsertDate}", Insertdate.ToString());

            mail.Subject = "New Contact" + " " + DateTime.Now.ToString("dd/MMM/yyyy hh:mm:ss tt");
            mail.IsBodyHtml = true;
            mail.Body = myString.ToString();
            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential(EmailFrom.ToString(), Password.ToString());
            SmtpServer.EnableSsl = false;
            object userState = mail;
            SmtpServer.SendCompleted += new SendCompletedEventHandler(SMTPClientForAsy.SmtpClient_OnCompleted);
            SmtpServer.SendAsync(mail, userState);

            Label1.Text = "We have received your inquiry, We will get back to you in 24 hours.";

            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox3.Text = string.Empty;
            TextBox4.Text = string.Empty;
        }
    }
}