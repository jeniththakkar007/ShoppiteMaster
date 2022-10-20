using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adminweb.Admin
{
    public partial class PageCat : System.Web.UI.Page
    {

        Entities db = new Entities();

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                getpagename();
                getmaincate();


                if (Request.QueryString["ID"] != null)
                {
                    int id = int.Parse(Request.QueryString["ID"].ToString());
                    PageCategory pg = db.PageCategories.FirstOrDefault(u => u.PageCategoryId == id);


                    txtpage.Text = pg.PageCategory1;
                    RadioButtonList1.SelectedValue = pg.Status;
                    ddlmaincat.SelectedValue = pg.MainPageCategoryId.ToString();
                    RadioButtonList2.SelectedValue = pg.Type;
                    CheckBox1.Checked = bool.Parse(pg.IsURL.ToString());
                    txtsortnumber.Text = pg.Sortnumber.ToString();
                  
                    //urlcheck();


                    if (CheckBox1.Checked == true)
                    {
                        txturl.Text = pg.URL;
                        txturl.Visible = true;
                    }

                    else
                    {

                        txturl.Visible = false;
                        txturl.Text = string.Empty;
                    }
                }



            }
        }


        protected void getmaincate()
        {

            var q = (from mc in db.MainPageCategories
                     select mc).ToList();



            ddlmaincat.DataTextField = "MainPageCategory1";
            ddlmaincat.DataValueField = "MainPageCategoryId";

            ddlmaincat.DataSource = q.ToList();
            ddlmaincat.DataBind();



        }


        protected void getpagename()
        {

            var q=(from pn in db.PageCategories
                       select pn);


            ListView1.DataSource = q.ToList();
            ListView1.DataBind();
        }


        //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/admin/PageCat?ID="+ GridView1.SelectedDataKey.Value);
        //}

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string ID = ((Label)e.Item.FindControl("Label1")).Text;
            if (e.CommandName == "ed")
            {

                Response.Redirect("~/admin/PageCat?ID=" + ID);
            }




            if (e.CommandName == "del")
            {

                int did = int.Parse(ID);

                PageCategory pc = db.PageCategories.FirstOrDefault(u => u.PageCategoryId == did);

                db.PageCategories.Remove(pc);
                db.SaveChanges();

                Response.Redirect(Request.RawUrl);

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (Request.QueryString["ID"] != null)
            {
                int id = int.Parse(Request.QueryString["ID"].ToString());
                PageCategory pg = db.PageCategories.FirstOrDefault(u => u.PageCategoryId == id);



                pg.PageCategory1 = txtpage.Text;
                pg.Status = RadioButtonList1.SelectedValue;
                pg.InsertDate = DateTime.Now;
                pg.MainPageCategoryId = int.Parse(ddlmaincat.SelectedValue.ToString());
                pg.Type = RadioButtonList2.SelectedValue;
                pg.IsURL = CheckBox1.Checked;
                pg.URL = txturl.Text;
                pg.Sortnumber = int.Parse(txtsortnumber.Text);

                db.SaveChanges();
            }

            else
            {

                PageCategory pg = new PageCategory();

                pg.PageCategory1 = txtpage.Text;
                pg.Status = RadioButtonList1.SelectedValue;
                pg.InsertDate = DateTime.Now;
                pg.MainPageCategoryId = int.Parse(ddlmaincat.SelectedValue.ToString());
                pg.Type = RadioButtonList2.SelectedValue;
                pg.IsURL = CheckBox1.Checked;
                pg.URL = txturl.Text;
                pg.Sortnumber = int.Parse(txtsortnumber.Text);

                db.PageCategories.Add(pg);
                db.SaveChanges();

            }

            Response.Redirect("~/admin/pagecat");
        }

        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(RadioButtonList2.SelectedValue=="Footer")
            {

                forfooter.Visible = true;
            }
            else
            {

                forfooter.Visible = false;
            }
        }


        protected void urlcheck()
        {
            if (CheckBox1.Checked == true)
            {
                txturl.Text = string.Empty;
                txturl.Visible = true;
            }

            else
            {

                txturl.Visible = false;
                txturl.Text = "NA";
            }

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            urlcheck();
        }
    }
}