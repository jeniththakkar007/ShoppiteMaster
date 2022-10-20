using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminPanel.Admin
{
    public partial class newsletteremail : System.Web.UI.Page
    {


        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {


            if(!IsPostBack)
            {
                var q = (from nl in db.NewsLetters
                         orderby nl.InsertDate
                         select nl);

                GridView1.DataSource = q.ToList();
                GridView1.DataBind();

            }

        }



    }
}