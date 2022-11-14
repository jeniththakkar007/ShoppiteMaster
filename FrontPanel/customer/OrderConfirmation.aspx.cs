using DataLayer.Helper;
using DataLayer.Models;
using System;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontPanel.customer
{
    public partial class OrderConfirmation : System.Web.UI.Page
    {
        private Entities db = new Entities();
        private Order_Helper oh = new Order_Helper();
        private Product_Helper ph = new Product_Helper();
        //string SMTP = "";
        //string BCC = "";

        //string EmailFrom = "";
        //string Password = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["OrderID"] != null)
                {
                    HiddenField1.Value = Request.QueryString["OrderID"].ToString();

                    getdata(Guid.Parse(HiddenField1.Value));

                    Order_Helper oh = new Order_Helper();
                    showcart(Guid.Parse(HiddenField1.Value));

                    if (Request.QueryString["Type"] == null)
                    {
                        oh.Order_Update(Guid.Parse(HiddenField1.Value), "Confirmed", this.Page.User.Identity.Name, "Paypal", this.Page.User.Identity.Name);
                    }
                    Session.Remove("OrderID");

                    try
                    {
                        vendorsendemails(Guid.Parse(HiddenField1.Value));
                        buysendemails(Guid.Parse(HiddenField1.Value));
                    }
                    catch (Exception ex)
                    {
                        return;
                    }
                }
            }
        }

        protected void getdata(Guid id)
        {
            //Order_Basic ob = db.Order_Basic.FirstOrDefault(u => u.OrderGUID == id);
            var q = db.f_order_master().Where(u => u.OrderGUID == id).ToList();

            foreach (var item in q)
            {
                lblorder.Text = item.orderid.ToString();
            }
        }

        //protected void emailbinding()
        //{
        //    Website_Setup_Helper wsh = new Website_Setup_Helper();

        //    wsh.setupemail();
        //    string SMTP = wsh.smtp;
        //    string BCC = wsh.bcc; ;
        //    string EmailFrom = wsh.bcc;
        //    string Password = wsh.password;
        //}

        protected void vendorsendemails(Guid id)
        {
            var q = (from ob in db.Order_Basic
                     join p in db.Product_Basic on ob.ProductId equals p.ProductId
                     join pr in db.Users_Profile on p.ProfileId equals pr.ProfileId
                     join os in db.Order_Shipping on ob.OrderGUID equals os.OrderGUID
                     where ob.OrderGUID == id
                     select new
                     {
                         email = pr.UserName,
                         FirstName = os.FirstName,
                         LastName = os.LastName
                     }
                       ).ToList().Distinct();

            foreach (var item in q)
            {
                emailsent2(item.email, item.FirstName + "-" + item.LastName, lblorder.Text);
            }
        }

        protected void buysendemails(Guid id)
        {
            Order_Shipping os = db.Order_Shipping.FirstOrDefault(u => u.OrderGUID == id);

            if (os != null)
            {
                emailsent2(os.Email, os.FirstName + "-" + os.LastName, lblorder.Text);
            }
        }

        protected void emailsent2(string toemails, string name, string orderid)
        {
            Website_Setup_Helper wsh = new Website_Setup_Helper();

            wsh.setupemail();
            string SMTP = wsh.smtp;
            string BCC = wsh.bcc; ;
            string EmailFrom = wsh.emailfrom;
            string Password = wsh.password;

            //emailbinding();
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    string host = HttpContext.Current.Request.Url.Host;
                    ListView1.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    MailMessage mm = new MailMessage(EmailFrom, toemails);
                    mm.Bcc.Add(BCC);

                    StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/Email/index1.html"));
                    string readFile = reader.ReadToEnd();
                    string myString = "";
                    myString = readFile;

                    myString = myString.Replace("#orderid", orderid);
                    myString = myString.Replace("#logo", Global.MyLogo.ToString());
                    myString = myString.Replace("#WebsiteName", host);

                    myString = myString.Replace("#client", name);
                    myString = myString.Replace("#cart", sw.ToString());

                    mm.Subject = "Order Detail";
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

            //string host = HttpContext.Current.Request.Url.Host;
            //// localhost
            //MailMessage mail = new MailMessage();
            //SmtpClient SmtpServer = new SmtpClient(SMTP);
            //mail.From = new MailAddress(EmailFrom);
            ////Email acpe = new Email();
            //mail.To.Add(toemails);
            //mail.Bcc.Add(BCC);

            //StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/Email/index1.html"));
            //string readFile = reader.ReadToEnd();
            //string myString = "";
            //myString = readFile;

            //myString = myString.Replace("#logo", Global.MyLogo.ToString());
            //myString = myString.Replace("#WebsiteName", host);

            //myString = myString.Replace("#client", name);
            //myString = myString.Replace("#cart", ListView1.ToString());

            //mail.Subject = "Order Detail";
            //mail.IsBodyHtml = true;
            //mail.Body = myString.ToString();
            //SmtpServer.Port = 25;
            //SmtpServer.Credentials = new System.Net.NetworkCredential(EmailFrom, Password);
            //SmtpServer.EnableSsl = false;
            //object userState = mail;
            //SmtpServer.SendCompleted += new SendCompletedEventHandler(SMTPClientForAsy.SmtpClient_OnCompleted);
            //SmtpServer.SendAsync(mail, userState);
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void emailsent(string toemails, string name)
        {
            //emailbinding();

            Website_Setup_Helper wsh = new Website_Setup_Helper();

            wsh.setupemail();
            string SMTP = wsh.smtp;
            string BCC = wsh.bcc; ;
            string EmailFrom = wsh.emailfrom;
            string Password = wsh.password;
            string host = HttpContext.Current.Request.Url.Host;
            // localhost
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(SMTP);
            mail.From = new MailAddress(EmailFrom);
            //Email acpe = new Email();
            mail.To.Add(toemails);
            mail.Bcc.Add(BCC);

            StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/Email/index1.html"));
            string readFile = reader.ReadToEnd();
            string myString = "";
            myString = readFile;

            myString = myString.Replace("#logo", Global.MyLogo.ToString());
            myString = myString.Replace("#WebsiteName", host);

            myString = myString.Replace("#client", name);
            myString = myString.Replace("#cart", ListView1.ToString());

            mail.Subject = "Order Detail";
            mail.IsBodyHtml = true;
            mail.Body = myString.ToString();
            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential(EmailFrom, Password);
            SmtpServer.EnableSsl = false;
            object userState = mail;
            SmtpServer.SendCompleted += new SendCompletedEventHandler(SMTPClientForAsy.SmtpClient_OnCompleted);
            SmtpServer.SendAsync(mail, userState);
        }

        protected void showcart(Guid orderid)
        {
            //var allproducts = db.f_getproducts();

            var orgId = ph.GetOrgID();
            var q = (from p in db.f_order_detail(orderid, orgId)

                     where p.OrderStatus == "Confirmed"
                     select new
                     {
                         Orderid = p.id,
                         ProductName = p.ProductName,
                         Price = p.Price,
                         Image = p.image,
                         Qty = p.QTY,
                         Total = p.totalPrice,
                         CurrencyName = p.CurrencyName,
                         Tax = p.Tax,
                         vat = p.VAT,
                         ordervariation = p.OrderVariation,
                         shipping = p.DeliveryFees
                     }
                                );

            ListView1.DataSource = q.ToList();
            ListView1.DataBind();
        }
    }
}