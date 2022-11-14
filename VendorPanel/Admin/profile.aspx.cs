using DataLayer.Helper;
using DataLayer.Models;
using System;
using System.Linq;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace VendorPanel.Admin
{
    public partial class profile : System.Web.UI.Page
    {
        private Entities db = new Entities();

        private Profile_Helper ph = new Profile_Helper();
        private Product_Helper pdh = new Product_Helper();

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

            string fileconfigpath = WebConfigurationManager.AppSettings["filepath"];
            var orgvalue = pdh.GetOrgID();
            string filepath = fileconfigpath + orgvalue + "/Profile";
            if (fuicon.HasFile)
            {
                string categoryfilepath = filepath + "/fuicon";
                categoryfilepath = categoryfilepath + "/" + fuicon.FileName;
                imgicon.ImageUrl = aw.uploadfile(fuicon, categoryfilepath);
            }

            if (fubanner.HasFile)
            {
                string bannerfilepath = filepath + "/fubanner";

                bannerfilepath = bannerfilepath + "/" + fubanner.FileName;
                imgbanner.ImageUrl = aw.uploadfile(fubanner, bannerfilepath);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            fileupload();
            var orgid = pdh.GetOrgID();
            Users_Profile upudate = db.Users_Profile.FirstOrDefault(u => u.UserName == this.Page.User.Identity.Name && u.OrgId == orgid);

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
            upudate.OrgId = orgid;

            db.SaveChanges();

            dvsave.Visible = true;
        }
    }
}