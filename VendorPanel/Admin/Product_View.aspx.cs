
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VendorPanel.Admin
{
    public partial class Product_View : System.Web.UI.Page
    {


        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            getdata();
        }

        protected void getdata()
        {
            Profile_Helper ph = new Profile_Helper();

            int profileid= ph.profile_return_id(this.Page.User.Identity.Name);
            var q=(from p in db.Product_Basic
                   where p.ProfileId==profileid && p.IsPublished==true
                       select p);


            ListView1.DataSource = q.ToList();
            ListView1.DataBind();
        }

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string ID = ((Label)e.Item.FindControl("Label2")).Text;
            if (e.CommandName == "ed")
            {

                Response.Redirect("~/admin/Product_Add?ID=" + ID);
            }

            if (e.CommandName == "del")
            {

                Guid id = Guid.Parse(ID);

                Product_Basic pb = db.Product_Basic.FirstOrDefault(u => u.ProductGUID == id);

                db.Product_Basic.Remove(pb);
                db.SaveChanges();
                getdata();
            }
        }


    }
}