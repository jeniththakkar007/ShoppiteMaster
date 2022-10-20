using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontPanel.usercontrol
{
    public partial class detail_payment_accepted : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


       
       public void showimage(string status)
        {

            if(status=="True")
            {

                Entities db = new Entities();

                Ads_Detail ad = db.Ads_Detail.FirstOrDefault(u => u.AdsPageId == 8);

                if (ad != null)
                {
                    Image2.ImageUrl = ad.Image;
                    Image2.Visible = true;
                }
            }

            else
            {

                Image2.Visible = false;
            }

        }

    }
}