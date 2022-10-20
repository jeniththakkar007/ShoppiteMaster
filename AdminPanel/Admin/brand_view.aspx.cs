using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminPanel.Admin
{
    public partial class brand_view : System.Web.UI.Page
    {

        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                getbrands();
            }
        }


        protected void getbrands()
        {


            var q=(from b in db.Brands
                      orderby b.BrandName
                       select b);


            ListView1.DataSource = q.ToList();
            ListView1.DataBind();


        }

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string ID = ((Label)e.Item.FindControl("Label2")).Text;
            if (e.CommandName == "ed")
            {

                Response.Redirect("~/admin/brand_add?ID="+ ID);
            }

            if (e.CommandName == "del")
            {

                int did = int.Parse(ID);

                Brand b = db.Brands.FirstOrDefault(u => u.BrandId == did);
                if(b!=null)
                {

                    db.Brands.Remove(b);
                    db.SaveChanges();

                    Response.Redirect(Request.RawUrl);

                }
            }
        }
        
        
    }
}