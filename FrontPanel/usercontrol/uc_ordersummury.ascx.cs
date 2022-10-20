using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontPanel.usercontrol
{
    public partial class uc_ordersummury : System.Web.UI.UserControl
    {


        Entities db = new Entities();
       
        Order_Helper oh = new Order_Helper();
        protected void Page_Load(object sender, EventArgs e)
        {
           

          
                if (Session["OrderID"] != null)
                {
                    HiddenField1.Value = Session["OrderID"].ToString();


                  lblcartcount.Text=  oh.cartcount(Guid.Parse(HiddenField1.Value));



                  gettotalamount(Guid.Parse(HiddenField1.Value));

               

                }
            
        }


        public string OS_HiddenField1
        {
            get { return HiddenField1.Value; }
            set { HiddenField1.Value = value; }
        }
      

        public string OS_lbltotal
        {
            get { return  lbltotal.Text ; }
            set {  lbltotal.Text  = value; }
        }

        public string OS_lblcurrency
        {
            get { return lblcurrency.Text; }
            set { lblcurrency.Text = value; }
        }


        public void gettotalamount(Guid Id)
        {


            var q = db.f_order_master_summary(Id).ToList();


         



            foreach (var item in q)
            {

                lblitemtotal.Text = item.ExcludeVatPrice.ToString();
                lblvatfees.Text = item.vat.ToString();
                lblcurrency.Text = item.CurrencyName;
                lbltax.Text = item.tax.ToString();
                lblshippingfees.Text = item.deliveryfees.ToString();
                lblvartcurrency.Text = item.CurrencyName;
                lbldelcurrency.Text = item.CurrencyName;
                lblshippingcurrency.Text =  item.CurrencyName;

                lbltotal.Text = item.totalPrice.ToString();
            }

            //CustomFeesCalculation cfc = new CustomFeesCalculation();
            //cfc.calculatefees(decimal.Parse(lblitemtotal.Text), int.Parse(lblcartcount.Text));
            //lbldeliveryfees.Text = cfc.deliveryfees.ToString() ;


            //commented on 13 mar bcs total is ocming query
            //decimal sum = decimal.Parse(lblitemtotal.Text) + decimal.Parse(lbltax.Text) + decimal.Parse(lblvatfees.Text) + decimal.Parse(lblshippingfees.Text);
          




            //////update delivery fees and total fees



            //oh.order_details_crud(Id, decimal.Parse(lbldeliveryfees.Text), decimal.Parse(sum.ToString()));

        }
    }
}