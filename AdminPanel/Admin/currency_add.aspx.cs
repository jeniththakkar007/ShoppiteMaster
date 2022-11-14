using DataLayer.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace AdminPanel.Admin
{
    public partial class currency_add : System.Web.UI.Page
    {
        private Entities db = new Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getcurrency();
                if (Request.QueryString["ID"] != null)
                {
                    int Id = int.Parse(Request.QueryString["ID"].ToString());

                    Currency c = db.Currencies.FirstOrDefault(u => u.CurrencyId == Id);

                    txtcurrency.Text = c.CurrencyName;
                    chkpublish.Checked = bool.Parse(c.IsPublished.ToString());
                }
            }
        }

        protected void getcurrency()
        {
            var q = (from c in db.Currencies
                     select c);

            ListView1.DataSource = q.ToList();
            ListView1.DataBind();
        }

        protected void lnksave_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] == null)
            {
                Currency c = new Currency();
                c.CurrencyName = txtcurrency.Text;
                c.IsPublished = chkpublish.Checked;

                db.Currencies.Add(c);
                db.SaveChanges();
            }
            else
            {
                int Id = int.Parse(Request.QueryString["ID"].ToString());

                Currency c = db.Currencies.FirstOrDefault(u => u.CurrencyId == Id);
                c.CurrencyName = txtcurrency.Text;
                c.IsPublished = chkpublish.Checked;
                db.SaveChanges();
            }

            Response.Redirect("~/admin/Currency_add");
        }

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string ID = ((Label)e.Item.FindControl("Label2")).Text;
            if (e.CommandName == "ed")
            {
                Response.Redirect("~/admin/currency_add?ID=" + ID);
            }
        }
    }
}