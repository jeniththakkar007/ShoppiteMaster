using DataLayer.Helper;
using DataLayer.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace FrontPanel
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfMultiVendor";
        private string _antiXsrfTokenValue;
        public static object MyCompanyName { get; private set; }
        public static object MyLogo { get; private set; }

        public static object Myfavicon { get; private set; }
        public static object IsDonation { get; private set; }
        public static object IsVendorChat { get; set; }
        public static object IsEmailOnChat { get; set; }

        public static object Title { get; set; }
        public static object keywords { get; set; }
        public static object description { get; set; }

        public static object pagenum { get; set; }
        public static object skiprows { get; set; }
        private Entities db = new Entities();
        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    //throw new InvalidOperationException("Validation of Anti-XSRF token failed.");

                    Response.Redirect("~/default");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Website_Setup_Helper ws = new Website_Setup_Helper();

                ws.getwebsiteinfo();

                MyCompanyName = ws.companyname;
                this.Page.Title += MyCompanyName;
                MyLogo = ws.logo;

                ///check if donation enable
                ///

                IsDonation = ws.Setup_Enable("Donation");
                if (IsDonation.ToString() == "True")
                {
                    dvdonation.Visible = true;
                    fundsreceivetotal_uc.getdonationtotal();
                }
                //Vendor Chat Enable or not
                IsVendorChat = ws.Setup_Enable("IsVendorChat");

                //Email Chat Enable or not
                IsEmailOnChat = ws.Setup_Enable("ChatEmail");

                ///pagenumber settings
                ///

                //My Favicon

                Myfavicon = ws.favicon != null ? ws.favicon.ToString() : null;
                hrfav.Href = Myfavicon.ToString();
                ///meta tag
                ///
                Title = ws.title;
                this.Page.Title += Title;


                Currency cur = db.Currencies.FirstOrDefault(u => u.ISBase == true);

                if (cur != null)
                {
                    Order_Helper.currencyid = cur.CurrencyId;
                    Order_Helper.currency_code = cur.CurrencyName;
                }

                //get all active currencies
                var q = (from c in db.Currencies
                         where c.IsPublished == true
                         select c);

                foreach (var item in q)
                {
                    Order_Helper.getsetcurrencies += item.CurrencyName + ",";
                }
                
                //meta tag
                string page = Request.Url.Segments[Request.Url.Segments.Length - 1];

                
                //Add Keywords Meta Tag.
                HtmlMeta keywords = new HtmlMeta();
                keywords.HttpEquiv = "keywords";
                keywords.Name = "keywords";
                keywords.Content = ws.keyword.ToString();
                this.Page.Header.Controls.Add(keywords);

                //Add Description Meta Tag.
                HtmlMeta description = new HtmlMeta();
                description.HttpEquiv = "description";
                description.Name = "description";
                description.Content = ws.description;
                this.Page.Header.Controls.Add(description);

                //// get footer script
                ///
                script_footer.getdata("Footer");

                //header script

                script_footer1.getdata("Header");
                
            }
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut();
        }
    }
}