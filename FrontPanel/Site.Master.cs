using DataLayer.Helper;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
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


            

                this.Page.Title += Global.MyCompanyName.ToString();

                //string isdonat=Global.IsDonation.ToString();

                if (Global.IsDonation.ToString() == "True")
                {

                    dvdonation.Visible = true;
                    fundsreceivetotal_uc.getdonationtotal();

                   
                }

                //favicon
                 hrfav.Href = Global.Myfavicon.ToString();


                //meta tag
                 string page = Request.Url.Segments[Request.Url.Segments.Length - 1];
                

                 //Add Page Title.
                 this.Page.Title = Global.Title.ToString();

                 //Add Keywords Meta Tag.
                 HtmlMeta keywords = new HtmlMeta();
                 keywords.HttpEquiv = "keywords";
                 keywords.Name = "keywords";
                 keywords.Content = Global.keywords.ToString();
                 this.Page.Header.Controls.Add(keywords);

                 //Add Description Meta Tag.
                 HtmlMeta description = new HtmlMeta();
                 description.HttpEquiv = "description";
                 description.Name = "description";
                 description.Content = Global.description.ToString();
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