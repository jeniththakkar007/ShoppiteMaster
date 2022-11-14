using DataLayer.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace AdminPanel.Admin
{
    public partial class attribute_view : System.Web.UI.Page
    {
        private Entities db = new Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getattribute();
            }
        }

        protected void getattribute()
        {
            var q = (from b in db.Attributes_Setup
                     orderby b.AttributeName
                     select b);

            ListView1.DataSource = q.ToList();
            ListView1.DataBind();
        }

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string ID = ((Label)e.Item.FindControl("Label2")).Text;
            if (e.CommandName == "ed")
            {
                Response.Redirect("~/admin/attribute_add?ID=" + ID);
            }

            if (e.CommandName == "del")
            {
                int did = int.Parse(ID);
                Attributes_Setup up = db.Attributes_Setup.FirstOrDefault(u => u.AttributeId == did);

                db.Attributes_Setup.Remove(up);
                db.SaveChanges();

                Response.Redirect(Request.RawUrl);
            }
        }
    }
}