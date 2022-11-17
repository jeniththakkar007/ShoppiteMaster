using DataLayer.Helper;
using DataLayer.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace FrontPanel.usercontrol
{
    public partial class header_productstatus : System.Web.UI.UserControl
    {
        private Entities db = new Entities();
        Product_Helper ph = new Product_Helper();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getproductstatus();
            }
        }

        protected void getproductstatus()
        {
            //Website_Setup_Helper website_Setup_Helper = new Website_Setup_Helper();
            //var Url = HttpContext.Current.Request.Url;
            //var subdomain = website_Setup_Helper.GetSubDomain(Url);
            //var orgid = 0;
            //if (subdomain.Contains("localhost"))
            //{
            //    orgid = 1;
            //}
            //else
            //{
            //    var orgObject = db.organizations.Where(x => x.org_name == subdomain).FirstOrDefault();
            //    orgid = orgObject.id;
            //}
            var orgid = ph.GetOrgID();
            var q = db.SP_Status_HasProducts(orgid);

            //var q=(from stat in db.Status
            //           join productstatus in db.Product_Status on stat.StatusId equals productstatus.StatusId
            //           orderby stat.Status1 ascending
            //           where stat.ShowOnFront==true
            //           select stat).Distinct().ToList();

            ListView1.DataSource = q.ToList();
            ListView1.DataBind();
        }
    }
}