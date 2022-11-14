using DataLayer.Models;
using System;
using System.Linq;

namespace AdminPanel.Admin
{
    public partial class attribute_add : System.Web.UI.Page
    {
        private Entities db = new Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    int id = int.Parse(Request.QueryString["ID"].ToString());

                    Attributes_Setup a = db.Attributes_Setup.FirstOrDefault(u => u.AttributeId == id);

                    txtattributename.Text = a.AttributeName;
                    txtdesc.Text = a.AttributeDescription;
                }
            }
        }

        protected void lnksave_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] == null)
            {
                Attributes_Setup a = new Attributes_Setup();

                a.AttributeName = txtattributename.Text;
                a.AttributeDescription = txtdesc.Text;
                a.InsertDate = DateTime.Now;
                a.UserName = this.Page.User.Identity.Name;

                db.Attributes_Setup.Add(a);
                db.SaveChanges();
            }
            else
            {
                int id = int.Parse(Request.QueryString["ID"].ToString());

                Attributes_Setup a = db.Attributes_Setup.FirstOrDefault(u => u.AttributeId == id);

                a.AttributeName = txtattributename.Text;
                a.AttributeDescription = txtdesc.Text;
                a.InsertDate = DateTime.Now;
                a.UserName = this.Page.User.Identity.Name;

                db.SaveChanges();
            }

            Response.Redirect("~/admin/attribute_view");
        }
    }
}