using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminPanel.Admin
{
    public partial class specification_add : System.Web.UI.Page
    {

        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {
                getattribute();
                if(Request.QueryString["ID"]!=null)
                {
                    int id = int.Parse(Request.QueryString["ID"].ToString());

                    Specification_Setup ss = db.Specification_Setup.FirstOrDefault(u => u.SpecificationId == id);


                    ddlattribute.SelectedValue = ss.AttributeId.ToString();
                    txtspecificationname.Text = ss.SpecificationName;
                    txtdesc.Text = ss.SpecificiatoinDescription;

                   

                }
            }

        }


        protected void getattribute()
        {

            var q=(from a in db.Attributes_Setup 
                       orderby a.AttributeName 
                       select a);


            ddlattribute.DataTextField = "AttributeName";
            ddlattribute.DataValueField = "AttributeId";

            ddlattribute.DataSource = q.ToList();
            ddlattribute.DataBind();
        }

        protected void lnksave_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] == null)
            {

                Specification_Setup ss = new Specification_Setup();


                ss.AttributeId = int.Parse(ddlattribute.SelectedValue);
                ss.SpecificationName = txtspecificationname.Text;
                ss.SpecificiatoinDescription = txtdesc.Text;

                db.Specification_Setup.Add(ss);
                db.SaveChanges();

            }

            else
            {
                int id = int.Parse(Request.QueryString["ID"].ToString());

                Specification_Setup ss = db.Specification_Setup.FirstOrDefault(u => u.SpecificationId == id);


                ss.AttributeId = int.Parse(ddlattribute.SelectedValue);
                ss.SpecificationName = txtspecificationname.Text;
                ss.SpecificiatoinDescription = txtdesc.Text;

           
                db.SaveChanges();

            }


            Response.Redirect("~/admin/specification_view");
        }
    }
}