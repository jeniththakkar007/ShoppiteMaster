using DataLayer.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace FrontPanel.usercontrol
{
    public partial class ad_left_uc : System.Web.UI.UserControl
    {
        private Entities db = new Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getdata();
            }
        }

        protected void getdata()
        {
            string page = this.Page.Title.ToString();

            var q = (from ad_detail in db.Ads_Detail
                     join ad_place in db.Ads_Placement on ad_detail.AdsPlacementId equals ad_place.AdsPlacementId
                     join ad_pagename in db.Ads_PageName on ad_detail.AdsPageId equals ad_pagename.AdsPageId
                     where ad_pagename.PageName.Contains("Home") && ad_place.PlacementName == "Left"
                     select new
                     {
                         AdId = ad_detail.AdId,
                         Image = ad_detail.Image,
                         StartDate = ad_detail.StartDate.ToString(),
                         EndDate = ad_detail.EndDate.ToString(),
                         Status = ad_detail.Status,
                         Placement = ad_place.PlacementName,
                         PageName = ad_pagename.PageName
                     }
                      );

            ListView1.DataSource = q.ToList();
            ListView1.DataBind();
        }
    }
}