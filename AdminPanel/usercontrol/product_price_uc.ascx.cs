
using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminPanel.usercontrol
{
    public partial class product_price_uc : System.Web.UI.UserControl
    {

        Entities db = new Entities();

   
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                getcurrency();
            }
        }

        protected void getcurrency()
        {

            var q=(from c in db.Currencies
                   where c.IsPublished==true
                       select c);

            ddlcurrency.DataTextField = "CurrencyName";
            ddlcurrency.DataValueField = "CurrencyID";

            ddlcurrency.DataSource = q.ToList();
            ddlcurrency.DataBind();



        }


        public string ProductPrice_ddlcurrency
        {
            get { return ddlcurrency.SelectedValue; }
            set { ddlcurrency.SelectedValue = value; }
        }

        public string ProductPrice_txtprice
        {
            get { return txtprice.Text; }
            set { txtprice.Text = value; }
        }

        public string ProductPrice_txtoldprice
        {
            get { return txtoldprice.Text; }
            set { txtoldprice.Text = value; }
        }


        public string ProductPrice_txtdeliveryfees
        {
            get { return txtdeliveryfees.Text; }
            set { txtdeliveryfees.Text = value; }
        }



        public bool ProductPrice_chckdisablebuybutton
        {
            get { return chckdisablebuybutton.Checked; }
            set { chckdisablebuybutton.Checked = value; }
        }

        public bool ProductPrice_chcktaxexempt
        {
            get { return chcktaxexempt.Checked; }
            set { chcktaxexempt.Checked = value; }
        }
    }
}