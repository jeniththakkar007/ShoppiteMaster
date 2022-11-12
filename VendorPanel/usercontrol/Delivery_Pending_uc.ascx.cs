﻿using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VendorPanel.usercontrol
{
    public partial class Delivery_Pending_uc : System.Web.UI.UserControl
    {
        Entities db = new Entities();
        Product_Helper ph = new Product_Helper(); 
        protected void Page_Load(object sender, EventArgs e)
        {



            getdisbursement();


        }


        protected void getdisbursement()
        {
            var orgid = ph.GetOrgID();
            var q = db.f_disbursement(orgid).Where(u => u.sellerusername == this.Page.User.Identity.Name && u.orderdeliverystatus=="Pending").Count();



            lbldisbursementamount.Text = q.ToString();

        }
    }
}