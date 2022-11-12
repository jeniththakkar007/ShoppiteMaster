using DataLayer.Helper;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontPanel
{
    public partial class searchvendor : System.Web.UI.Page
    {

        Entities db = new Entities();
        Product_Helper ph = new Product_Helper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                


                if(Request.QueryString["address"] !=null)
                {
                    txtarea.Text = Request.QueryString["address"].ToString();
                }

                if (Request.QueryString["radius"] != null)
                {
                   ddlradiussearch.SelectedValue = Request.QueryString["radius"].ToString();
                }


                if (Request.QueryString["lat"] != null)
                {
                    hdnlat.Value = Request.QueryString["lat"].ToString();
                }


                if (Request.QueryString["long"] != null)
                {
                    hdnlong.Value  = Request.QueryString["long"].ToString();
                }

                getdata();

            }
        }


        

        Latlong ll = new Latlong();
        protected void getdata()
        {

            var orgid = ph.GetOrgID();
            string productname = "%";
            string area = "%";
            string maincat = "%";
            string subcat = "%";

            if (txtkeyword.Text != string.Empty)
            {

                productname = txtkeyword.Text;

                
            }


            if (txtarea.Text != string.Empty)
            {
                area = txtarea.Text;
            }


            if (lstcat.SelectedValue != "")
            {
                maincat = lstcat.SelectedValue;
            }


            //if(txtkeyword.Text!=string.Empty || txtarea.Text!=string.Empty|| lstcat.SelectedValue!=string.Empty)
            //{
            //    lblsearch.Text = "Following vendor meet your search criteria";
            //}
            //else
            //{

            //    lblsearch.Text = string.Empty;
            //}

         

            if (Request.QueryString["lat"]==null && Request.QueryString["long"]==null)
            {
                var q = db.SP_Vendor_Search(productname, maincat, subcat, area,orgid).ToList();



                if (q.Count().ToString() != "0")
                {
                    lblsearch.Text = "Following vendor meet your search criteria";
                }

                else
                {
                    lblsearch.Text = "";
                }

                ListView1.DataSource = q.ToList();
                ListView1.DataBind();
            }

            else
            {


                var b = db.SP_Vendor_Search(productname, maincat, subcat, area,orgid);

                var Algo1Match = b.AsEnumerable().Select(a => new
            {

                shopurl = a.shopurl,
                logo = a.logo,
                ShopName = a.ShopName,
                totalproducts = a.totalproducts,
                address = a.address,
               




                //distance between pickup and actual drop mark by driver

              

                Distance = ll.distancebetweenreturn(double.Parse(hdnlat.Value), double.Parse(hdnlong.Value), double.Parse(a.latitude), double.Parse(a.longitude))



            });


            if (Request.QueryString["radius"] != null)
            {

                int distance = int.Parse(ddlradiussearch.SelectedValue);

                Algo1Match = Algo1Match.Where(u => u.Distance <= distance).ToList();

            }


            if(Algo1Match.Count().ToString()!="0")
            {
                lblsearch.Text = "Following vendor meet your search criteria";
            }

            else
            {
               lblsearch.Text = "";
            }


            ListView1.DataSource = Algo1Match.ToList();
            ListView1.DataBind();
            }
        }
    

       

        protected void Button1_Click(object sender, EventArgs e)
        {

            Latlong ll = new Latlong();
            ll.destinatoinlat(txtarea.Text);

            hdnlat.Value = ll.v_lat;
            hdnlong.Value = ll.v_lon;
            getdata();
        }

      
    }
}