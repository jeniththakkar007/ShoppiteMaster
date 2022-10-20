using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontPanel.Donation
{
    public partial class MyFunds : System.Web.UI.Page
    {


        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                getdata();
            }
        }


        protected void getdata()
        {

            var q=(from dm in db.Donation_Master
                       where dm.UserName==this.Page.User.Identity.Name
                       select dm);


            ListView1.DataSource = q.ToList();
            ListView1.DataBind();
        }

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string ID = ((Label)e.Item.FindControl("Label2")).Text;
            if (e.CommandName == "ed")
            {

                Response.Redirect("~/Donation/FundRequest?ID=" + ID);
            }
        }
    }
}