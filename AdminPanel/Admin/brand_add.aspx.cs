using DataLayer.Models;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer.Helper;
using System.Web.Configuration;

namespace AdminPanel.Admin
{
    public partial class brand_add : System.Web.UI.Page
    {


        Entities db = new Entities();
        //CheckFile cf = new CheckFile();
        protected void Page_PreRender(object sender, EventArgs e)
        {
            getcat();
            if(Request.QueryString["ID"]!=null)
            {

                int id = int.Parse(Request.QueryString["ID"].ToString());
                Brand b = db.Brands.FirstOrDefault(u => u.BrandId == id);

                ddlcategory.SelectedValue = b.Category_Id.ToString();
                txtbrandname.Text = b.BrandName;
                txtdesc.Text = b.BrandDescription;
                imgicon.ImageUrl = b.BrandImage;
                chckpublish.Checked = bool.Parse(b.IsPublished.ToString());

            
            }

        }



        protected void getcat()
        {
            String masterDropDown = (((this.Master) as MasterPage).FindControl("ddlorganization") as DropDownList).SelectedItem.Value;
            int selectedOrg = Convert.ToInt32(masterDropDown);
            var q=(from c in db.category_master
                       where c.parent_category_id==0 && c.OrgId == selectedOrg
                       select c);

            ddlcategory.DataTextField = "category_name";
            ddlcategory.DataValueField = "category_id";


            ddlcategory.DataSource = q.ToList();
            ddlcategory.DataBind();
        }


        protected void fileupload()
        {
            String masterDropDown = (((this.Master) as MasterPage).FindControl("ddlorganization") as DropDownList).SelectedItem.Value;
            int orgid = Convert.ToInt32(masterDropDown);
            string fileconfigpath = WebConfigurationManager.AppSettings["filepath"];
            string filepath = fileconfigpath + orgid + "\\Brands";
            if (fuicon.HasFile)
            {
                string bannerfilepath = filepath + "\\fuicon";
                if (!System.IO.Directory.Exists(bannerfilepath))
                {
                    System.IO.Directory.CreateDirectory(bannerfilepath);
                }
                bannerfilepath = bannerfilepath + "\\" + fuicon.FileName;
                fuicon.SaveAs(bannerfilepath);
                imgicon.ImageUrl = bannerfilepath;
            }

        }

        protected void lnksave_Click(object sender, EventArgs e)
        {

            String masterDropDown = (((this.Master) as MasterPage).FindControl("ddlorganization") as DropDownList).SelectedItem.Value;
            int selectedOrg = Convert.ToInt32(masterDropDown);
            fileupload();
            if (Request.QueryString["ID"] == null)
            {


                Brand b = new Brand();

                b.Category_Id = int.Parse(ddlcategory.SelectedValue);
                b.BrandName = txtbrandname.Text;
                b.BrandDescription = txtdesc.Text;
                b.BrandImage = imgicon.ImageUrl;
                b.IsPublished = chckpublish.Checked;
                b.InsertDate = DateTime.Now;
                b.UserName = this.Page.User.Identity.Name;
                b.OrgId = selectedOrg;

                db.Brands.Add(b);
                db.SaveChanges();
            }

            else
            {

                int id = int.Parse(Request.QueryString["ID"].ToString());
                Brand b = db.Brands.FirstOrDefault(u => u.BrandId == id);

                b.Category_Id = int.Parse(ddlcategory.SelectedValue);
                b.BrandName = txtbrandname.Text;
                b.BrandDescription = txtdesc.Text;
                b.BrandImage = imgicon.ImageUrl;
                b.IsPublished = chckpublish.Checked;
                b.ModifiedDate = DateTime.Now;
                b.UserName = this.Page.User.Identity.Name;
                b.OrgId = selectedOrg;
                db.SaveChanges();
            }


            Response.Redirect("~/admin/brand_view");
        }
    }
}