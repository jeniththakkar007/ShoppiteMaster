using DataLayer.Models;
using System;
using System.Linq;

namespace FrontPanel.Account
{
    public partial class ResetPassword : Page
    {
        private Entities db = new Entities();

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                int id = int.Parse(Request.QueryString["MemberId"].ToString());

                UserRegisterHelper ur = new UserRegisterHelper();

                User us = db.Users.FirstOrDefault(u => u.UserId == id);

                ur.changepassword(us.Username, TextBox2.Text);

                Response.Redirect("~/Account/ResetPasswordConfirmation");
            }
        }
    }
}