using DataLayer.Helper;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
            
            if (!IsPostBack)
            {
                FU1.Attributes["onchange"] = "UploadFile(this)";

                FileUpload1.Attributes["onchange"] = "UploadFile1(this)";

                FileUpload2.Attributes["onchange"] = "UploadFile2(this)";
                Page.LoadComplete += new EventHandler(Page_PreRender);
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            String masterDropDown = (((this.Master) as MasterPage).FindControl("ddlorganization") as DropDownList).SelectedItem.Value;
            int selectedOrg = Convert.ToInt32(masterDropDown);

            string constr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT Logo, logowidth, logoheight, CompanyName, Address, SupportContact, FooterLogo, Favicon, Title, Keyword, Description FROM dbo.Logo where orgid = @orgid";
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@orgid", selectedOrg);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        string img = (string)dt.Rows[0]["Logo"];
                        int width = dt.Rows[0]["logowidth"] !=null ? Convert.ToInt32(dt.Rows[0]["logowidth"]):0;
                        int height = dt.Rows[0]["logoheight"]!=null? Convert.ToInt32(dt.Rows[0]["logoheight"]):0;
                        string companyname = dt.Rows[0]["companyname"]!=null?(string)dt.Rows[0]["companyname"]:"";
                        string address = (string)dt.Rows[0]["address"];
                        string supportcontact = (string)dt.Rows[0]["supportcontact"];
                        string FooterLogo = (string)dt.Rows[0]["FooterLogo"];
                        string favicon = (string)dt.Rows[0]["favicon"];

                        string Title = (string)dt.Rows[0]["Title"];
                        string Keyword = (string)dt.Rows[0]["Keyword"];
                        string Description = (string)dt.Rows[0]["Description"];

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

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String masterDropDown = (((this.Master) as MasterPage).FindControl("ddlorganization") as DropDownList).SelectedItem.Value;
            int selectedOrg = Convert.ToInt32(masterDropDown);
            string constr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            string strSQL = string.Empty;
            var count = 0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT Logo, logowidth, logoheight, CompanyName, Address, SupportContact, FooterLogo, Favicon, Title, Keyword, Description FROM dbo.Logo where orgid = @orgid";
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@orgid", selectedOrg);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        count = dt.Rows.Count;
                    }
                }
            }
            if (count > 0)
            {
                strSQL = "INSERT INTO dbo.Logo ([Logo] ,[logowidth]";
                strSQL += ",[logoheight]";
                strSQL += ",[CompanyName]";
                strSQL += ",[Address]";
                strSQL += ",[SupportContact]";
                strSQL += ",[WebsiteName]";
                strSQL += ",[FooterLogo]";
                strSQL += ",[Favicon]";
                strSQL += ",[Title]";
                strSQL += ",[Keyword]";
                strSQL += ",[Description]";
                strSQL += ",[OrgId])";
                strSQL += "Values(@Image,@logowidth,@logoheight,@companyname,@address,@support,'',@footerlogo,@favicon,@title,@keyword,@description,@orgid)";
            }
            else {
                strSQL = "UPDATE dbo.Logo SET Logo = @Image, logowidth = @logowidth, logoheight = @logoheight, CompanyName = @companyname, Address = @address, SupportContact = @support, FooterLogo = @footerlogo, Favicon = @favicon, Title = @title, Keyword = @keyword, Description = @description where OrgId = @orgid";
            }
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    con.Open();
                    cmd.CommandText = strSQL;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@Image", Image2.ImageUrl);
                    cmd.Parameters.AddWithValue("@logowidth", 0);
                    cmd.Parameters.AddWithValue("@logoheight", 0);
                    cmd.Parameters.AddWithValue("@companyname", TextBox3.Text);
                    cmd.Parameters.AddWithValue("@address", TextBox4.Text);
                    cmd.Parameters.AddWithValue("@support", TextBox5.Text);
                    cmd.Parameters.AddWithValue("@footerlogo", Image1.ImageUrl);
                    cmd.Parameters.AddWithValue("@favicon", Image3.ImageUrl);
                    cmd.Parameters.AddWithValue("@title", txtmetatitle.Text);
                    cmd.Parameters.AddWithValue("@keyword", txtkeywords.Text);
                    cmd.Parameters.AddWithValue("@description", txtmetadescription.Text);
                    cmd.Parameters.AddWithValue("@orgid", selectedOrg);
                    cmd.ExecuteNonQuery();
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record updated successfully');", true);
                }

            }
            
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
                    string bannerfilepath = fileconfigpath + selectedOrg + "/Logo/" + FileUpload2.FileName;
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