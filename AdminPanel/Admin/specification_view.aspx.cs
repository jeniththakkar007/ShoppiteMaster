using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminPanel.Admin
{
    public partial class specification_view : System.Web.UI.Page
    {
        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                getattribute();
            }
        }


        protected void getattribute()
        {


            var q = (from b in db.Specification_Setup
                     join a in db.Attributes_Setup on b.AttributeId equals a.AttributeId
                     orderby b.SpecificationName
                     select new
                     {

                         Specificationid= b.SpecificationId,
                         SpecificationName=b.SpecificationName,
                         Attributename=a.AttributeName


                     }
                     );


            ListView1.DataSource = q.ToList();
            ListView1.DataBind();


        }

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string ID = ((Label)e.Item.FindControl("Label2")).Text;
            if (e.CommandName == "ed")
            {

                Response.Redirect("~/admin/specification_add?ID=" + ID);
            }

            if (e.CommandName == "del")
            {

                int did = int.Parse(ID);
                Specification_Setup up = db.Specification_Setup.FirstOrDefault(u => u.SpecificationId == did);


                db.Specification_Setup.Remove(up);
                db.SaveChanges();

                Response.Redirect(Request.RawUrl);
            }
        }
    }
}