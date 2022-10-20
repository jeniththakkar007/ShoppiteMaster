using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;

using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Drawing;
using DataLayer.Models;
using DataLayer.Helper;

namespace FrontPanel.Account
{
    public partial class ForgotPassword : Page
    {



        Entities db = new Entities();
      

        protected void Forgot(object sender, EventArgs e)
        {

           
            string id = string.Empty;
            string password = string.Empty;
            string email = string.Empty;
            string constr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT UserName, userid as Id, email FROM     dbo.users WHERE  (email = @Email)"))
                {
                    cmd.Parameters.AddWithValue("@Email", Email.Text.Trim());
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            id = sdr["Id"].ToString();
                            email = sdr["email"].ToString();
                            //password = sdr["Password"].ToString();
                        }
                    }
                    con.Close();
                }
            }
            if (!string.IsNullOrEmpty(id))
            {

                Website_Setup_Helper wsh = new Website_Setup_Helper();

                wsh.setupemail();


                string SMTP = wsh.smtp;
                string BCC = wsh.bcc; ;
                string EmailFrom = wsh.emailfrom;
                string Password = wsh.password;




               
                string host = HttpContext.Current.Request.Url.Host;
                // localhost
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(SMTP.ToString());
                mail.From = new MailAddress(EmailFrom.ToString());
                //Email acpe = new Email();
                mail.To.Add(email);
                mail.Bcc.Add(BCC.ToString());

                StreamReader reader = new StreamReader(Server.MapPath("~/email/PasswordRecovery.html"));
                string readFile = reader.ReadToEnd();
                string myString = "";
                myString = readFile;
                myString = myString.Replace("{#memberid}", id.ToString());
                myString = myString.Replace("{#URL}", host.ToString());


                mail.Subject = "Recover Password" + " " + DateTime.Now.ToString("dd/MMM/yyyy hh:mm:ss tt");
                mail.IsBodyHtml = true;
                mail.Body = myString.ToString();
                SmtpServer.Port = 25;
                SmtpServer.Credentials = new System.Net.NetworkCredential(EmailFrom.ToString(), Password.ToString());
                SmtpServer.EnableSsl = false;
                object userState = mail;
                SmtpServer.SendCompleted += new SendCompletedEventHandler(SMTPClientForAsy.SmtpClient_OnCompleted);
                SmtpServer.SendAsync(mail, userState);


                Label1.ForeColor = Color.Green;
                Label1.Text = "Password Reset link has been sent to your email address";
            }
           
            else
            {
                Label1.ForeColor = Color.Red;
                Label1.Text = "This username does not match our records.";
            }
        }
    }
}