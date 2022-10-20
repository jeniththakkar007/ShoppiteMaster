using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminPanel.Admin
{
    public partial class Orders_All : System.Web.UI.Page
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


            Profile_Helper ph = new Profile_Helper();


            int id = ph.profile_return_id(this.Page.User.Identity.Name);
            var q = db.f_Orders_All().Where(u =>  u.orderdeliverystatus == RadioButtonList1.SelectedValue).OrderByDescending(u => u.InsertDate);


            GridView1.DataSource = q.ToList();
            GridView1.DataBind();
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getdata();
        }
    }
}