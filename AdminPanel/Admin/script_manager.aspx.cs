using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminPanel.Admin
{
    public partial class script_manager : System.Web.UI.Page
    {

        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                getdata();
                if (Request.QueryString["ID"]!=null)
                {

                    int id = int.Parse(Request.QueryString["ID"].ToString());

                    Website_Setup_Script wss = db.Website_Setup_Script.FirstOrDefault(u => u.Scriptid == id);

                    if(wss!=null)
                    {
                        RadioButtonList1.SelectedValue = wss.Type;
                        txttitle.Text = wss.Title;
                        txtscript.Text = wss.Scriptname;
                    }
                }
            }
        }

        protected void getdata()
        {


            var q = (from wss in db.Website_Setup_Script
                     select wss);

            ListView1.DataSource = q.ToList();
            ListView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] == null)
            {
                Website_Setup_Script wss = new Website_Setup_Script();

                wss.Type = RadioButtonList1.SelectedValue;
                wss.Title = txttitle.Text;
                wss.Scriptname = txtscript.Text;
                db.Website_Setup_Script.Add(wss);
                db.SaveChanges();
            }

            else
            {
                int id = int.Parse(Request.QueryString["ID"].ToString());

                Website_Setup_Script wss = db.Website_Setup_Script.FirstOrDefault(u => u.Scriptid == id);

                if (wss != null)
                {
                   

                    wss.Type = RadioButtonList1.SelectedValue;
                    wss.Title = txttitle.Text;
                    wss.Scriptname = txtscript.Text;

                    db.SaveChanges();
                }
            }

            Response.Redirect("~/admin/script_manager");
        }


        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string lblid = ((Label)e.Item.FindControl("lblid")).Text;


            int id = int.Parse(lblid);

            if (e.CommandName == "ed")
            {
                

                Response.Redirect("~/admin/script_manager?ID=" + id);
            }



            if (e.CommandName == "del")
            {
               

                Website_Setup_Script wss = db.Website_Setup_Script.FirstOrDefault(u => u.Scriptid == id);

                db.Website_Setup_Script.Remove(wss);
                db.SaveChanges();

                getdata();
            }
        }
    }
}