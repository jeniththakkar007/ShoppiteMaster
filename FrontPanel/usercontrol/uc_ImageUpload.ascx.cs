using DataLayer.Helper;
using System;

namespace FrontPanel.user_controls
{
    public partial class uc_ImageUpload : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FileUpload1.Attributes["onchange"] = "UploadFile(this)";

            //Image img = (Image)this.UploadImage.FindControl("Image1");
        }

        protected void Upload(object sender, EventArgs e)
        {
            //CheckFile image = new CheckFile();
            AWS_Helper aw = new AWS_Helper();
            Image1.ImageUrl = aw.uploadfile(FileUpload1);
        }

        public string ImageURl
        {
            get { return Image1.ImageUrl; }
            set { Image1.ImageUrl = value; }
        }
    }
}