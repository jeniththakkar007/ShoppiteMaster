using DataLayer.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace AdminPanel.Admin
{
    public partial class VendorPackages : System.Web.UI.Page
    {
        private Entities db = new Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getcurrency();
                if (Request.QueryString["ID"] != null)
                {
                    int id = int.Parse(Request.QueryString["ID"].ToString());

                    Vendor_Membership_Package vmpupdate = db.Vendor_Membership_Package.FirstOrDefault(u => u.Membershipid == id);

                    txttitle.Text = vmpupdate.Title;
                    txtdescription.Text = vmpupdate.Description;
                    RadioButtonList2.SelectedValue = vmpupdate.Membershiptype;
                    txtrecurringperiod.Text = vmpupdate.RecurringPeriod.ToString();
                    txtfees.Text = vmpupdate.Fees.ToString();
                    CheckBox1.Checked = bool.Parse(vmpupdate.IsActive.ToString());
                    txtdescription.Text = vmpupdate.Description;
                    ddlcurrency.SelectedValue = vmpupdate.CurrencyId.ToString();
                    txtunit.Text = vmpupdate.Unit;

                    db.SaveChanges();
                }
            }
        }

        protected void getcurrency()
        {
            var q = (from c in db.Currencies
                     where c.IsPublished == true
                     select c);

            ddlcurrency.DataTextField = "CurrencyName";
            ddlcurrency.DataValueField = "CurrencyID";

            ddlcurrency.DataSource = q.ToList();
            ddlcurrency.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] == null)
            {
                Vendor_Membership_Package vmp = new Vendor_Membership_Package();

                vmp.Title = txttitle.Text;
                vmp.Description = txtdescription.Text;
                vmp.Membershiptype = RadioButtonList2.SelectedValue;
                vmp.RecurringPeriod = int.Parse(txtrecurringperiod.Text);
                vmp.Fees = decimal.Parse(txtfees.Text);
                vmp.InsertDate = DateTime.Now;
                vmp.IsActive = CheckBox1.Checked;
                vmp.CurrencyId = int.Parse(ddlcurrency.SelectedValue);
                vmp.Unit = txtunit.Text;

                db.Vendor_Membership_Package.Add(vmp);
                db.SaveChanges();
            }
            else
            {
                int id = int.Parse(Request.QueryString["ID"].ToString());

                Vendor_Membership_Package vmpupdate = db.Vendor_Membership_Package.FirstOrDefault(u => u.Membershipid == id);

                vmpupdate.Title = txttitle.Text;
                vmpupdate.Description = txtdescription.Text;
                vmpupdate.Membershiptype = RadioButtonList2.SelectedValue;
                vmpupdate.RecurringPeriod = int.Parse(txtrecurringperiod.Text);
                vmpupdate.Fees = decimal.Parse(txtfees.Text);
                vmpupdate.InsertDate = DateTime.Now;
                vmpupdate.IsActive = CheckBox1.Checked;
                vmpupdate.CurrencyId = int.Parse(ddlcurrency.SelectedValue);
                vmpupdate.Unit = txtunit.Text;

                db.SaveChanges();
            }

            Response.Redirect("~/admin/vendorpackage_view");
        }

        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList2.SelectedValue == "Recurring")
            {
                recurringperiod.Visible = true;
            }
            else if (RadioButtonList2.SelectedValue == "Free")
            {
                recurringperiod.Visible = true;
            }
            else
            {
                recurringperiod.Visible = false;
                recurringperiod.InnerText = "365";
            }
        }
    }
}