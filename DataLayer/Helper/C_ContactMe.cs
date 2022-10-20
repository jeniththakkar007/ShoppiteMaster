

using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Routing;
using System.Web.UI;

    public class C_ContactMe
    {


        Entities db = new Entities();
        public string contactbnt(string loginusername, string clientusername, string message)
        {

           
                string id = "";

                string user = clientusername;


                Message s = db.Messages.FirstOrDefault(u => u.sender == loginusername && u.recipient == user);

                if (s != null)
                {
                    id = s.ChatID.ToString();

                }

                Message r = db.Messages.FirstOrDefault(u => u.recipient == loginusername && u.sender == user);

                if (r != null)
                {

                    id = r.ChatID.ToString();
                }


                if (id.ToString() == "")
                {
                    Message i = new Message();

                    i.ChatID = Guid.NewGuid();
                    i.sender = loginusername;
                    i.senddate = DateTime.Parse(DateTime.Now.ToString());
                    i.recipient = clientusername;
                    i.recieveddate = DateTime.Parse(DateTime.Now.ToString());
                    i.status = "Read";
                    i.Attachment = "No";
                    i.Message1 = message;
                    db.Messages.Add(i);
                    db.SaveChanges();

                    id = i.ChatID.ToString();



                   
                }

                //HttpContext.Current.Response.Redirect("~/inbox/chat.aspx?ID=" + id);

                return id;

        }



        public void sendmail(string msg, string toemail)
        {


            string SMTP = "mail.theblacktrade.com";
            string BCC = "globaliwebsite@gmail.com";

            string EmailFrom = "noreply@theblacktrade.com";
            string Password = "Software@1";
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {

                    string host = HttpContext.Current.Request.Url.Host;
                    //ListView1.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    MailMessage mm = new MailMessage(EmailFrom, toemail);
                    mm.Bcc.Add(BCC);



                    StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/Email/notificationemails.html"));
                    string readFile = reader.ReadToEnd();
                    string myString = "";
                    myString = readFile;


                    //myString = myString.Replace("#orderid", orderid);
                    //myString = myString.Replace("#logo", Global.MyLogo.ToString());
                    myString = myString.Replace("#message", msg);


                    myString = myString.Replace("#WebsiteName", host);
                    //myString = myString.Replace("#cart", sw.ToString());




                    mm.Subject = "New Message Received";
                    mm.Body = myString.ToString();
                    mm.IsBodyHtml = true;


                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = SMTP;
                    smtp.EnableSsl = false;
                    System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                    NetworkCred.UserName = EmailFrom;
                    NetworkCred.Password = Password;
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 25;
                    smtp.Send(mm);
                }
            }


        }
    }

    
       
