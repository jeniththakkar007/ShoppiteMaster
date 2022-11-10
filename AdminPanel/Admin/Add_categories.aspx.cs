
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
        AWS_Helper aw = new AWS_Helper();
        //CheckFile cf = new CheckFile();
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
                Page.LoadComplete += new EventHandler(Page_PreRender);
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            String masterDropDown = (((this.Master) as MasterPage).FindControl("ddlorganization") as DropDownList).SelectedItem.Value;
            int selectedOrg = Convert.ToInt32(masterDropDown);

            ddlcat.DataSource = db.sp_getcat(selectedOrg);
            ddlcat.DataTextField = "catnames";
            ddlcat.DataValueField = "ID";
            ddlcat.DataBind();

            ddlcat.Items.Insert(0, new ListItem("None", "0"));
        }



        protected void fileupload()
        {
            String masterDropDown = (((this.Master) as MasterPage).FindControl("ddlorganization") as DropDownList).SelectedItem.Value;
            int orgvalue = Convert.ToInt32(masterDropDown);
            string fileconfigpath = WebConfigurationManager.AppSettings["filepath"];
            string filepath = fileconfigpath + orgvalue + "/Category";
            if (fuicon.HasFile)
            {
                string categoryfilepath = filepath+"/fuicon";
                categoryfilepath = categoryfilepath +"/"+fuicon.FileName;
                imgicon.ImageUrl = aw.uploadfile(fuicon, categoryfilepath);
            }

            if (fubanner.HasFile)
            {
                string bannerfilepath = filepath +"/fubanner";
              
                bannerfilepath = bannerfilepath +"/"+fubanner.FileName;
                imgbanner.ImageUrl = aw.uploadfile(fubanner, bannerfilepath);
            }

        }



        protected void lnksave_Click(object sender, EventArgs e)
        {
            fileupload();

            CreateURLPath_Helper cuh = new CreateURLPath_Helper();
            String masterDropDown = (((this.Master) as MasterPage).FindControl("ddlorganization") as DropDownList).SelectedItem.Value;
            int orgvalue = Convert.ToInt32(masterDropDown);
            if (Request.QueryString["ID"]==null)
            {

                category_master cm = new category_master();

                cm.category_name = txtname.Text;
                cm.URLPath = cuh.createurlpath(txtname.Text);
                cm.parent_category_id = int.Parse(ddlcat.SelectedValue);
                cm.OrgId = orgvalue;
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
                cm.OrgId = orgvalue;
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