using DataLayer.Helper;
using System;
using System.Web;

namespace FrontPanel.usercontrol
{
    public partial class detail_vendor_uc : System.Web.UI.UserControl
    {
        private Website_Setup_Helper wsh = new Website_Setup_Helper();
        protected void Page_Load(object sender, EventArgs e)
        {
            wsh.getwebsiteinfo();
            if (wsh.Setup_Enable("IsVendorChat").ToString() == "True")
            {
                LinkButton2.Visible = true;
                dvvendorchat.Visible = true;

                if (Request.QueryString["ID"] != null)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "chatvisible();", true);
                }
            }
        }

        public string Vendor_lblshopnameurlpath
        {
            get { return lblurlpath.Text; }
            set { lblurlpath.Text = value; }
        }

        public string Vendor_lblshopname
        {
            get { return lblshopname.Text; }
            set { lblshopname.Text = value; }
        }

        public string Vendor_imglogo
        {
            get { return imglogo.ImageUrl; }
            set { imglogo.ImageUrl = value; }
        }

        public string Vendor_hdnshopusername
        {
            get { return hdnshopusername.Value; }
            set { hdnshopusername.Value = value; }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("Store", new { Shopname = lblurlpath.Text.Replace(" ", "-").Replace("/", "-").Replace("&", "").Replace(" ", "") });
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            C_ContactMe cht = new C_ContactMe();
            UserRegisterHelper ur = new UserRegisterHelper();

            Profile_Helper ph = new Profile_Helper();

            string senderusername = "";

            string receiverusername = ph.getvendoruser_byshopname(lblurlpath.Text);

            string host = HttpContext.Current.Request.Url.Host;

            senderusername = Page.User.Identity.Name;

            string message = "Hello, how you doing? <br/> I want to discuss about this product <br/> " + "https://" + host + "/" + this.Page.RouteData.Values["URL"].ToString() + "/show";

            string chatid = cht.contactbnt(senderusername, receiverusername, message);
            Website_Setup_Helper ws = new Website_Setup_Helper();
            ws.getwebsiteinfo();
            if (ws.Setup_Enable("ChatEmail").ToString() == "True")
            {
                //if (Session["Email"] == null)
                //{
                cht.sendmail(message, receiverusername);
                Session["Email"] = "Sent";

                //}
            }

            Response.RedirectToRoute("Detail", new { URL = this.Page.RouteData.Values["URL"].ToString(), ID = chatid });
        }
    }
}