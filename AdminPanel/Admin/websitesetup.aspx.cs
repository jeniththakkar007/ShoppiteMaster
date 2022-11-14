using DataLayer.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace AdminPanel.Admin
{
    public partial class websitesetup : System.Web.UI.Page
    {
        private Entities db = new Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getdata();
                if (Request.QueryString["ID"] != null)
                {
                    int Id = int.Parse(Request.QueryString["ID"].ToString());

                    Website_Setup wsu = db.Website_Setup.FirstOrDefault(u => u.WebsiteSetupId == Id);

                    txtsetupname.Text = wsu.ItemName;
                    txtvalue.Text = wsu.ItemValue.ToString();
                    txtdes.Text = wsu.ItemDescription; ;
                    CheckBox1.Checked = bool.Parse(wsu.IsActive.ToString());
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] == null)
            {
                Website_Setup ws = new Website_Setup();

                ws.ItemName = txtsetupname.Text;
                ws.ItemValue = decimal.Parse(txtvalue.Text);
                ws.ItemDescription = txtdes.Text;
                ws.IsActive = CheckBox1.Checked;
                ws.InsertDate = DateTime.Now;

                db.Website_Setup.Add(ws);
                db.SaveChanges();
            }
            else
            {
                int Id = int.Parse(Request.QueryString["ID"].ToString());

                Website_Setup wsu = db.Website_Setup.FirstOrDefault(u => u.WebsiteSetupId == Id);

                wsu.ItemName = txtsetupname.Text;
                wsu.ItemValue = decimal.Parse(txtvalue.Text);
                wsu.ItemDescription = txtdes.Text;
                wsu.IsActive = CheckBox1.Checked;
                wsu.InsertDate = DateTime.Now;

                db.SaveChanges();
            }

            Response.Redirect("~/admin/websitesetup");
        }

        protected void getdata()
        {
            var q = (from ws in db.Website_Setup
                     select ws);

            GridView1.DataSource = q.ToList();
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("~/admin/websitesetup?ID=" + GridView1.SelectedDataKey.Value);
        }
    }
}