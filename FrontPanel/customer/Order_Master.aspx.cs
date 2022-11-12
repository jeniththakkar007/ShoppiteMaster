using DataLayer.Helper;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontPanel.Admin
{
    public partial class Order_Master : System.Web.UI.Page
    {

        Entities db = new Entities();

        Product_Helper phh = new Product_Helper();
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {
                //Page.LoadComplete += new EventHandler(Page_PreRender);
                getdata();
            }

        }
        //protected void Page_PreRender(object sender, EventArgs e)
        //{
        //    getdata();

        //}

        protected void getdata()
        {
            Profile_Helper ph = new Profile_Helper();

            int profileid = ph.profile_return_id(Page.User.Identity.Name);

            //Website_Setup_Helper website_Setup_Helper = new Website_Setup_Helper();
            //var Url = HttpContext.Current.Request.Url;
            //var subdomain = website_Setup_Helper.GetSubDomain(Url);
            //var orgid = 0;
            //if (subdomain == "localhost")
            //{
            //    orgid = 1;
            //}
            //else {
            //    var orgObject = db.organizations.Where(x => x.org_name == subdomain).FirstOrDefault();
            //    orgid = orgObject.id;
            //   //orgid = 1;
            //}
            var orgid = phh.GetOrgID();
            var q = db.SP_Order_Master(orgid).Where(u => u.BuyerId == profileid &&
                        u.orderdeliverystatus==RadioButtonList1.SelectedValue);

            if(txtsearch.Text!=string.Empty)
            {

                q = q.Where(u => u.orderid.ToLower().Contains(txtsearch.Text.ToLower()));
            }

            ListView1.DataSource = q.ToList();
            ListView1.DataBind();

        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getdata();

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            getdata();
        }
    }
}