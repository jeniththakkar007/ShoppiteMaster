using DataLayer.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontPanel.usercontrol
{
    public partial class ImageUploadJquery_uc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



       
        public string Image_imgurl
        {
            get { return imgicon.ImageUrl; }
            set { imgicon.ImageUrl = value; }
        }


        public void fileupload()
        {
            if (fuicon.HasFile)
            {
                //CheckFile cs = new CheckFile();

                AWS_Helper aw = new AWS_Helper();

                imgicon.ImageUrl = aw.uploadfile(fuicon);
            }
        }
        
    }
}