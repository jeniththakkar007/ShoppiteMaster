using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminPanel.Admin
{
    public partial class advertisement_all : System.Web.UI.Page
    {


        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                getads();
            }
        }

        protected void getads()
        {

            var q = (from ad_detail in db.Ads_Detail
                     join ad_place in db.Ads_Placement on ad_detail.AdsPlacementId equals ad_place.AdsPlacementId
                     join ad_pagename in db.Ads_PageName on ad_detail.AdsPageId equals ad_pagename.AdsPageId
                     select new
                     {

                         AdId=ad_detail.AdId,
                         Image=ad_detail.Image,
                         StartDate=ad_detail.StartDate.ToString(),
                         EndDate=ad_detail.EndDate.ToString(),
                         Status=ad_detail.Status,
                         Placement=ad_place.PlacementName,
                         PageName= ad_pagename.PageName


                     }
                       );


            ListView1.DataSource = q.ToList();
            ListView1.DataBind();
        }

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string id = ((Label)e.Item.FindControl("Label1")).Text;
            if (e.CommandName == "ed")
            {
                Response.Redirect("~/admin/advertisment_add?ID="+ id);
               
            }


            if (e.CommandName == "del")
            {

                int did = int.Parse(id);

                Ads_Detail ad = db.Ads_Detail.FirstOrDefault(u => u.AdId == did);

                db.Ads_Detail.Remove(ad);
                db.SaveChanges();

                getads();

            }
        }
    }
}