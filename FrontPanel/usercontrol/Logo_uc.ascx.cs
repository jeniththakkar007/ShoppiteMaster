using DataLayer.Helper;
using System;

namespace FrontPanel.usercontrol
{
    public partial class Logo_uc : System.Web.UI.UserControl
    {
        private Website_Setup_Helper wsh = new Website_Setup_Helper();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                wsh.getwebsiteinfo();
                Image1.ImageUrl = wsh.logo.ToString();
            }
        }
    }
}