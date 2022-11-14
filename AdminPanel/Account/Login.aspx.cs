using System;
using System.Web;
using System.Web.UI;

namespace AdminPanel.Account
{
    public partial class Login : Page
    {
        private UserRegisterHelper ur = new UserRegisterHelper();

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            //OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                FailureText.Text = ur.login(txtemail.Text, txtpassword.Text, RememberMe.Checked);

                if (FailureText.Text == "Success")
                {
                    Response.Redirect("~/default");
                }
            }
        }
    }
}