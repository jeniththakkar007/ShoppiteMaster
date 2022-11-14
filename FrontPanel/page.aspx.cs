using DataLayer.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace FrontPanel
{
    public partial class Page : System.Web.UI.Page
    {
        private Entities db = new Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (HttpContext.Current.Request.RequestContext.RouteData.Values["ID"] != null)
                {
                    int id = int.Parse(HttpContext.Current.Request.RequestContext.RouteData.Values["ID"].ToString());

                    getpage(id);
                }
            }
        }

        protected void getpage(int id)
        {
            var q = (from p in db.PageCategoryDetails
                     join pc in db.PageCategories on p.PageCategoryId equals pc.PageCategoryId
                     where p.PageCategoryId == id
                     select new
                     {
                         PageCategory = pc.PageCategory1,
                         PageDescription = p.PageCategoryDescriptoin
                     });

            ListView1.DataSource = q.ToList();
            ListView1.DataBind();
        }
    }
}