using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontPanel.Donation
{
    public partial class FundsDetails : System.Web.UI.Page
    {

        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {


                    Guid id = Guid.Parse(Request.QueryString["ID"].ToString());

                    HiddenField1.Value = id.ToString();
                    var q = db.f_Donation_BYID().Where(u=>u.RequestFundGUID==id);

                    foreach (var item in q)
                    {

                        imgdonatoin.ImageUrl = item.Image;
                        lbltitle.Text = item.Title;
                        lbldescription.Text = item.Description;
                        lblamount.Text =  item.Amount.ToString();
                        lblpaypalid.Text = item.paypalid;
                        lblcurrency.Text = "USD";

                        lblamountreceived.Text =  item.totalreceived.ToString() + "USD " ;
                        lblcampaignstartdate.Text = DateTime.Parse(item.InsertDate.ToString()).ToString("MMM dd, yyyy");


                        decimal bal = decimal.Parse(item.Amount.ToString()) - decimal.Parse(item.totalreceived.ToString());

                        lblbalance.Text =  bal.ToString() + "USD " ;

                        if(lblbalance.Text=="0")
                        {
                            Button1.Visible = false;
                            Button1.Text = "Campaign Closed";

                        }


                        if(lblpaypalid.Text=="")
                        {

                            Button1.Visible = false;
                            Button1.Text = "Campaign Closed";
                        }
                       
                    }


                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            PaymentGateway_Helper pgh = new PaymentGateway_Helper();

                  string host = "http://" + HttpContext.Current.Request.Url.Host;
                string successurl = host + "/donation/donationconfirmation?ID=" +  HiddenField1.Value;
                string cancelurl = host + "/donation/cancel?OrderID=" + HiddenField1.Value;
                string ipn = host + "/donation/ipndonation.aspx";

                pgh.Paypal_send(lblpaypalid.Text, true, this.Page.User.Identity.Name, decimal.Parse(lblamount.Text), HiddenField1.Value,  "USD", successurl, cancelurl, ipn);
        }
    }
}