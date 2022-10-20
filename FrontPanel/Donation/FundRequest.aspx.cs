using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontPanel.Donation
{
    public partial class FundRequest : System.Web.UI.Page
    {


        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Request.QueryString["ID"]!=null)
                {


                    Guid id = Guid.Parse(Request.QueryString["ID"].ToString());


                    Donation_Master dm = db.Donation_Master.FirstOrDefault(u => u.RequestFundGUID == id);


                    ImageUploadJquery_uc.Image_imgurl = dm.Image;
                    txttitle.Text = dm.Title;
                    txtdescription.Text = dm.Description;
                    txtrequiredfunds.Text = dm.Amount.ToString();
                    CheckBox1.Checked = bool.Parse(dm.IsActive.ToString());
                    txtpaypalid.Text = dm.PaypalID;
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

          
            ImageUploadJquery_uc.fileupload();


            if (Request.QueryString["ID"] == null)
            {

                Donation_Master dm = new Donation_Master();

              

                dm.Image = ImageUploadJquery_uc.Image_imgurl;
                dm.Title = txttitle.Text;
                dm.Description = txtdescription.Text;
                dm.Amount = decimal.Parse(txtrequiredfunds.Text);
                dm.IsActive = CheckBox1.Checked;
                dm.UserName = this.Page.User.Identity.Name;
                dm.InsertDate = DateTime.Now;
                dm.PaypalID = txtpaypalid.Text;
                db.Donation_Master.Add(dm);

                db.SaveChanges();

            }

            else
            {
                Guid id = Guid.Parse(Request.QueryString["ID"].ToString());


                Donation_Master dm = db.Donation_Master.FirstOrDefault(u => u.RequestFundGUID == id);

               

                dm.Image = ImageUploadJquery_uc.Image_imgurl;
                dm.Title = txttitle.Text;
                dm.Description = txtdescription.Text;
                dm.Amount = decimal.Parse(txtrequiredfunds.Text);
                dm.IsActive = CheckBox1.Checked;
                dm.UserName = this.Page.User.Identity.Name;
                dm.PaypalID = txtpaypalid.Text;

                db.SaveChanges();

            }

            Response.Redirect("~/donation/MyFunds");

        }
    }
}