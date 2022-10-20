using DataLayer.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminPanel.usercontrol
{
    public partial class Image_uploadasync_uc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void fileupload()
        {

            if (fubanner.HasFile)
            {

                //CheckFile cf = new CheckFile();


                //imgbanner.ImageUrl = cf.UploadImages(fubanner);

                AWS_Helper aw = new AWS_Helper();
                imgbanner.ImageUrl = aw.uploadfile(fubanner);
            }
        }



        public string IMG_imgbanner
        {
            get { return imgbanner.ImageUrl; }
            set { imgbanner.ImageUrl = value; }
        }
        
    }
}