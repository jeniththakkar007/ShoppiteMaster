using DataLayer.Models;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminPanel.Admin
{
    public partial class CustomersAll : System.Web.UI.Page
    {
        private Entities db = new Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
            var q = db.f_Profile_All("Client", selectedOrg);

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