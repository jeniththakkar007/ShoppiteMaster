using DataLayer.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace VendorPanel
{
    public class Global : HttpApplication
    {

        public static object IsVendorChat { get; set; }
        public static object IsEmailOnChat { get; set; }
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            Website_Setup_Helper ws = new Website_Setup_Helper();

            //Vendor Chat Enable or not
            IsVendorChat = ws.Setup_Enable("IsVendorChat");


            //Email Chat Enable or not
            IsEmailOnChat = ws.Setup_Enable("ChatEmail");

        }


        void Application_Error(object sender, EventArgs e)
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
    }
}