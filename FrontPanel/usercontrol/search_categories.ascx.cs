using DataLayer.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace FrontPanel.usercontrol
{
    public partial class search_categories : System.Web.UI.UserControl
    {
        private Entities db = new Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.RouteData.Values["MainCategory"] != null)
            {
                HiddenField1.Value = this.Page.RouteData.Values["MainCategory"].ToString();
                getcat(HiddenField1.Value);
                getdata();
            }
        }

        protected void getdata()
        {
            int id = int.Parse(catid.Text);
            var q = (from a in db.getcat(id)

                     orderby a.catnames
                     select new

                     {
                         path = a.urlpath,
                         id = a.ID,
                         Name = a.NAME
                     }

                );

            ListView1.DataSource = q.ToList();
            ListView1.DataBind();
        }

        protected void getcat(string value)
        {
            if (this.Page.RouteData.Values["Type"] != null)
            {
                category_master cm = db.category_master.FirstOrDefault(u => u.category_id + "-" + u.URLPath == value);

                lblmaincat.Text = cm.category_name;
                catid.Text = cm.category_id.ToString();
            }

            if (this.Page.RouteData.Values["Keyword"] != null)
            {
                category_master cm = db.category_master.FirstOrDefault(u => u.category_id + "-" + u.URLPath == value);

                lblmaincat.Text = cm.category_name;
                catid.Text = cm.category_id.ToString();
            }
        }
    }
}