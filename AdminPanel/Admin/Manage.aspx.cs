using DataLayer.Models;
using System;
using System.Web.UI;

namespace FrontPanel.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        protected string SuccessMessage
        {
            get;
            private set;
        }

        private Entities db = new Entities();

        protected void Page_Load()
        {
            if (!IsPostBack)
            {
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    // Strip the query string from action
                    Form.Action = ResolveUrl("~/admin/Manage");

                    SuccessMessage =
                        message == "ChangePwdSuccess" ? "Your password has been changed."
                        : message == "SetPwdSuccess" ? "Your password has been set."
                        : message == "RemoveLoginSuccess" ? "The account was removed."
                        : String.Empty;
                    successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
                }
            }
        }

        protected void ChangePassword_Click(object sender, EventArgs e)
        {
            UserRegisterHelper ur = new UserRegisterHelper();

            ur.changepassword(Page.User.Identity.Name, NewPassword.Text);

            Response.Redirect("~/admin/Manage?m=ChangePwdSuccess");
        }
    }
}