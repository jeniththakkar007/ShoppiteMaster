using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontPanel.usercontrol
{
    public partial class currencies_uc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getcurrencyvalues();

                getcurrencycode();

                getcountry();





                
                


            }
        }


        protected void getcountry()
        {

            string ipAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ipAddress))
            {
                ipAddress = Request.ServerVariables["REMOTE_ADDR"];

                //ipAddress = "180.92.150.180";
            }


            try
            {
                string jsons = (new System.Net.WebClient()).DownloadString("https://api.ipgeolocation.io/ipgeo?apiKey=0168838d1e0c43769834c924d06e3366&ip=" + ipAddress);
                System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
                KeyValuePair<string, object> ratess = jss.Deserialize<Dictionary<string, object>>(jsons)
                                                    .Where(x => x.Key == "country_name").FirstOrDefault();



                 KeyValuePair<string, object> ratesss = jss.Deserialize<Dictionary<string, object>>(jsons)
                                                    .Where(x => x.Key == "country_flag").FirstOrDefault();
                //KeyValuePair<string, object> keyValue = (ratess.Value as Dictionary<string, object>)
                //                                        .Where(x => x.Key == "country_name").FirstOrDefault();
                if (ratess.Value != null)
                {
                    //lblValue.Text = keyValue.Value.ToString();

                    //ddlExchangeRates.SelectedItem="";

                    lblcountry.Text = ratess.Value.ToString();
                    Image1.ImageUrl = ratesss.Value.ToString();


                }

               
            }
            catch (Exception)
            {

            }
        }

        protected void getcurrencycode()
        {
            if (Session["SelectionType"] == null)
            {
                string ipAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ipAddress))
                {
                    ipAddress = Request.ServerVariables["REMOTE_ADDR"];
                }


                try
                {
                    string jsons = (new System.Net.WebClient()).DownloadString("https://api.ipgeolocation.io/ipgeo?apiKey=0168838d1e0c43769834c924d06e3366&fields=currency&ip=" + ipAddress);
                    System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
                    KeyValuePair<string, object> ratess = jss.Deserialize<Dictionary<string, object>>(jsons)
                                                        .Where(x => x.Key == "currency").FirstOrDefault();
                    KeyValuePair<string, object> keyValue = (ratess.Value as Dictionary<string, object>)
                                                            .Where(x => x.Key == "code").FirstOrDefault();
                    if (keyValue.Value != null)
                    {
                        //lblValue.Text = keyValue.Value.ToString();

                        //ddlExchangeRates.SelectedItem="";


                        var item = ddlExchangeRates.Items.FindByText(keyValue.Value.ToString());
                        if (item != null)
                        {
                            item.Selected = true;
                        }

                        else
                        {
                            var items = ddlExchangeRates.Items.FindByText("EUR");
                            if (items != null)
                                items.Selected = true;

                        }


                      
                    }

                    else
                    {

                        var item = ddlExchangeRates.Items.FindByText("EUR");
                        if (item != null)
                            item.Selected = true;


                    }
                }
                catch (Exception)
                {

                    var item = ddlExchangeRates.Items.FindByText("EUR");
                    if (item != null)
                        item.Selected = true;
                }

                Session["CurrencyCode"] = ddlExchangeRates.SelectedItem.ToString();
                Session["CurrencyValue"] = ddlExchangeRates.SelectedValue;
            }

            else
            {

             
                var item = ddlExchangeRates.Items.FindByText(Session["CurrencyCode"].ToString());
                if (item != null)
                    item.Selected = true;

                

            }


        }


        protected void getcurrencyvalues()
        {


            string json = (new System.Net.WebClient()).DownloadString("https://api.exchangeratesapi.io/latest");
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            KeyValuePair<string, object> rates = js.Deserialize<Dictionary<string, object>>(json)
                                                .Where(x => x.Key == "rates").FirstOrDefault();
            ddlExchangeRates.DataSource = rates.Value;
            ddlExchangeRates.DataTextField = "Key";
            ddlExchangeRates.DataValueField = "Value";
            ddlExchangeRates.DataBind();
            ddlExchangeRates.Items.Insert(0, new ListItem("Select", "0"));

        }

        protected void ddlExchangeRates_SelectedIndexChanged(object sender, EventArgs e)
        {
            


                Session["CurrencyCode"] = ddlExchangeRates.SelectedItem.ToString();
                Session["CurrencyValue"] = ddlExchangeRates.SelectedValue;



           

            Session["SelectionType"] = "Manual";

            Response.Redirect(Request.RawUrl);
        }
    }
}