using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VendorPanel.Admin
{
    public partial class Order_Master : System.Web.UI.Page
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
            Profile_Helper ph = new Profile_Helper();

            int profileid = ph.profile_return_id(Page.User.Identity.Name);



            var q = db.SP_Order_Master(profileid).Where(u => u.ProfileId == profileid && u.orderdeliverystatus==RadioButtonList1.SelectedValue);

            if(txtsearch.Text!=string.Empty)
            {

                q = q.Where(u => u.orderid.ToLower().Contains(txtsearch.Text.ToLower()));
            }

            ListView1.DataSource = q.ToList();
            ListView1.DataBind();

        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getdata();

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            getdata();
        }
    }
}