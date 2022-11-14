using DataLayer.Helper;
using System;
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
                AWS_Helper aw = new AWS_Helper();

                //1350 500
                String masterDropDown = (((this.Master) as MasterPage).FindControl("ddlorganization") as DropDownList).SelectedItem.Value;
                int orgid = Convert.ToInt32(masterDropDown);
                string fileconfigpath = WebConfigurationManager.AppSettings["filepath"];
                string filepath = fileconfigpath + orgid + "/SocialMedia";
                if (FileUpload1.HasFile)
                {
                    string bannerfilepath = filepath + "/files";

                    bannerfilepath = bannerfilepath + "/" + FileUpload1.FileName;

                    SqlDataSource1.InsertParameters.Add("Image", aw.uploadfile(FileUpload1));

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