using DataLayer.Helper;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminPanel.Admin
{
    public partial class status_add : System.Web.UI.Page
    {


        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                getdata();

                if (Request.QueryString["ID"] != null)
                {
                    int id = int.Parse(Request.QueryString["ID"].ToString());
                    Status s = db.Status.FirstOrDefault(u => u.StatusId == id);

                    txtstatus.Text = s.Status1;
                    chckhomepage.Checked = bool.Parse(s.ShowOnFront.ToString());
                    Image1.ImageUrl = s.CssClass;
                    
                }

            }

        }

        protected void getdata()
        {

            var q=(from s in db.Status
                   where s.ShowOnFront==true
                       orderby s.Status1
                       select s);

            ListView1.DataSource = q.ToList();
            ListView1.DataBind();
        }

        protected void lnksave_Click(object sender, EventArgs e)
        {
            AWS_Helper aw = new AWS_Helper();
            //CheckFile cf = new CheckFile();
            String masterDropDown = (((this.Master) as MasterPage).FindControl("ddlorganization") as DropDownList).SelectedItem.Value;
            int selectedOrg = Convert.ToInt32(masterDropDown);
            string fileconfigpath = WebConfigurationManager.AppSettings["filepath"];
            string filepath = fileconfigpath + selectedOrg + "\\Status";
            Image1.ImageUrl = aw.uploadfile(FileUpload1, filepath);
            if(Image1.ImageUrl=="")
            {

                lblerror.Text = "Status Image is required.";
                return;
            }

          

            if(Request.QueryString["ID"]==null)
            {

                Status s = new Status();

                s.Status1 = txtstatus.Text;
                s.URLPath = txtstatus.Text.Replace(" ", "-");
                s.InsertDate = DateTime.Now;
                s.ShowOnFront = chckhomepage.Checked;
                s.CssClass = Image1.ImageUrl;

                db.Status.Add(s);
                db.SaveChanges();
            }
            else
            {

                int id = int.Parse(Request.QueryString["ID"].ToString());
                Status s = db.Status.FirstOrDefault(u => u.StatusId == id);

                s.Status1 = txtstatus.Text;
                s.URLPath = txtstatus.Text.Replace(" ", "-");
                s.InsertDate = DateTime.Now;
                s.ShowOnFront = chckhomepage.Checked;
                s.CssClass = Image1.ImageUrl;

                db.SaveChanges();

            }

            Response.Redirect("~/admin/status_add");
        }

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string ID = ((Label)e.Item.FindControl("Label2")).Text;
            if (e.CommandName == "ed")
            {

                Response.Redirect("~/admin/status_add?ID=" + ID);
            }


            if (e.CommandName == "del")
            {
                int id = int.Parse(ID);

                Status sdel = db.Status.FirstOrDefault(u => u.StatusId == id);

                db.Status.Remove(sdel);
                db.SaveChanges();

                getdata();
              
            }
        }
    }
}