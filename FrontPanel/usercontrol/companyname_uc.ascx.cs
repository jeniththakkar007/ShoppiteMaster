using DataLayer.Helper;
using System;

namespace FrontPanel.usercontrol
{
    public partial class companyname_uc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Website_Setup_Helper ws = new Website_Setup_Helper();

                ws.getwebsiteinfo();

                lblcompanyname.Text = ws.companyname;
            }
        }
    }
}