using DataLayer.Models;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace AdminPanel.Admin
{
    public partial class Orders_All : System.Web.UI.Page
    {
        private Entities db = new Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.LoadComplete += new EventHandler(page_preRender);
                //getdata();
            }
        }

        private void page_preRender(object sender, EventArgs e)
        {
            getdata();
        }

        protected void getdata()
        {
            String masterDropDown = (((this.Master) as MasterPage).FindControl("ddlorganization") as DropDownList).SelectedItem.Value;
            int selectedOrg = Convert.ToInt32(masterDropDown);

            Profile_Helper ph = new Profile_Helper();

            int id = ph.profile_return_id(this.Page.User.Identity.Name);
            var q = db.f_Orders_All(selectedOrg).Where(u => u.orderdeliverystatus == RadioButtonList1.SelectedValue).OrderByDescending(u => u.InsertDate);

            GridView1.DataSource = q.ToList();
            GridView1.DataBind();
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getdata();
        }
    }
}