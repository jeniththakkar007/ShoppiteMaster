using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VendorPanel.Admin
{
    public partial class Membershipsusbcription : System.Web.UI.Page
    {


        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {

                var q=(from m in db.Users_Membership
                        join p in db.Users_Profile  on  m.ProfileId equals p.ProfileId
                           where p.UserName==this.Page.User.Identity.Name
                       select m
                           
                           );


                GridView1.DataSource = q.ToList();
                GridView1.DataBind();
            }

        }
    }
}