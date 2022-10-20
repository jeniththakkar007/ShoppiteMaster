using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontPanel.customer
{
    public partial class customer_profile : System.Web.UI.Page
    {


        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                

                Users_Profile us = db.Users_Profile.FirstOrDefault(u => u.UserName == this.Page.User.Identity.Name);

                if(us!=null)
                {

                    txtshopname.Text = us.ShopName;
                    txtphone.Text = us.ContactNumber;
                    tagline.Text = us.ShopDescription;
                   ImageUploadJquery_uc.Image_imgurl = us.Logo;
                }
            }
        }

      

        protected void Button1_Click(object sender, EventArgs e)
        {

            ImageUploadJquery_uc.fileupload();

            Users_Profile us = db.Users_Profile.FirstOrDefault(u => u.UserName == this.Page.User.Identity.Name);

            us.ShopName = txtshopname.Text;
            us.ContactNumber = txtphone.Text;
            us.ShopDescription = tagline.Text;
            us.Logo = ImageUploadJquery_uc.Image_imgurl;

            db.SaveChanges();

            Response.Redirect(Request.RawUrl);
        }



    }
}