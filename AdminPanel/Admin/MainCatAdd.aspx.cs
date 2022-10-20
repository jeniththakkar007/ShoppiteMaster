
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adminweb.Admin
{
    public partial class MainCatAdd : System.Web.UI.Page
    {
        Entities db = new Entities();

      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                getcat();
                if (Request.QueryString["ID"] != null)
                {

                    int id = int.Parse(Request.QueryString["ID"].ToString());
                    MainPageCategory c = db.MainPageCategories.FirstOrDefault(u => u.MainPageCategoryId == id);


                    txtcategory.Text = c.MainPageCategory1;
                 
                    RadioButtonList1.SelectedValue = c.Status;
                 
                }
            }
        }


      
        protected void getcat()
        {

            var q = (from c in db.MainPageCategories
                     select c);


            GridView1.DataSource = q.ToList();
            GridView1.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

       

                if (Request.QueryString["ID"] != null)
                {

                    int id = int.Parse(Request.QueryString["ID"].ToString());
                    MainPageCategory c = db.MainPageCategories.FirstOrDefault(u => u.MainPageCategoryId == id);

                    c.MainPageCategory1 = txtcategory.Text;
                  
                    c.Status = RadioButtonList1.SelectedValue;
                  

                    db.SaveChanges();

                }

                else
                {

                MainPageCategory c = new MainPageCategory();


                    c.MainPageCategory1 = txtcategory.Text;
               
                    c.Status = RadioButtonList1.SelectedValue;
                  

                    db.MainPageCategories.Add(c);

                    db.SaveChanges();

                }
                Response.Redirect("~/admin/maincatadd");
           

           



        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("~/admin/MainCatAdd?ID=" + GridView1.SelectedDataKey.Value);
        }
    }
}