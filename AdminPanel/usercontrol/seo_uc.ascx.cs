using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminPanel.usercontrol
{
    public partial class seo_uc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }




        

        public string SEO_txtpagename
        {
            get { return txtpagename.Text; }
            set { txtpagename.Text = value; }
        }



        public string SEO_txtmetatitle
        {
            get { return txtmetatitle.Text; }
            set { txtmetatitle.Text = value; }
        }


        public string SEO_txtkeywords
        {
            get { return txtkeywords.Text; }
            set { txtkeywords.Text = value; }
        }


        public string SEO_txtmetadescription
        {
            get { return txtmetadescription.Text; }
            set { txtmetadescription.Text = value; }
        }

        
    }
}