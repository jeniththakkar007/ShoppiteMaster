using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontPanel
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

           
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {





                Product_homepage.getparentcat();



                homepage_statusproducts.getproductstatus();

                //recently viewed show

                thumbnail_slider.getrecentlyviewed("Just For You");


                //mega offers

                thumbnail_slider1.getmegaoffers(10, "Mega Offers");

                homepage_brands.getbrands();
            }
        }
    }
}