using DataLayer.Helper;
using DataLayer.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace FrontPanel
{
    public class Global : HttpApplication
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

        private void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterRoutes(System.Web.Routing.RouteTable.Routes);

            
        }

        private void Application_Error(object sender, EventArgs e)
        {
            //try
            //{
            //    string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            //    string sqlStatment = "INSERT INTO ErrorLog VALUES(@Date,@Message)";
            //    using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(constr))
            //    {
            //        using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sqlStatment, con))
            //        {
            //            Exception ex = Server.GetLastError().GetBaseException();
            //            if (!(ex is HttpException))
            //            {
            //                string exceptionMessage = ex.Message;
            //                string StackTrace = ex.StackTrace.Replace(Environment.NewLine, string.Empty);
            //                string source = ex.Source.Replace(Environment.NewLine, string.Empty);
            //                string targetSite = ex.TargetSite.ToString().Replace(Environment.NewLine, string.Empty);
            //                string userName = HttpContext.Current.User.Identity.Name;
            //                string url = (HttpContext.Current.Request == null || HttpContext.Current.Request.Url == null) ? "" : HttpContext.Current.Request.Url.AbsoluteUri;
            //                con.Open();
            //                cmd.Parameters.AddWithValue("@Date", DateTime.Now);
            //                cmd.Parameters.AddWithValue("@Message", userName.ToString() + "" + exceptionMessage.ToString() + "" + StackTrace.ToString() + "" + source.ToString() + "" + targetSite.ToString() + "" + url + "" + ((System.Exception)(Server.GetLastError().InnerException)).Message.Trim());
            //                cmd.ExecuteNonQuery();
            //                con.Close();
            //            }
            //        }
            //    }
            //}

            //catch
            //{
            //Response.Redirect("~/Oops.aspx");
            //}
        }

        private void RegisterRoutes(System.Web.Routing.RouteCollection routes)
        {
            routes.MapPageRoute("CategoryMain", "{MainCategory}/{Type}/Category", "~/Search.aspx");
            routes.MapPageRoute("CategorySub", "{MainCategory}/{SubCategory}/{Type}/Category", "~/Search.aspx");

            routes.MapPageRoute("CatStatus", "{CatStatus}/{Type}/Status", "~/deals.aspx");

            routes.MapPageRoute("Key", "{MainCategory}/{Keyword}/Keyword", "~/Search.aspx");

            routes.MapPageRoute("Detail", "{URL}/show", "~/detail.aspx");

            routes.MapPageRoute("Store", "{Shopname}/StoreProducts", "~/store.aspx");
            routes.MapPageRoute("Brand", "{BrandName}/BrandProducts", "~/brands.aspx");

            routes.MapPageRoute("page", "{ID}/{pagetitle}/page", "~/page.aspx");
        }
    }
}