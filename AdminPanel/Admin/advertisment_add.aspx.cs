using DataLayer;
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
    public partial class advertisment_add : System.Web.UI.Page
    {



        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                getposition();


                if(Request.QueryString["ID"]!=null)
                {

                    getrecord();
                }
            }


            FileUpload1.Attributes["onchange"] = "UploadFile(this)";
        }

        protected void Upload(object sender, EventArgs e)
        {
            int height=0;
            int width=0;


            //if(ddlposition.SelectedValue=="1")
            //{
            //    height = 80;
            //    width = 1900;

            //}

            //if (ddlposition.SelectedValue == "2")
            //{
            //    height = 200;
            //    width = 1200;

            //}

            //if (ddlposition.SelectedValue == "3")
            //{
            //    height = 600;
            //    width = 250;

            //}

            //if (ddlposition.SelectedValue == "4")
            //{
            //    height = 200;
            //    width = 1200;

            //}

            //if (ddlposition.SelectedValue == "5")
            //{
            //    height = 400;
            //    width = 950;

            //}


            int id = int.Parse(ddlposition.SelectedValue);
            Ads_Placement ap = db.Ads_Placement.FirstOrDefault(u => u.AdsPlacementId == id);

            if(ap!=null)
            {

                height = int.Parse(ap.Height.ToString());
                width = int.Parse(ap.Width.ToString());
            }



            //CheckFile image = new CheckFile();

            AWS_Helper aw = new AWS_Helper();


            string message = aw.checkfilesize(FileUpload1, height, width);

          if (message == "Success")
          {
                String masterDropDown = (((this.Master) as MasterPage).FindControl("ddlorganization") as DropDownList).SelectedItem.Value;
                int selectedOrg = Convert.ToInt32(masterDropDown);
                string fileconfigpath = WebConfigurationManager.AppSettings["filepath"];
                string bannerfilepath = fileconfigpath + selectedOrg + "\\Ads";
                Image1.ImageUrl = aw.uploadfile(FileUpload1, bannerfilepath);
              lblerror.Text = string.Empty;
          }

          else
          {

         
              lblerror.Text = message;
          }

        }

        protected void getposition()
        {

             var q=(from p in db.Ads_Placement
                        where p.Status=="Active"
                    select new
                    {


                        Description= p.PlacementName + "-" + p.Description,
                        AdsPlacementId= p.AdsPlacementId
                    }
                        );


             ddlposition.DataTextField = "Description";
             ddlposition.DataValueField = "AdsPlacementId";

             ddlposition.DataSource = q.ToList();
             ddlposition.DataBind();
        }


        protected void getrecord()
        {

            int id = int.Parse(Request.QueryString["ID"].ToString());

            Ads_Detail ad = db.Ads_Detail.FirstOrDefault(u => u.AdId == id);



            ddlposition.SelectedValue = ad.AdsPlacementId.ToString();
            Image1.ImageUrl = ad.Image;
            txtdescription.Text = ad.Description;
            txtstartdate.Text = ad.StartDate.ToString();
            txtenddate.Text = ad.EndDate.ToString();
            RadioButtonList1.SelectedValue = ad.Status;
            getpagename(int.Parse(ddlposition.SelectedValue));
            Label1.Text = ddlposition.SelectedItem.ToString();


            foreach (ListItem cBox in chckpage.Items)
                if (cBox.Value== ad.AdsPageId.ToString())
                {
                    cBox.Selected = true;

                }
        }


        protected void getpagename(int id)
        {


            var q=(from pn in db.Ads_PageName
                       where pn.Status=="Active" && pn.AdsPlacementId==id
                       select pn);



            chckpage.DataTextField = "PageName";
            chckpage.DataValueField = "AdsPageId";

            chckpage.DataSource = q.ToList();
            chckpage.DataBind();
        }

        protected void ddlposition_SelectedIndexChanged(object sender, EventArgs e)
        {
            getpagename(int.Parse(ddlposition.SelectedValue));
            Label1.Text = ddlposition.SelectedItem.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(lblerror.Text==string.Empty)
            {

                foreach(ListItem cBox in chckpage.Items) 
                    if(cBox.Selected) 
                    {
                        crud(int.Parse(cBox.Value));

                    }
            }
        }


        protected void crud(int pageid)
        {
            

            if(Request.QueryString["ID"]==null)
            {
                Ads_Detail ad = new Ads_Detail();

                ad.AdsPageId = pageid;
                ad.AdsPlacementId = int.Parse(ddlposition.SelectedValue);
                ad.Image = Image1.ImageUrl;
                ad.Description = txtdescription.Text;
                ad.StartDate = DateTime.Parse(txtstartdate.Text);
                ad.EndDate = DateTime.Parse(txtenddate.Text);
                ad.Status = RadioButtonList1.SelectedValue;
                ad.InsertDate = DateTime.Now;
                ad.UserName = this.Page.User.Identity.Name;


                db.Ads_Detail.Add(ad);
                db.SaveChanges();

            }

            else
            {


                int id = int.Parse(Request.QueryString["ID"].ToString());

                Ads_Detail ad = db.Ads_Detail.FirstOrDefault(u => u.AdId == id);


                ad.AdsPageId = pageid;
                ad.AdsPlacementId = int.Parse(ddlposition.SelectedValue);
                ad.Image = Image1.ImageUrl;
                ad.Description = txtdescription.Text;
                ad.StartDate = DateTime.Parse(txtstartdate.Text);
                ad.EndDate = DateTime.Parse(txtenddate.Text);
                ad.Status = RadioButtonList1.SelectedValue;
                ad.ModifiedDate = DateTime.Now;
                ad.UserName = this.Page.User.Identity.Name;


                db.SaveChanges();



            }

            Response.Redirect("~/admin/advertisement_all");
        }
    }
}