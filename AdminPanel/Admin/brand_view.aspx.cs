using DataLayer.Models;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminPanel.Admin
{
    public partial class brand_view : System.Web.UI.Page
    {
        private Entities db = new Entities();

        protected void Page_PreRender(object sender, EventArgs e)
        {
            getbrands();
        }

        protected void getbrands()
        {
            String masterDropDown = (((this.Master) as MasterPage).FindControl("ddlorganization") as DropDownList).SelectedItem.Value;
            int selectedOrg = Convert.ToInt32(masterDropDown);
            var q = (from b in db.Brands
                     where b.OrgId == selectedOrg
                     orderby b.BrandName
                     select b);

            ListView1.DataSource = q.ToList();
            ListView1.DataBind();
        }

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string ID = ((Label)e.Item.FindControl("Label2")).Text;
            if (e.CommandName == "ed")
            {
                Response.Redirect("~/admin/brand_add?ID=" + ID);
            }

            if (e.CommandName == "del")
            {
                int did = int.Parse(ID);

                Brand b = db.Brands.FirstOrDefault(u => u.BrandId == did);
                if (b != null)
                {
                    db.Brands.Remove(b);
                    db.SaveChanges();

                    Response.Redirect(Request.RawUrl);
                }
            }
        }
    }
}