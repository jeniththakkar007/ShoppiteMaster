
using DataLayer;
using DataLayer.Helper;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminPanel.Admin
{
    public partial class Add_categories : System.Web.UI.Page
    {


        Entities db = new Entities();
        //CheckFile cf = new CheckFile();
        //AWS_Helper aw = new AWS_Helper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Request.QueryString["ID"]!=null)
                {
                    int id = int.Parse(Request.QueryString["ID"].ToString());
                    category_master cm = db.category_master.FirstOrDefault(u => u.category_id == id);

                    ddlcat.DataBind();
                    txtname.Text = cm.category_name;
                    ddlcat.SelectedValue = cm.parent_category_id.ToString();
                    ddlorg.SelectedValue = cm.OrgId != null ? cm.OrgId.ToString(): "0" ;
                    txtdescription.Text = cm.Description;
                    imgicon.ImageUrl = cm.Icon;
                    imgbanner.ImageUrl = cm.Banner;
                    chkpublish.Checked = bool.Parse(cm.IsPublished.ToString());
                    chkshowhomepage.Checked = bool.Parse(cm.IsShowHomePage.ToString());
                    chkincludeinmenu.Checked = bool.Parse(cm.IsIncludeMenu.ToString());
                    txtpagename.Text = cm.SEO_PageName;
                    txtmetatitle.Text = cm.SEO_Title;
                    txtkeywords.Text = cm.SEO_Keyword;
                    txtmetadescription.Text = cm.SEO_Description;
                    txtdisplayorder.Text = cm.DisplayOrder.ToString();

                }
            }
        }



        protected void fileupload()
        {

            string fileconfigpath = WebConfigurationManager.AppSettings["filepath"];
            var orgvalue = ddlorg.SelectedValue;
            string filepath = fileconfigpath + orgvalue + "\\Category";
            if (!System.IO.Directory.Exists(fileconfigpath+orgvalue))
                System.IO.Directory.CreateDirectory(fileconfigpath + orgvalue);
            if (fuicon.HasFile)
            {
                string categoryfilepath = filepath+"\\fuicon";
                if (!System.IO.Directory.Exists(categoryfilepath))
                {
                    System.IO.Directory.CreateDirectory(categoryfilepath);
                }
                categoryfilepath = categoryfilepath +"\\"+fuicon.FileName;
                fuicon.SaveAs(categoryfilepath);
                imgicon.ImageUrl = categoryfilepath;
            }

            if (fubanner.HasFile)
            {
                string bannerfilepath = filepath +"\\fubanner";
                if (!System.IO.Directory.Exists(bannerfilepath))
                {
                    System.IO.Directory.CreateDirectory(bannerfilepath);
                }
                bannerfilepath = bannerfilepath +"\\"+fubanner.FileName;
                fubanner.SaveAs(bannerfilepath);
                imgbanner.ImageUrl = bannerfilepath;
            }

        }



        protected void lnksave_Click(object sender, EventArgs e)
        {
            fileupload();

            CreateURLPath_Helper cuh = new CreateURLPath_Helper();

            if(Request.QueryString["ID"]==null)
            {

                category_master cm = new category_master();

                cm.category_name = txtname.Text;
                cm.URLPath = cuh.createurlpath(txtname.Text);
                cm.parent_category_id = int.Parse(ddlcat.SelectedValue);
                cm.OrgId = int.Parse(ddlorg.SelectedValue);
                cm.Description = txtdescription.Text;
                cm.Icon = imgicon.ImageUrl;
                cm.Banner = imgbanner.ImageUrl;
                cm.IsPublished = chkpublish.Checked;
                cm.IsShowHomePage = chkshowhomepage.Checked;
                cm.IsIncludeMenu = chkincludeinmenu.Checked;
                cm.SEO_PageName = txtpagename.Text;
                cm.SEO_Title = txtmetatitle.Text;
                cm.SEO_Keyword = txtkeywords.Text;
                cm.SEO_Description = txtmetadescription.Text;
                cm.InsertDate = DateTime.Now;
                cm.UserName = this.Page.User.Identity.Name;
                cm.DisplayOrder = int.Parse(txtdisplayorder.Text);
                db.category_master.Add(cm);
                db.SaveChanges();
            }
            

            else
            {

                int id = int.Parse(Request.QueryString["ID"].ToString());
                category_master cm = db.category_master.FirstOrDefault(u => u.category_id == id);

                cm.category_name = txtname.Text;
                cm.URLPath = cuh.createurlpath(txtname.Text);
                cm.parent_category_id = int.Parse(ddlcat.SelectedValue);
                cm.OrgId = int.Parse(ddlorg.SelectedValue);
                cm.Description = txtdescription.Text;
                cm.Icon = imgicon.ImageUrl;
                cm.Banner = imgbanner.ImageUrl;
                cm.IsPublished = chkpublish.Checked;
                cm.IsShowHomePage = chkshowhomepage.Checked;
                cm.IsIncludeMenu = chkincludeinmenu.Checked;
                cm.SEO_PageName = txtpagename.Text;
                cm.SEO_Title = txtmetatitle.Text;
                cm.SEO_Keyword = txtkeywords.Text;
                cm.SEO_Description = txtmetadescription.Text;
                cm.ModifiedDate = DateTime.Now;
                cm.UserName = this.Page.User.Identity.Name;

                cm.DisplayOrder = int.Parse(txtdisplayorder.Text);
                db.SaveChanges();

            }

            Response.Redirect("~/admin/category_view");


        }
    }
}