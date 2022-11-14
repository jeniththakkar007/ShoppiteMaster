using DataLayer.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace FrontPanel.usercontrol
{
    public partial class script_footer : System.Web.UI.UserControl
    {
        private Entities db = new Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void getdata(string type)
        {
            if (!IsPostBack)
            {
                var q = (from wss in db.Website_Setup_Script
                         where wss.Type == type
                         select wss);

                ListView1.DataSource = q.ToList();
                ListView1.DataBind();
            }
        }
    }
}