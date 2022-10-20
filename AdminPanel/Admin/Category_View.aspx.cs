using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminPanel.Admin
{
    public partial class Category_View : System.Web.UI.Page
    {

        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {




                var q = (from f in db.f_All_getcat()
                         join c in db.category_master on f.ID equals c.category_id
                         orderby f.catnames
                         where c.IsPublished==true
                        
                             select f
                             );
                    
                    
                    
                  


                ListView1.DataSource = q.ToList();
                ListView1.DataBind();
            }
        }

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string ID = ((Label)e.Item.FindControl("Label2")).Text;
            if (e.CommandName == "ed")
            {

                Response.Redirect("~/admin/Add_categories?ID=" + ID);
            }




            if (e.CommandName == "del")
            {

                int did = int.Parse(ID);

                category_master ad = db.category_master.FirstOrDefault(u => u.category_id == did);

                db.category_master.Remove(ad);
                db.SaveChanges();

                Response.Redirect(Request.RawUrl);

            }
        }
    }
}