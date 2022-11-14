using DataLayer.Helper;
using System;
using System.Data;
using System.IO;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adminweb.Admin
{
    public partial class logo : System.Web.UI.Page
    {
        private AWS_Helper aw = new AWS_Helper();

        //CheckFile cs = new CheckFile();
        protected void Page_Load(object sender, EventArgs e)
        {
            FU1.Attributes["onchange"] = "UploadFile(this)";

            FileUpload1.Attributes["onchange"] = "UploadFile1(this)";

            FileUpload2.Attributes["onchange"] = "UploadFile2(this)";
            if (!IsPostBack)
            {
                DataView dview = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);

                string img = (string)dview.Table.Rows[0]["Logo"];
                int width = (int)dview.Table.Rows[0]["logowidth"];
                int height = (int)dview.Table.Rows[0]["logoheight"];
                string companyname = (string)dview.Table.Rows[0]["companyname"];
                string address = (string)dview.Table.Rows[0]["address"];
                string supportcontact = (string)dview.Table.Rows[0]["supportcontact"];
                string FooterLogo = (string)dview.Table.Rows[0]["FooterLogo"];
                string favicon = (string)dview.Table.Rows[0]["favicon"];

                string Title = (string)dview.Table.Rows[0]["Title"];
                string Keyword = (string)dview.Table.Rows[0]["Keyword"];
                string Description = (string)dview.Table.Rows[0]["Description"];

                Image2.ImageUrl = img.ToString();
                Image1.ImageUrl = FooterLogo.ToString();
                Image3.ImageUrl = favicon.ToString();
                //TextBox1.Text = width.ToString();
                //TextBox2.Text = height.ToString();

                TextBox3.Text = companyname.ToString();

                TextBox4.Text = address.ToString();

                TextBox5.Text = supportcontact.ToString();

                txtmetatitle.Text = Title;
                txtkeywords.Text = Keyword;
                txtmetadescription.Text = Description;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlDataSource1.UpdateParameters.Add("Image", Image2.ImageUrl);
            SqlDataSource1.UpdateParameters.Add("footerlogo", Image1.ImageUrl);
            SqlDataSource1.UpdateParameters.Add("favicon", Image3.ImageUrl);
            SqlDataSource1.Update();
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record updated successfully');", true);
        }

        protected void Upload(object sender, EventArgs e)
        {
            if (FU1.HasFile)
            {
                String masterDropDown = (((this.Master) as MasterPage).FindControl("ddlorganization") as DropDownList).SelectedItem.Value;
                int selectedOrg = Convert.ToInt32(masterDropDown);
                string fileconfigpath = WebConfigurationManager.AppSettings["filepath"];
                string filepath = fileconfigpath + selectedOrg + "/Logos/" + FU1.FileName;

                Image2.ImageUrl = aw.uploadfile(FU1, filepath);
            }
        }

        protected void Upload1(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                String masterDropDown = (((this.Master) as MasterPage).FindControl("ddlorganization") as DropDownList).SelectedItem.Value;
                int selectedOrg = Convert.ToInt32(masterDropDown);
                string fileconfigpath = WebConfigurationManager.AppSettings["filepath"];
                string bannerfilepath = fileconfigpath + selectedOrg + "/Logo/" + FileUpload1.FileName;
                Image1.ImageUrl = aw.uploadfile(FileUpload1, bannerfilepath);
            }
        }

        protected void Upload2(object sender, EventArgs e)
        {
            if (FileUpload2.HasFile)
            {
                string ext = Path.GetExtension(FileUpload2.FileName).ToLower();

                if (ext == ".ico")
                {
                    String masterDropDown = (((this.Master) as MasterPage).FindControl("ddlorganization") as DropDownList).SelectedItem.Value;
                    int selectedOrg = Convert.ToInt32(masterDropDown);
                    string fileconfigpath = WebConfigurationManager.AppSettings["filepath"];
                    string bannerfilepath = fileconfigpath + selectedOrg + "\\Logo\\" + FileUpload2.FileName;
                    Image3.ImageUrl = aw.uploadfile(FileUpload2, bannerfilepath);
                }
                else
                {
                    lblerror.Text = ".ico favicon required";
                }
            }
        }
    }
}