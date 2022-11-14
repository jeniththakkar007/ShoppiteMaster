using DataLayer.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace Adminweb.Admin
{
    public partial class PageDetails : System.Web.UI.Page
    {
        private Entities db = new Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getpagecat();
            }
        }

        protected void getpagecat()
        {
            var q = (from pg in db.PageCategories
                     where pg.IsURL == false
                     select pg);

            ddlpage.DataTextField = "PageCategory1";
            ddlpage.DataValueField = "PageCategoryId";

            ddlpage.DataSource = q.ToList();
            ddlpage.DataBind();
        }

        protected void getpagetext(int id)
        {
            PageCategoryDetail pcd = db.PageCategoryDetails.FirstOrDefault(u => u.PageCategoryId == id);

            if (pcd != null)
            {
                txtdetail.Text = pcd.PageCategoryDescriptoin;
            }
        }

        protected void ddlpage_SelectedIndexChanged(object sender, EventArgs e)
        {
            getpagetext(int.Parse(ddlpage.SelectedValue));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(ddlpage.SelectedValue);
            PageCategoryDetail pcd = db.PageCategoryDetails.FirstOrDefault(u => u.PageCategoryId == id);

            if (pcd == null)
            {
                PageCategoryDetail pd = new PageCategoryDetail();

                pd.PageCategoryId = id;
                pd.PageCategoryDescriptoin = txtdetail.Text;
                pd.InsertDate = DateTime.Now;

                db.PageCategoryDetails.Add(pd);
                db.SaveChanges();
            }
            else
            {
                pcd.PageCategoryId = id;
                pcd.PageCategoryDescriptoin = txtdetail.Text;
                pcd.InsertDate = DateTime.Now;

                db.SaveChanges();
            }

            lblerror.Text = "Updated successfully";
        }
    }
}