using DataLayer.Models;
using System;
using System.Web.UI.WebControls;

namespace FrontPanel.usercontrol
{
    public partial class footerpages : System.Web.UI.UserControl
    {
        private Entities db = new Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ListView2_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string pgview = ((Label)e.Item.FindControl("Label1")).Text;
            string pgid = ((Label)e.Item.FindControl("Label2")).Text;
            string pgurl = ((Label)e.Item.FindControl("Label3")).Text;
            string isurl = ((Label)e.Item.FindControl("Label4")).Text;

            if (e.CommandName == "pgview")
            {
                if (isurl == "False")
                {
                    Response.RedirectToRoute("page", new { ID = pgid, pagetitle = pgview.Replace(" ", "-").Replace("/", "-").Replace("&", "").Replace(" ", "") });
                }
                else
                {
                    Response.Redirect(pgurl);
                }
            }
        }
    }
}