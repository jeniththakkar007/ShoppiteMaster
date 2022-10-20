using DataLayer.Models;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer.Helper;

namespace AdminPanel.Admin
{
    public partial class brand_add : System.Web.UI.Page
    {


        Entities db = new Entities();
        //CheckFile cf = new CheckFile();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
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
        }



        protected void getcat()
        {

            var q=(from c in db.category_master
                       where c.parent_category_id==0
                       select c);

            ddlcategory.DataTextField = "category_name";
            ddlcategory.DataValueField = "category_id";


            ddlcategory.DataSource = q.ToList();
            ddlcategory.DataBind();
        }


        protected void fileupload()
        {
            if (fuicon.HasFile)
            {


                  AWS_Helper aw = new AWS_Helper();


                  imgicon.ImageUrl = aw.uploadfile(fuicon);
            }

          



        }

        protected void lnksave_Click(object sender, EventArgs e)
        {


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

                db.SaveChanges();
            }


            Response.Redirect("~/admin/brand_view");
        }
    }
}