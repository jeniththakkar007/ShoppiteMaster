using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontPanel.test
{
    public partial class currency_latesttest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                getcurrencyvalues();
            }
        }


        protected void getcurrencyvalues()
        {

            string getsetcurrencies = "";

            Entities db = new Entities();



            var q = (from c in db.Currencies
                     where c.IsPublished==true
                     select c);

            foreach (var item in q)
            {
                getsetcurrencies += item.CurrencyName+",";
            }

            string json = (new System.Net.WebClient()).DownloadString("https://openexchangerates.org/api/latest.json?app_id=c5624ad197e141ccb5d45c919aeed097&symbols="+ getsetcurrencies);
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            KeyValuePair<string, object> rates = js.Deserialize<Dictionary<string, object>>(json)
                                                .Where(x => x.Key == "rates" ).FirstOrDefault();



           



            ddlExchangeRates.DataSource = rates.Value;
            ddlExchangeRates.DataTextField = "Key";
            ddlExchangeRates.DataValueField = "Value";
            ddlExchangeRates.DataBind();
            ddlExchangeRates.Items.Insert(0, new ListItem("Select", "0"));

        }

        protected void ddlExchangeRates_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Text = ddlExchangeRates.SelectedValue;
        }
    }
}