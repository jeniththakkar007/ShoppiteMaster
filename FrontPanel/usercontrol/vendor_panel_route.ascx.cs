using DataLayer.Models;
using System;

namespace FrontPanel.usercontrol
{
    public partial class vendor_panel_route : System.Web.UI.UserControl
    {
        private Entities db = new Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.Identity.Name != "")
            {
                Profile_Helper ph = new Profile_Helper();

                if (ph.isvendor_status(this.Page.User.Identity.Name) == false)
                {
                    LinkButton1.Visible = false;
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Vendor");
        }
    }
}