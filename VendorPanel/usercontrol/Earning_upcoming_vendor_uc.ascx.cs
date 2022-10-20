﻿using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VendorPanel.usercontrol
{
    public partial class Earning_upcoming_vendor_uc : System.Web.UI.UserControl
    {
        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {

          

                getdisbursement();
            

        }


        protected void getdisbursement()
        {
            var q = db.f_disbursement().Where(u => u.sellerusername == this.Page.User.Identity.Name && u.disbursementamount==0).Sum(u=>u.balancedisbursment);



            lbldisbursementamount.Text = q.ToString();
       
        }
    }
}