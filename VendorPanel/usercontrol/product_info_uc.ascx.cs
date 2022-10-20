
using DataLayer.Models;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VendorPanel.usercontrol
{
    public partial class product_info_uc : System.Web.UI.UserControl
    {


        CommaSeperation cs = new CommaSeperation();
        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                txtstartdate.Attributes.Add("readonly", "true");
                txtenddate.Attributes.Add("readonly", "true");


                txtstartdate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
                txtenddate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
                //getbranddata();
                getstatus();
                getcatbind();
                ListBox1.DataBind();

                    Guid id = Guid.Parse(Request.QueryString["ID"].ToString());


                    ////multiple cateogry re populate
                    var q = (from pc in db.Product_Category
                             where pc.ProductGUID == id
                             select pc).ToList();


                    if (q != null)
                    {

                        foreach (var productcategory in q)
                        {

                            foreach (ListItem item in ListBox1.Items)
                            {
                                string catid = productcategory.Category_Id.ToString();
                                if (item.Value == catid)
                                {

                                    item.Selected = true;
                                }


                            }
                        }


                    }



                     //if (productbrands != null)
                     //{
                        


                     //    foreach (ListItem item in ListBox2.Items)
                     //    { 
                             
                     //        string brandid = productbrands.BrandId.ToString();


                     //        if (item.Value == brandid)
                     //        {

                     //            item.Selected = true;
                     //        }


                     //    }
                     //}


                     var productstatus = (from ps in db.Product_Status
                                          where ps.ProductGUID == id
                                          select ps);

                     if (productstatus != null)
                     {


                         foreach (var item in productstatus)
                         {

                             foreach (ListItem citem in chkstatus.Items)
                             {

                                 string statusid = item.StatusId.ToString();
                                 if (citem.Value == statusid)
                                 {

                                     citem.Selected = true;
                                 }
                             }

                         }


                     }



            }
        }

        protected void getcatbind()
        {

            var q = db.sp_getcat().Where(u => u.PARENT_NAMEID != 0);



         


                ListBox1.DataTextField="catnames";
            ListBox1.DataValueField="ID";
            ListBox1.DataSource = q.ToList();
            ListBox1.DataBind();
        }

        public string ProductBasic_txtqty
        {
            get { return txtqty.Text; }
            set { txtqty.Text = value; }
        }
     

        public string ProductBasic_txtproductname
        {
            get { return txtproductname.Text; }
            set { txtproductname.Text = value; }
        }


        public string ProductBasic_txtshortdescription
        {
            get { return txtshortdescription.Text; }
            set { txtshortdescription.Text = value; }
        }


        public string ProductBasic_txtdescription
        {
            get { return txtdescription.Text; }
            set { txtdescription.Text = value; }
        }



        public string ProductBasic_txtsku
        {
            get { return txtsku.Text; }
            set { txtsku.Text = value; }
        }



        public string ProductBasic_txtcategories
        {
            get { return ListBox1.SelectedValue; }
            set { ListBox1.SelectedValue= value; }
        }


   


        public string ProductBasic_txttags
        {
            get { return txttags.Text; }
            set { txttags.Text = value; }
        }



        public string ProductBasic_txtstartdate
        {
            get { return txtstartdate.Text; }
            set { txtstartdate.Text = value; }
        }



        public string ProductBasic_txtenddate
        {
            get { return txtenddate.Text; }
            set { txtenddate.Text = value; }
        }


        public string ProductBasic_txtbrand
        {
            get { return txtbrands.Text; }
            set { txtbrands.Text = value; }
        }



        public bool ProductBasic_chkpublish
        {
            get { return chkpublish.Checked; }
            set { chkpublish.Checked = value; }
        }



        public string ProductBasic_lblchklist
        {
            get { return lblchklist.Text; }
            set { lblchklist.Text = value; }
        }

        public string ProductBasic_lblcatlist
        {
            get { return lblcatlist.Text; }
            set { lblcatlist.Text = value; }
        }


        public string ProductBasic_lblbranlist
        {
            get { return lblbrandlist.Text; }
            set { lblbrandlist.Text = value; }
        }
        

        public void getchklist()
        {

          lblchklist.Text=  cs.chcklistreturn(chkstatus);
        }


        public void getcat()
        {

           lblcatlist.Text= cs.listboxreturn(ListBox1);
            
        }

        //public void getbrand()
        //{

        //    lblbrandlist.Text = cs.listboxreturn(ListBox2);

        //}


       //protected void getbranddata()
       // {

       //     var q=(from b in db.Brands
       //                orderby b.BrandName
       //                select b);


       //     ListBox2.DataTextField = "BrandName";
       //     ListBox2.DataValueField = "BrandID";

       //     ListBox2.DataSource = q.ToList();
       //     ListBox2.DataBind();
       // }



        protected void getstatus()
       {

            var q =(from s in db.Status
                        orderby s.Status1
                        select s);

            chkstatus.DataTextField = "Status1";
            chkstatus.DataValueField = "Statusid";

            chkstatus.DataSource = q.ToList();
            chkstatus.DataBind();
       }
    }
}