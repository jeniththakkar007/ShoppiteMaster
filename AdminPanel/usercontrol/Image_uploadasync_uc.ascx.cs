using DataLayer.Helper;
using System;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminPanel.usercontrol
{
    public partial class Image_uploadasync_uc : System.Web.UI.UserControl
    {
        private AWS_Helper aw = new AWS_Helper();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void fileupload()
        {
            String masterDropDown = (((this.Parent.Page.Master) as MasterPage).FindControl("ddlorganization") as DropDownList).SelectedItem.Value;
            int orgid = Convert.ToInt32(masterDropDown);
            string fileconfigpath = WebConfigurationManager.AppSettings["filepath"];
            string filepath = fileconfigpath + orgid + "/Products";
            if (fubanner.HasFile)
            {
                string bannerfilepath = filepath + "/fubanner";
                bannerfilepath = bannerfilepath + "/" + fubanner.FileName;

                imgbanner.ImageUrl = aw.uploadfile(fubanner, bannerfilepath);
                //CheckFile cf = new CheckFile();

                //imgbanner.ImageUrl = cf.UploadImages(fubanner);
            }
        }

        public string IMG_imgbanner
        {
            get { return imgbanner.ImageUrl; }
            set { imgbanner.ImageUrl = value; }
        }
    }
}