using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontPanel.usercontrol
{
    public partial class header_links : System.Web.UI.UserControl
    {

        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                getheaderlink();
            }
        }


        protected void getheaderlink()
        {
            var q=(from pc in db.PageCategories
                       where pc.Type=="Header" && pc.Status=="Active"
                       orderby pc.Sortnumber
                       select pc);


            ListView1.DataSource = q.ToList();
            ListView1.DataBind();
        }

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
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