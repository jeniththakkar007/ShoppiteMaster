using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VendorPanel.inbox
{
    public partial class msg_counter : System.Web.UI.UserControl
    {


        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {







            var q = (from m in db.Messages
                     where m.recipient == this.Page.User.Identity.Name && m.status == "UnRead"
                     select m).Count();




            lblmsg.Text = q.ToString();

        }
    }
}