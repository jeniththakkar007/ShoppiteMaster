using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontPanel.usercontrol
{
    public partial class detail_variation : System.Web.UI.UserControl
    {

        Entities db = new Entities();
       
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }




        public string DV_lblcurrentprice
        {
            get { return lblcurrentprice.Text; }
            set { lblcurrentprice.Text = value; }
        }

        public string DV_lblsaleprice
        {
            get { return lblsaleprice.Text; }
            set { lblsaleprice.Text = value; }
        }
        public string DV_lblcurrency2
        {
            get { return lblcurrency2.Text; }
            set { lblcurrency2.Text = value; }
        }

        public string DV_lbloldprice
        {
            get { return lbloldprice.Text; }
            set { lbloldprice.Text = value; }
        }

        public string DV_lblcurrecny
        {
            get { return lblcurrecny.Text; }
            set { lblcurrecny.Text = value; }
        }

        public string DV_lblsave
        {
            get { return lblsave.Text; }
            set { lblsave.Text = value; }
        }

        public string DV_HiddenField1
        {
            get { return HiddenField1.Value; }
            set { HiddenField1.Value = value; }
        }


        public string DV_lblvariationdata
        {
            get { return lblvariationdata.Text; }
            set { lblvariationdata.Text = value; }
        }



        public void Getvariationcrud()
        {
            if (ListView1.Items.Count > 0)
            {

                foreach (ListViewItem item in ListView1.Items)
                {

                    Label lblatrributename = (Label)item.FindControl("Label2");
                    RadioButtonList rdbspecid = (RadioButtonList)item.FindControl("RadioButtonList1");




                    lblvariationdata.Text += lblatrributename.Text + ": " + rdbspecid.SelectedItem + " || ";

                }



            }

        }





      
        public void price_addon()
        {
            if (ListView1.Items.Count > 0)
            {

              
                decimal totalprice = 0;
                totalprice = decimal.Parse(lblcurrentprice.Text);
                foreach (ListViewItem item in ListView1.Items)
                {

                   

                    Label lblatributeid = (Label)item.FindControl("Label3");
                    RadioButtonList rdbspecid = (RadioButtonList)item.FindControl("RadioButtonList1");

                    Label lblinsideprice = (Label)item.FindControl("lblinsideprice");
                    decimal attributeprice= decimal.Parse(lblinsideprice.Text);

                    if (rdbspecid.SelectedValue != string.Empty)
                    {

                        int id = int.Parse(rdbspecid.SelectedValue);

                        Product_Specification ps = db.Product_Specification.FirstOrDefault(u => u.ProductSpecificationId == id);

                        if (ps != null)
                        {
                            if (ps.Price != null)
                            {
                                attributeprice = decimal.Parse(ps.Price.ToString());
                                lblinsideprice.Text = ps.Price.ToString();
                            }
                        }

                      
                    }


                    totalprice += attributeprice;
                    

                }

                lblsaleprice.Text = totalprice.ToString();



            }

        }



        public void variationcrud(Guid orderid)
        {
            if(ListView1.Items.Count> 0)
            {

                 foreach (ListViewItem item in ListView1.Items)
                 {

                     Label lblatrributename = (Label)item.FindControl("Label2");
                     RadioButtonList rdbspecid = (RadioButtonList)item.FindControl("RadioButtonList1");


                     Order_Variation ov = new Order_Variation();

                     ov.OrderGUID = orderid;
                     ov.ProductSpecificationId = int.Parse(rdbspecid.SelectedValue);

                     db.Order_Variation.Add(ov);
                     db.SaveChanges();


                     lblvariationdata.Text += lblatrributename.Text + ": " + rdbspecid.SelectedItem + " ";

                 }



            }

        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            price_addon();
        }
    }
}