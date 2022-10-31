using DataLayer.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminPanel.Admin
{
    public partial class AddSocialMedia : System.Web.UI.Page
    {


        //CheckFile ch = new CheckFile();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                //1350 500
                String masterDropDown = (((this.Master) as MasterPage).FindControl("ddlorganization") as DropDownList).SelectedItem.Value;
                int orgid = Convert.ToInt32(masterDropDown);
                string fileconfigpath = WebConfigurationManager.AppSettings["filepath"];
                string filepath = fileconfigpath + orgid + "\\SocialMedia";
                if (FileUpload1.HasFile)
                {

                    //System.Drawing.Image img = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream);
                    //int height = img.Height;
                    //int width = img.Width;
                    //decimal size = Math.Round(((decimal)FileUpload1.PostedFile.ContentLength / (decimal)1024), 2);

                    //FileUpload1.SaveAs(Server.MapPath("~/DynamicImage/" + Path.GetFileName(FileUpload1.FileName)));

                    string bannerfilepath = filepath + "\\files";
                    if (!System.IO.Directory.Exists(bannerfilepath))
                    {
                        System.IO.Directory.CreateDirectory(bannerfilepath);
                    }
                    bannerfilepath = bannerfilepath + "\\" + FileUpload1.FileName;
                    FileUpload1.SaveAs(bannerfilepath);

                    SqlDataSource1.InsertParameters.Add("Image", bannerfilepath);

                    SqlDataSource1.Insert();
                    lblMessage.Visible = true;
                  
                    GridView1.DataBind();


                }

            }
            catch (Exception ex)
            {

                lblMessage.Visible = true;
                lblMessage.Text = ex.Message;
            }

        }
    }
}