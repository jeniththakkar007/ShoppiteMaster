using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminPanel.Admin
{
    public partial class CustomersAll : System.Web.UI.Page
    {
        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                getdata();
            }

        }


        protected void getdata()
        {


            var q = db.f_Profile_All("Client");

            ListView1.DataSource = q.ToList();
            ListView1.DataBind();

            lblrowscount.Text = "Total Records Found: " + q.Count().ToString();
        }


        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string username = ((Label)e.Item.FindControl("Label1")).Text;

            if (e.CommandName == "change")
            {
                UserRegisterHelper u = new UserRegisterHelper();


                u.userlockout(username);

                Response.Redirect(Request.RawUrl);
            }


            if (e.CommandName == "del")
            {
                Users_Profile up = db.Users_Profile.FirstOrDefault(u => u.UserName == username);


                db.Users_Profile.Remove(up);
                db.SaveChanges();

                Response.Redirect(Request.RawUrl);
            }
        }
    }
}