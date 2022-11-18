using DataLayer.Helper;
using DataLayer.Models;
using System;
using System.Linq;

namespace AdminPanel
{
    public partial class Login : System.Web.UI.MasterPage
    {
        public static object MyCompanyName { get; private set; }
        public static object MyLogo { get; private set; }

        public static object Myfavicon { get; private set; }
        public static object IsDonation { get; private set; }
        public static object IsVendorChat { get; set; }
        public static object IsEmailOnChat { get; set; }

        public static object Title { get; set; }
        public static object keywords { get; set; }
        public static object description { get; set; }

        public static object pagenum { get; set; }
        public static object skiprows { get; set; }

        private Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            Website_Setup_Helper ws = new Website_Setup_Helper();

            ws.getwebsiteinfo();

            MyCompanyName = ws.companyname;
            MyLogo = ws.logo;

            ///check if donation enable
            ///

            IsDonation = ws.Setup_Enable("Donation");

            //Vendor Chat Enable or not
            IsVendorChat = ws.Setup_Enable("IsVendorChat");

            //Email Chat Enable or not
            IsEmailOnChat = ws.Setup_Enable("ChatEmail");

            ///pagenumber settings
            ///

            //My Favicon

            Myfavicon = ws.favicon != null ? ws.favicon.ToString() : null;

            ///meta tag
            ///
            Title = ws.title;
            keywords = ws.keyword;
            description = ws.description;


            Currency cur = db.Currencies.FirstOrDefault(u => u.ISBase == true);

            if (cur != null)
            {
                Order_Helper.currencyid = cur.CurrencyId;
                Order_Helper.currency_code = cur.CurrencyName;
            }

            //get all active currencies
            var q = (from c in db.Currencies
                     where c.IsPublished == true
                     select c);

            foreach (var item in q)
            {
                Order_Helper.getsetcurrencies += item.CurrencyName + ",";
            }
        }
    }
}