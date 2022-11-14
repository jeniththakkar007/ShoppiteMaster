using DataLayer.Helper;
using System;
using System.Web.Configuration;

namespace VendorPanel.usercontrol
{
    public partial class Image_uploadasync_uc : System.Web.UI.UserControl
    {
        private Product_Helper ph = new Product_Helper();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void fileupload()
        {
            if (fubanner.HasFile)
            {
                var orgid = ph.GetOrgID();
                AWS_Helper aw = new AWS_Helper();
                string fileconfigpath = WebConfigurationManager.AppSettings["filepath"];
                string filepath = fileconfigpath + orgid + "/Products";

                string bannerfilepath = filepath + "/fubanner";
                bannerfilepath = bannerfilepath + "/" + fubanner.FileName;
                imgbanner.ImageUrl = aw.uploadfile(fubanner, bannerfilepath);
            }
        }

        public string IMG_imgbanner
        {
            get { return imgbanner.ImageUrl; }
            set { imgbanner.ImageUrl = value; }
        }
    }
}