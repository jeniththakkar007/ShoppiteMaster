using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using DataLayer.Models;
using FrontPanel;

namespace FrontPanel.Account
{
    public partial class Login : Page
    {

        UserRegisterHelper ur = new UserRegisterHelper();
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
              
             FailureText.Text = ur.login(txtemail.Text,txtpassword.Text, RememberMe.Checked);

             if (FailureText.Text == "Success")
             {



                 if (Session["OrderID"] != null)
                 {

                     ur.login(txtemail.Text, txtpassword.Text, true);
                     Response.Redirect("~/cart");
                 }

                 else
                 {

                      Profile_Helper ph = new Profile_Helper();

                      if (ph.isvendor_status(txtemail.Text) == false)
                      {

                          Response.Redirect("~/Default");
                      }

                      else
                      {

                          Response.Redirect("~/Vendor");
                      }
                 }
             }
               
            }
        }


       
    }
}