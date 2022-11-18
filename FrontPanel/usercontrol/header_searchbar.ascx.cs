using DataLayer.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace FrontPanel.usercontrol
{
    public partial class header_searchbar : System.Web.UI.UserControl
    {
        private Entities db = new Entities();
        private Product_Helper ph = new Product_Helper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getmaincat();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            var orgid = ph.GetOrgID();
            //Response.RedirectToRoute("Key", new { MainCategory = DropDownList1.SelectedValue,  Keyword = TextBox1.Text });

            if (DropDownList1.SelectedValue == "0" && TextBox1.Text == string.Empty)
            {
                lblerror.Text = "Please select search criteria";
                return;
            }

            if (DropDownList1.SelectedValue == "0" && TextBox1.Text != string.Empty)
            {
                Product_Basic p = db.Product_Basic.FirstOrDefault(u => u.URLPath == TextBox1.Text && u.OrgId == orgid);

                if (p != null)
                {
                    Product_Category pc = db.Product_Category.FirstOrDefault(u => u.ProductGUID == p.ProductGUID);

                    if (pc != null)
                    {
                        category_master cm = db.category_master.FirstOrDefault(u => u.category_id == pc.MainCat_Id);

                        if (cm != null)
                        {
                            string cat = cm.category_id + "-" + cm.URLPath;
                            Response.RedirectToRoute("Key", new { MainCategory = cat, Keyword = TextBox1.Text });
                        }
                    }
                }
                else
                {
                    lblerror.Text = "No matching result found.";
                    return;
                }
            }
            else if (DropDownList1.SelectedValue != "0")
            {
                Response.RedirectToRoute("CategoryMain", new { MainCategory = DropDownList1.SelectedValue, Type = "MC" });
            }
            else
            {
                lblerror.Text = "No matching result found.";
                return;
            }
        }

        protected void getmaincat()
        {
            var orgid = ph.GetOrgID();
            var q = (from c in db.category_master

                     where c.parent_category_id == 0 && c.IsPublished == true && c.OrgId == orgid
                     select new
                     {
                         Urlpath = c.category_id + "-" + c.URLPath,
                         categoryname = c.category_name
                     }

                       ).Distinct();

            DropDownList1.DataValueField = "URLPath";
            DropDownList1.DataTextField = "categoryname";

            DropDownList1.DataSource = q.ToList();
            DropDownList1.DataBind();
        }
    }
}