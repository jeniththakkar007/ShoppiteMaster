using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontPanel.test
{
    public partial class currencycoversion : System.Web.UI.Page
    {
        protected void Convert(object sender, EventArgs e)
        {
            double amount = 0d;
            if (double.TryParse(txtAmount.Text.Trim(), out amount))
            {
                string url = string.Format("http://rate-exchange.appspot.com/currency?from={0}&to={1}", ddlFrom.SelectedItem.Value, ddlTo.SelectedItem.Value);
                WebClient client = new WebClient();
                string rates = client.DownloadString(url);
                Rate rate = new JavaScriptSerializer().Deserialize<Rate>(rates);
                double converted_amount = amount * rate.rate;
                string message = ddlFrom.SelectedItem.Value + ": " + amount + "\\n";
                message += ddlTo.SelectedItem.Value + ": " + converted_amount + "\\n";
                message += "Rate: 1 " + ddlFrom.SelectedItem.Value + " = " + rate.rate + " " + ddlTo.SelectedItem.Value;
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Invalid amount value.');", true);
            }
        }


        public class Rate
        {
            public string to { get; set; }
            public string from { get; set; }
            public double rate { get; set; }
        }
    }
}