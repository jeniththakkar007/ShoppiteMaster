using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq.Dynamic;
using DataLayer.Helper;

namespace FrontPanel.usercontrol
{
    public partial class search_allproducts : System.Web.UI.UserControl
    {



        Entities db = new Entities();
        Product_Helper ph = new Product_Helper();
        public string totalrecordfound = "0";
        public string totalavailrecords = "0";
        public int pricestart;
        public int priceend;
        public string brands = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
          if(!IsPostBack)
          {

              Global.pagenum = 0;
              Global.skiprows = 0;
          }
         
        }


        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string id = ((Label)e.Item.FindControl("lblid")).Text;

            if (e.CommandName == "lk")
            {


                ph.Wishlist_Crud_Like(int.Parse(id), Page.User.Identity.Name);

               if(Page.Title.Contains("Search"))
               {

                   getproduct();
               }
            }
        }


        protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {

                Label id = ((Label)e.Item.FindControl("lblid"));

                LinkButton lnk = ((LinkButton)e.Item.FindControl("lnkhomeproduct"));

                // Display the e-mail address in italics.
                ph.getwishliststatus_ByIP(int.Parse(id.Text));

                if (ph.wishlisthstatus == "True")
                {
                    lnk.CssClass = "p-like";

                }

            }
        }

        public void getbrandsproducts(string brands )
        {
            var q = db.f_getproducts().OrderByDescending(u=>u.ModifiedDate??u.InsertDate).Where(u => u.brandid + "-" + u.brandsurlpath == brands).ToList().Distinct();




            ListView1.DataSource = q.ToList();
            ListView1.DataBind();
        }

        public void getstoreproducts(string storename)
        {
            var q = db.f_getproducts().Where(u => u.ProfileId + "-" + u.ShopURLPath == storename).ToList().Distinct();




            ListView1.DataSource = q.ToList();
            ListView1.DataBind();
        }

        public void getnewarrival()
        {
            var q = db.f_getproducts().OrderByDescending(u => u.InsertDate).Where(u => u.deals.Contains("New-Arrival")).ToList().Take(4).OrderBy(u => Guid.NewGuid()).Distinct();

           


            ListView1.DataSource = q.ToList();
            ListView1.DataBind();
        }


        public void wishlist()
        {

            var q=(from us in db.Customer_Wishlist 
                       join p in db.f_getproducts() on us.ProductId equals p.ProductId
                       where us.UserName==this.Page.User.Identity.Name
                       select p);


            ListView1.DataSource = q.ToList().Distinct();
            ListView1.DataBind();
        }


        public void getproduct(int numberofrows = 24, int skiprows =0, int currentpage=1)
        {

            //var q = db.f_getproducts().ToList();

            //var q = db.f_getproducts_paging(numberofrows, skiprows).ToList();



            string maincategory = "";
            string subcategory = "";
            string deals = "";
            string key="";

            string Searchurl = "";

            string Action = "";
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
                orgid = orgObject.id;
               
            }
            db.SaveChanges();



            if (this.Page.RouteData.Values["Keyword"] != null)
            {
                Action = "Keyword";
                Searchurl = this.Page.RouteData.Values["Keyword"].ToString();

                totalavailrecords = db.SP_Product_Paging_AllRecord(Action, Searchurl, orgid).FirstOrDefault().ToString();

                //maincategory = this.Page.RouteData.Values["MainCategory"].ToString();
                //key = this.Page.RouteData.Values["Keyword"].ToString();
                //q = q.Where(u => u.URLPath.Contains(key) && u.maincatid + "-" + u.maincaturlpath == maincategory).ToList();

            }

            if (this.Page.RouteData.Values["Type"] != null && this.Page.RouteData.Values["Type"].ToString() == "MC")
            {


                Action = "MainCat";
                Searchurl = this.Page.RouteData.Values["MainCategory"].ToString();


                totalavailrecords = db.SP_Product_Paging_AllRecord(Action, Searchurl,orgid).FirstOrDefault().ToString();
              
                //maincategory = this.Page.RouteData.Values["MainCategory"].ToString();
                //q = q.Where(u => u.maincatid + "-" + u.maincaturlpath == maincategory).ToList();

            }


            if (this.Page.RouteData.Values["Type"] != null && this.Page.RouteData.Values["Type"].ToString() == "SC")
            {
                Action = "SubCat";
                Searchurl = this.Page.RouteData.Values["SubCategory"].ToString();
                totalavailrecords = db.SP_Product_Paging_AllRecord(Action, Searchurl, orgid).FirstOrDefault().ToString();

                //subcategory = this.Page.RouteData.Values["SubCategory"].ToString();
                //q = q.Where(u => u.Category_Id + "-" + u.categoryurlpath == subcategory).ToList();
            }

            if (this.Page.RouteData.Values["Type"] != null && this.Page.RouteData.Values["Type"].ToString() == "Deals")
            {
                Action = "Deals";
                Searchurl = this.Page.RouteData.Values["CatStatus"].ToString();
                totalavailrecords = db.SP_Product_Paging_AllRecord(Action, Searchurl, orgid).FirstOrDefault().ToString();

                //deals = this.Page.RouteData.Values["CatStatus"].ToString();




                //q = q.Where(u => u.deals != "" && u.deals.Contains(deals)).ToList();
            }





            var q = db.SP_Product_Paging(Action, numberofrows, skiprows, Searchurl, orgid).ToList();


            if (Session["SortList"] != null && Session["DirectionList"] != null)
            {
               q = q.AsQueryable().OrderBy(Session["SortList"].ToString() + " " + Session["DirectionList"]).ToList();
            }

            else
            {

                q = q.AsQueryable().OrderBy("ProductName" + " " + "DESC").ToList();
            }

            ///optional filter
            

           if(pricestart!=0 && priceend!=0)
           {

               q = q.Where(u => u.Price >= pricestart && u.Price <= priceend).ToList();

           }

            //if(brands !=string.Empty)
            //{

            //    q = q.Where(u => u.brands.Contains(brands)).ToList();
            //}




            totalrecordfound = q.Count.ToString();


            PopulatePager(int.Parse(totalavailrecords), currentpage, 24);

            ListView1.DataSource = q.ToList().Distinct();
            ListView1.DataBind();
        }

        //protected void LinkButton2_Click(object sender, EventArgs e)
        //{



        //    Global.pagenum = int.Parse(Global.pagenum.ToString()) + 1;
        //    Global.skiprows = int.Parse( Global.pagenum.ToString())* 24;




          
        //    getproduct(24, int.Parse(Global.skiprows.ToString()), 1);

        //    //if(Session["PageNum"]!=null)
        //    //{

        //    //    int pagenum = int.Parse(Session["PageNum"].ToString()) + 1;
        //    //    int skiprows = pagenum * 25;

        //    //    getproduct(25, skiprows);
        //    //}

        //    //else
        //    //{
        //    //    Session["PageNum"] = "0";
        //    //    int pagenum = int.Parse(Session["PageNum"].ToString());
        //    //    int skiprows = pagenum * 25;

        //    //    
        //    //}

           

        //}

        //protected void LinkButton1_Click(object sender, EventArgs e)
        //{
        //    Global.pagenum = int.Parse(Global.pagenum.ToString()) - 1;
        //    Global.skiprows = int.Parse(Global.pagenum.ToString()) * 24;



          

        //    getproduct(24, int.Parse(Global.skiprows.ToString()));

          
        //}

        private void PopulatePager(int recordCount, int currentPage, int PageSize)
        {

            double dblPageCount = (double)((decimal)recordCount / decimal.Parse(PageSize.ToString()));
            int pageCount = (int)Math.Ceiling(dblPageCount);
            List<ListItem> pages = new List<ListItem>();
            if (pageCount > 0)
            {
                pages.Add(new ListItem("First", "1", currentPage > 1));
                for (int i = 1; i <= pageCount; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                }
                pages.Add(new ListItem("Last", pageCount.ToString(), currentPage < pageCount));
            }
            rptPager.DataSource = pages;
            rptPager.DataBind();





            //double dblPageCount = (double)((decimal)recordCount / (decimal)PageSize);
            //int pageCount = (int)Math.Ceiling(dblPageCount);
            //List<ListItem> pages = new List<ListItem>();
            //if (pageCount > 0)
            //{
            //    pages.Add(new ListItem("First", "1", currentPage > 1));
            //    if (currentPage != 1)
            //    {
            //        pages.Add(new ListItem("Previous", (currentPage - 1).ToString()));
            //    }
            //    if (pageCount < 4)
            //    {
            //        for (int i = 1; i <= pageCount; i++)
            //        {
            //            pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
            //        }
            //    }
            //    else if (currentPage < 4)
            //    {
            //        for (int i = 1; i <= 4; i++)
            //        {
            //            pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
            //        }
            //        pages.Add(new ListItem("...", (currentPage).ToString(), false));
            //    }
            //    else if (currentPage > pageCount - 4)
            //    {
            //        pages.Add(new ListItem("...", (currentPage).ToString(), false));
            //        for (int i = currentPage - 1; i <= pageCount; i++)
            //        {
            //            pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
            //        }
            //    }
            //    else
            //    {
            //        pages.Add(new ListItem("...", (currentPage).ToString(), false));
            //        for (int i = currentPage - 2; i <= currentPage + 2; i++)
            //        {
            //            pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
            //        }
            //        pages.Add(new ListItem("...", (currentPage).ToString(), false));
            //    }
            //    if (currentPage != pageCount)
            //    {
            //        pages.Add(new ListItem("Next", (currentPage + 1).ToString()));
            //    }
            //    pages.Add(new ListItem("Last", pageCount.ToString(), currentPage < pageCount));
            //}
            //rptPager.DataSource = pages;
            //rptPager.DataBind();
        }

        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = Convert.ToInt32(((sender as LinkButton).CommandArgument));
            //getcustomers(pageIndex);
            Global.skiprows = (pageIndex-1) * 24;

            getproduct(24, int.Parse(Global.skiprows.ToString()), pageIndex);
        }

      
    }
}