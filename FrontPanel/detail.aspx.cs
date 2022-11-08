using DataLayer;
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
    public partial class detail : System.Web.UI.Page
    {


        Entities db = new Entities();
        Product_Helper ph = new Product_Helper();

      
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                if (this.Page.RouteData.Values["URL"] != null)
                {

                  
                    //get route value url
                    HiddenField1.Value = this.Page.RouteData.Values["URL"].ToString();

                    //get product id
                    int Productid = ph.Get_ProductId(HiddenField1.Value);


                    //pass product id to load variations
                    detail_variation.DV_HiddenField1 = Productid.ToString();


                   



                    //Product_Basic p = db.Product_Basic.FirstOrDefault(u => u.ProductId + "-" + u.URLPath == HiddenField1.Value);

                  
                    //get product guid
                    Guid ProductGUID = Guid.Parse(ph.Get_ProductGUID(HiddenField1.Value));

                    //bind product to controls
                    getproduct(HiddenField1.Value);


                   
                    


                  
                 //bind breadcrumb
                     bindbreadcrumb(ProductGUID);




                     ph.recentlyviewedcrud(Productid);




                     //bind star rating
                     ph.Get_StarRating(Productid);
                     Rating1.CurrentRating = ph.averagerating;



                     //check wishlist
                     getwishlist(Productid);



                     //random 4 new arrivals

                     thumbnail_slider3.getnewarrivals(4, "New Arrivals");


                     //search_allproducts.getnewarrival();



                     thumbnail_slider.getmegaoffers(10, "Mega Offers");




                     //similar products


                     thumbnail_slider1.getlastcatdata(int.Parse(HiddenField2.Value));




                     //recently viewed show
                     thumbnail_slider2.getrecentlyviewed("Recently Viewed");

                    

                }

            }

        }


        protected void bindbreadcrumb(Guid Id)
        {

            Product_Category pc = db.Product_Category.FirstOrDefault(u => u.ProductGUID == Id);


            var cat = db.getcat(pc.MainCat_Id);

            if (cat != null)
            {

                cat = cat.Where(u => u.ID == pc.Category_Id);
                HiddenField2.Value = pc.MainCat_Id.ToString();
            }


            foreach (var item in cat)
            {
                lblbreadcrumb.Text = item.catnames;

               
            }
        }

        protected void getwishlist(int Productid)
        {

            if (this.Page.User.Identity.Name == "")
            {

                LinkButton3.Visible = false;

            }

            else
            {





                if (Productid != 0)
                {
                    ph.getwishliststatus(int.Parse(Productid.ToString()), this.Page.User.Identity.Name);
                }

                if (ph.wishlisthstatus == "True")
                {

                    LinkButton3.CssClass = "btn btn-lg pink-c no-radius btn-default pink-bd";
                }
            }
        }

        protected void getproduct(string urlpath)
        {

            var q = db.f_getproducts_By_ProductId(urlpath);

            foreach (var item in q)
            {
                lblbrand.Text = item.brands;
                lblproduct.Text = item.ProductName;
                lbldescription.Text = item.Description;
                lblshortdes.Text = item.ShortDescription;



                decimal save = decimal.Parse(item.OldPrice.ToString()) - decimal.Parse(item.Price.ToString());
                save = save / decimal.Parse(item.OldPrice.ToString());
                save = save * 100;

                detail_variation.DV_lbloldprice = item.OldPrice.ToString();
                detail_variation.DV_lblsaleprice = item.Price.ToString();
                detail_variation.DV_lblsave = save.ToString("0.##") + "%";
                detail_variation.DV_lblcurrecny = item.CurrencyName;
                detail_variation.DV_lblcurrency2 = item.CurrencyName;
                detail_variation.DV_lblcurrentprice = item.Price.ToString();


                detail_vendor_uc.Vendor_lblshopname = item.shopname;
                detail_vendor_uc.Vendor_imglogo = item.logo;
                detail_vendor_uc.Vendor_lblshopnameurlpath = item.ProfileId + "-" + item.ShopURLPath;
             


                this.Page.Title = item.ProductName;


                if (Order_Helper.currency_code != "")
                {




                    //lblcurrency.Text = Order_Helper.currency_code;


                    decimal Old_coversionprice = decimal.Parse(item.OldPrice.ToString()) * decimal.Parse(Order_Helper.currency_value.ToString());

                    decimal sale_coversionprice = decimal.Parse(item.Price.ToString()) * decimal.Parse(Order_Helper.currency_value.ToString());



                    decimal save_coversionprice = decimal.Parse(save.ToString()) * decimal.Parse(Order_Helper.currency_value.ToString());


                    //string pricecoverted= coversionprice.ToString("#,##0.00");
                    //lblprice.Text = String.Format("#,##0.00", coversionprice);

                    detail_variation.DV_lbloldprice = Old_coversionprice.ToString("#,##0.00");
                    detail_variation.DV_lblsaleprice= sale_coversionprice.ToString("#,##0.00");


                    detail_variation.DV_lblcurrecny = Order_Helper.currency_code;
                    detail_variation.DV_lblcurrency2 = Order_Helper.currency_code;
                    detail_variation.DV_lblcurrentprice = sale_coversionprice.ToString("#,##0.00");


                    detail_variation.DV_lblsave = save_coversionprice.ToString("0.##") + "%";
                }
            }


             
          
	

            
         
            
       

         



        }


        protected void order_crud()
        {


            CustomFeesCalculation cfc = new CustomFeesCalculation();
            Order_Helper oh = new Order_Helper();
            //Product_Basic p = db.Product_Basic.FirstOrDefault(u => u.ProductId + "-" + u.URLPath == HiddenField1.Value);
            //get product guid
            Guid ProductGUID = Guid.Parse(ph.Get_ProductGUID(HiddenField1.Value));
            // get product id
            int ProductId = ph.Get_ProductId(HiddenField1.Value);

            //get product price
            Product_Price price = db.Product_Price.FirstOrDefault(u => u.ProductGUID == ProductGUID);


            decimal pricing = decimal.Parse(detail_variation.DV_lblsaleprice);





            





            Guid orderid = new Guid();

            if (Session["OrderID"] != null)
            {
                orderid = Guid.Parse(Session["OrderID"].ToString());

            }

            else
            {

                orderid = oh.MasterOrderID();
            }



            //tax per product fees

            //cfc.calculat_VAT(decimal.Parse(price.Price.ToString()), int.Parse(TextBox1.Text));

            Website_Setup_Helper website_Setup_Helper = new Website_Setup_Helper();
            var Url = HttpContext.Current.Request.Url;
            var subdomain = website_Setup_Helper.GetSubDomain(Url);
            var orgid = 0;
            if (subdomain.Contains("localhost"))
            {
                orgid = 1;
            }
            else
            {
                var orgObject = db.organizations.Where(x => x.org_name == subdomain).FirstOrDefault();

            }
            Order_Basic ob = new Order_Basic();




            ob.ProductId = int.Parse(ProductId.ToString());
            ob.OrderGUID = orderid;
            ob.QTY = int.Parse(TextBox1.Text);
            ob.Price = pricing;
            ob.Tax = oh.get_commission("Tax", pricing, int.Parse(TextBox1.Text));
            ob.VAT = oh.get_commission("Vat", pricing, int.Parse(TextBox1.Text));
            ob.DeliveryFees = price.DeliveryFees;
            ob.InsertDate = DateTime.Now;
            ob.OrderStatus = "Cart";
            ob.currencyid = Order_Helper.currencyid;
            ob.Commission = oh.get_commission("SalesCommission", pricing, int.Parse(TextBox1.Text));


            //decimal com=oh.get_commission("SalesCommission", decimal.Parse(price.Price.ToString()), int.Parse(TextBox1.Text));
            ob.Donation = oh.get_commission("Donation", pricing, int.Parse(TextBox1.Text));
            ob.OrgId = orgid;
            detail_variation.Getvariationcrud();
            ob.OrderVariation = detail_variation.DV_lblvariationdata;
            db.Order_Basic.Add(ob);
            db.SaveChanges();


            if(ob.OrderGUID!=null)
            {

                detail_variation.variationcrud(orderid);
            }


            if (ob != null)
            {

                Session["OrderID"] = orderid;
                
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            order_crud();
            Response.Redirect("~/cart");

          
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            order_crud();

            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup1();", true);
            //Response.Redirect("~/default");
        }



     


        protected void LinkButton3_Click(object sender, EventArgs e)
        {
           
              //Product_Basic p = db.Product_Basic.FirstOrDefault(u => u.ProductId + "-" + u.URLPath == HiddenField1.Value);

              int id= ph.Get_ProductId(HiddenField1.Value);

              if (id != 0)
              {
                  ph.Wishlist_Crud(int.Parse(id.ToString()), this.Page.User.Identity.Name);

                  Response.Redirect(Request.RawUrl);
              }
        }
    }
}