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
                Page.LoadComplete += new EventHandler(Page_PreRender);
                //getdata();
            }

        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            getdata();

        }

        protected void getdata()
        {
            String masterDropDown = (((this.Master) as MasterPage).FindControl("ddlorganization") as DropDownList).SelectedItem.Value;
            int selectedOrg = Convert.ToInt32(masterDropDown);

            Profile_Helper ph = new Profile_Helper();

            int profileid = ph.profile_return_id(Page.User.Identity.Name);



            var q = db.SP_Order_Master(selectedOrg).Where(u => u.ProfileId == selectedOrg && u.orderdeliverystatus==RadioButtonList1.SelectedValue);

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