using DataLayer.Helper;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VendorPanel.Admin
{
    public partial class profile : System.Web.UI.Page
    {


        Entities db = new Entities();

        Profile_Helper ph = new Profile_Helper();
        //CheckFile cs = new CheckFile();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                getcountry();

                ph.getprofile(this.Page.User.Identity.Name);
                
                imgbanner.ImageUrl = ph.logo;
                txtshopname.Text = ph.shopname;
                txtcontactnumber.Text = ph.contactnumber;
                ddlcountry.SelectedValue = ph.country;
                txtcity.Text = ph.city;
                txtzipcode.Text = ph.zip;
                txtstate.Text = ph.state;
                txtaddress.Text = ph.address;
                txtshortdesc.Text = ph.shopdescription;
                txtpaypalid.Text = ph.paypalid;
            
            }
        }


        


        protected void getcountry()
        {

            var q = (from c in db.Countries
                     orderby c.CountryName
                     select c);


            ddlcountry.DataTextField = "CountryName";
            ddlcountry.DataValueField = "CountryName";

            ddlcountry.DataSource = q.ToList();
            ddlcountry.DataBind();



        }

        protected void fileupload()
        {

            AWS_Helper aw = new AWS_Helper();
            if (fuicon.HasFile)
            {
                imgicon.ImageUrl = aw.uploadfile(fuicon);
            }

            if (fubanner.HasFile)
            {
                imgbanner.ImageUrl = aw.uploadfile(fubanner);
            }





        }


        protected void Button1_Click(object sender, EventArgs e)
        {

            fileupload();

            Users_Profile upudate = db.Users_Profile.FirstOrDefault(u => u.UserName == this.Page.User.Identity.Name);

            upudate.CoverImage = imgicon.ImageUrl;
            upudate.Logo = imgbanner.ImageUrl;
            upudate.ShopName = txtshopname.Text;
            upudate.ContactNumber = txtcontactnumber.Text;
            upudate.Country = ddlcountry.SelectedValue;
            upudate.City = txtcity.Text;
            upudate.Zip = txtzipcode.Text;
            upudate.State = txtstate.Text;
            upudate.Address = txtaddress.Text;
            upudate.ShopDescription = txtshortdesc.Text;
            upudate.PaypalId = txtpaypalid.Text;
            
          
              

            db.SaveChanges();

            dvsave.Visible = true;
        }





    }
}