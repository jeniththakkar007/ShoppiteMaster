using DataLayer.Models;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminPanel.Admin
{
    public partial class Commission_Report : System.Web.UI.Page
    {
        private Entities db = new Entities();
        private Product_Helper ph = new Product_Helper();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.LoadComplete += new EventHandler(Page_PreRender);
                //getdata();
            }
        }

        private void Page_PreRender(object sender, EventArgs e)
        {
            getdata();
        }

        protected void getdata()
        {
            String masterDropDown = (((this.Master) as MasterPage).FindControl("ddlorganization") as DropDownList).SelectedItem.Value;
            int selectedOrg = Convert.ToInt32(masterDropDown);

            var q = db.f_disbursement(selectedOrg).ToList();

            if (RadioButtonList1.SelectedValue == "Paid Disbursement")
            {
                q = q.Where(u => u.disbursementamount > 0).ToList();
            }
            else if (RadioButtonList1.SelectedValue == "Balance Disbursement")
            {
                q = q.Where(u => u.disbursementamount <= 0).ToList();
            }

            GridView1.DataSource = q.ToList();
            GridView1.DataBind();

            var qs = db.f_disbursement_summary(selectedOrg);

            GridView2.DataSource = qs.ToList();
            GridView2.DataBind();
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getdata();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Order_Disbursement ord = new Order_Disbursement();

            int id = int.Parse(GridView1.SelectedDataKey.Value.ToString());

            //Accessing BoundField Column.
            string amount = GridView1.SelectedRow.Cells[10].Text;

            decimal m = decimal.Parse(amount.ToString());

            ord.OrderId = id;
            ord.Amount = m;
            ord.DisburseDate = DateTime.Now;
            ord.DisbursementMode = "Paypal";
            ord.InsertBy = Page.User.Identity.Name;

            db.Order_Disbursement.Add(ord);
            db.SaveChanges();
            getdata();
        }
    }
}