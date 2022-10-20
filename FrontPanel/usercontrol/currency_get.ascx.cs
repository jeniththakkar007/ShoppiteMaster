using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontPanel.usercontrol
{
    public partial class currency_get : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {




            if (!IsPostBack)
            {
                getcurrencyvalues();
                if (Order_Helper.currency_code != "")
                {

                    var item = ddlExchangeRates.Items.FindByText(Order_Helper.currency_code.ToString());
                    if (item != null)
                    {
                        item.Selected = true;
                    }

                    //else
                    //{
                    //    var items = ddlExchangeRates.Items.FindByText("EUR");
                    //    if (items != null)
                    //        items.Selected = true;

                    //}



                }
            }

        }

        protected void getcurrencyvalues()
        {

          


           

            string json = (new System.Net.WebClient()).DownloadString("https://openexchangerates.org/api/latest.json?app_id=c5624ad197e141ccb5d45c919aeed097&symbols=" + Order_Helper.getsetcurrencies);
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            KeyValuePair<string, object> rates = js.Deserialize<Dictionary<string, object>>(json)
                                                .Where(x => x.Key == "rates").FirstOrDefault();







            ddlExchangeRates.DataSource = rates.Value;
            ddlExchangeRates.DataTextField = "Key";
            ddlExchangeRates.DataValueField = "Value";
            ddlExchangeRates.DataBind();
            ddlExchangeRates.Items.Insert(0, new ListItem("Currency", "0"));


            //ddlExchangeRates.SelectedItem.Text = Order_Helper.currency_code;

        }

        protected void ddlExchangeRates_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Label1.Text = ddlExchangeRates.SelectedValue;

            Entities db = new Entities();

            Order_Helper.currency_code = ddlExchangeRates.SelectedItem.ToString();
            Order_Helper.currency_value = decimal.Parse(ddlExchangeRates.SelectedValue.ToString());


            Currency c = db.Currencies.FirstOrDefault(u => u.CurrencyName == Order_Helper.currency_code);

            if(c!=null)
            {
                Order_Helper.currencyid = int.Parse(c.CurrencyId.ToString());
            }

          

            Response.Redirect(Request.RawUrl);
        }
    }
}