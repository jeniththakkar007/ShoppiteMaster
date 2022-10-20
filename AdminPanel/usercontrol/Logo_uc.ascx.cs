using DataLayer.Helper;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontPanel.usercontrol
{
    public partial class Logo_uc : System.Web.UI.UserControl
    {

        
        protected void Page_Load(object sender, EventArgs e)
        {


            if(!IsPostBack)
            {

                Website_Setup_Helper ws = new Website_Setup_Helper();

                ws.getwebsiteinfo();

                Image1.ImageUrl = ws.logo;
                
            }
        }
    }
}