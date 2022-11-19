using DataLayer.Helper;
using System;

namespace FrontPanel.usercontrol
{
    public partial class Logo_uc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*ws.logo*/

                Image1.ImageUrl = "~/images/shopitelogo.png";
            }
        }
    }
}