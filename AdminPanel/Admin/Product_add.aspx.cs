using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminPanel.Admin
{
    public partial class Product_add : System.Web.UI.Page
    {


        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                if (Request.QueryString["ID"] != null)
                {


                    Guid id = Guid.Parse(Request.QueryString["ID"].ToString());

                    Product_Basic pb = db.Product_Basic.FirstOrDefault(u => u.ProductGUID == id);

                    if (pb != null)
                    {

                        product_info_uc.ProductBasic_txtproductname = pb.ProductName;
                        product_info_uc.ProductBasic_txtshortdescription = pb.ShortDescription;
                        product_info_uc.ProductBasic_txtdescription = pb.Description;
                        product_info_uc.ProductBasic_txtsku = pb.SKU;
                        product_info_uc.ProductBasic_chkpublish = bool.Parse(pb.IsPublished.ToString());
                        product_info_uc.ProductBasic_txtstartdate = pb.ProductStartDate.ToString();
                        product_info_uc.ProductBasic_txtenddate = pb.ProductEndDate.ToString();
                        
                        product_info_uc.ProductBasic_txtqty = pb.QTY.ToString();
                        Image_uploadasync_uc.IMG_imgbanner = pb.CoverImage;






                        Product_Price productprice = db.Product_Price.FirstOrDefault(u => u.ProductGUID == id);


                        product_price_uc.ProductPrice_txtprice = productprice.Price.ToString();
                        product_price_uc.ProductPrice_txtoldprice = productprice.OldPrice.ToString();
                        product_price_uc.ProductPrice_txtdeliveryfees = productprice.DeliveryFees.ToString();
                        product_price_uc.ProductPrice_chckdisablebuybutton = bool.Parse(productprice.DisableBuyButton.ToString());
                        product_price_uc.ProductPrice_chcktaxexempt = bool.Parse(productprice.TaxExempt.ToString());
                        product_price_uc.ProductPrice_ddlcurrency = productprice.CurrencyId.ToString();





                        Product_SEO ps = db.Product_SEO.FirstOrDefault(u => u.ProductGUID == id);

                        if (ps != null)
                        {
                            seo_uc.SEO_txtpagename = ps.SEO_PageName;
                            seo_uc.SEO_txtmetatitle = ps.SEO_MetaTItle;
                            seo_uc.SEO_txtkeywords = ps.SEO_Keywords;
                            seo_uc.SEO_txtmetadescription = ps.SEO_Metadescription;
                        }



                        var productags = (from pt in db.Product_Tags
                                          where pt.ProductGUID == id
                                          select pt).ToList();


                        foreach (var item in productags)
                        {
                            product_info_uc.ProductBasic_txttags += "," + item.ProductTags;
                        }

                    }

                }

                else
                {
                    Response.Redirect("~/admin/Product_add?ID=" + Guid.NewGuid());

                }
            }
        }




        protected void catinsert(Guid id)
        {

            product_info_uc.getcat();







            var q = (from pc in db.Product_Category
                     where pc.ProductGUID == id
                     select pc).ToList();

            foreach (var item in q)
            {



                db.Product_Category.Remove(item);
            }



            List<string> abclist = product_info_uc.ProductBasic_lblcatlist.Split(',').ToList();
            foreach (string s in abclist)
            {

                var maincat = db.f_topcat(int.Parse(s.ToString()));
                string maincatid = "0";


                foreach (var item in maincat)
                {
                    maincatid = item.category_id.ToString();
                }

                Product_Category productcategory = new Product_Category();

                productcategory.ProductGUID = id;
                productcategory.Category_Id = int.Parse(s);
                productcategory.MainCat_Id = int.Parse(maincatid);
                productcategory.InsertDate = DateTime.Now;
                productcategory.UserName = this.Page.User.Identity.Name;


                db.Product_Category.Add(productcategory);
                db.SaveChanges();
            }



        }


        protected void brandinsert(Guid id)
        {

            product_info_uc.getbrand();




            var q = (from pc in db.Product_Brands
                     where pc.ProductGUID == id
                     select pc).ToList();

            foreach (var item in q)
            {



                db.Product_Brands.Remove(item);
            }

            List<string> abclist = product_info_uc.ProductBasic_lblbranlist.Split(',').ToList();
            foreach (string s in abclist)
            {
                Product_Brands productbrands = new Product_Brands();

                productbrands.ProductGUID = id;
                productbrands.BrandId = int.Parse(s);
                productbrands.InsertDate = DateTime.Now;
                productbrands.UserName = this.Page.User.Identity.Name;

                db.Product_Brands.Add(productbrands);
                db.SaveChanges();
            }



        }



        protected void statusinsert(Guid id)
        {

            product_info_uc.getchklist();

            var q = (from pc in db.Product_Status
                     where pc.ProductGUID == id
                     select pc).ToList();

            foreach (var item in q)
            {



                db.Product_Status.Remove(item);
            }
            if (product_info_uc.ProductBasic_lblchklist != string.Empty)
            {
                List<string> abclist = product_info_uc.ProductBasic_lblchklist.Split(',').ToList();



                foreach (string s in abclist)
                {
                    Product_Status productstatus = new Product_Status();

                    productstatus.ProductGUID = id;
                    productstatus.StatusId = int.Parse(s);
                    productstatus.InsertDate = DateTime.Now;
                    productstatus.UserName = this.Page.User.Identity.Name;


                    db.Product_Status.Add(productstatus);
                    db.SaveChanges();
                }
            }

        }


        protected void tagsinsert(Guid id)
        {
            var q = (from pc in db.Product_Tags
                     where pc.ProductGUID == id
                     select pc).ToList();

            foreach (var item in q)
            {



                db.Product_Tags.Remove(item);
            }


            List<string> abclist = product_info_uc.ProductBasic_txttags.Split(',').ToList();
            foreach (string s in abclist)
            {

                Product_Tags producttags = new Product_Tags();

                producttags.ProductGUID = id;
                producttags.ProductTags = s;
                producttags.InsertDate = DateTime.Now;
                producttags.UserName = this.Page.User.Identity.Name;


                db.Product_Tags.Add(producttags);
                db.SaveChanges();
            }

        }



        protected void lnksave_Click(object sender, EventArgs e)
        {

            Image_uploadasync_uc.fileupload();
            imagemultiuploaduc.Upload();

            String masterDropDown = (((this.Master) as MasterPage).FindControl("ddlorganization") as DropDownList).SelectedItem.Value;
            int orgid = Convert.ToInt32(masterDropDown);
            if (Image_uploadasync_uc.IMG_imgbanner == "")
            {

                lblerror.Text = "Please upload Cover Image";

                return;
            }

            else
            {

                Profile_Helper ph = new Profile_Helper();
                CreateURLPath_Helper cph = new CreateURLPath_Helper();

                Guid id = Guid.Parse(Request.QueryString["ID"].ToString());

                Product_Basic pbcheck = db.Product_Basic.FirstOrDefault(u => u.ProductGUID == id);
                if (pbcheck == null)
                {

                    try
                    {
                        catinsert(id);
                        brandinsert(id);
                        statusinsert(id);
                        tagsinsert(id);

                        Product_Basic pb = new Product_Basic();

                        pb.ProductGUID = id;
                        pb.ProductName = product_info_uc.ProductBasic_txtproductname;
                        pb.URLPath = cph.createurlpath(product_info_uc.ProductBasic_txtproductname);
                        pb.ShortDescription = product_info_uc.ProductBasic_txtshortdescription;
                        pb.Description = product_info_uc.ProductBasic_txtdescription;
                        pb.SKU = product_info_uc.ProductBasic_txtsku;
                        pb.IsPublished = product_info_uc.ProductBasic_chkpublish;
                        pb.QTY = int.Parse(product_info_uc.ProductBasic_txtqty);

                        pb.ProductStartDate = DateTime.Parse(product_info_uc.ProductBasic_txtstartdate);
                        pb.ProductEndDate = DateTime.Parse(product_info_uc.ProductBasic_txtenddate);
                        pb.InsertDate = DateTime.Now;
                        pb.ProfileId = ph.profile_return_id(this.Page.User.Identity.Name);
                        pb.CoverImage = Image_uploadasync_uc.IMG_imgbanner;
                        pb.OrgId = orgid;

                        db.Product_Basic.Add(pb);
                        db.SaveChanges();















                        Product_Price productprice = new Product_Price();

                        productprice.ProductGUID = id;
                        productprice.Price = decimal.Parse(product_price_uc.ProductPrice_txtprice);
                        productprice.OldPrice = decimal.Parse(product_price_uc.ProductPrice_txtoldprice);
                        productprice.DeliveryFees = decimal.Parse(product_price_uc.ProductPrice_txtdeliveryfees);
                        productprice.DisableBuyButton = product_price_uc.ProductPrice_chckdisablebuybutton;
                        productprice.TaxExempt = product_price_uc.ProductPrice_chcktaxexempt;
                        productprice.CurrencyId = int.Parse(product_price_uc.ProductPrice_ddlcurrency);


                        db.Product_Price.Add(productprice);
                        db.SaveChanges();




                        Product_SEO ps = new Product_SEO();

                        ps.ProductGUID = id;
                        ps.SEO_PageName = seo_uc.SEO_txtpagename;
                        ps.SEO_MetaTItle = seo_uc.SEO_txtmetatitle;
                        ps.SEO_Keywords = seo_uc.SEO_txtkeywords;
                        ps.SEO_Metadescription = seo_uc.SEO_txtmetadescription;

                        db.Product_SEO.Add(ps);
                        db.SaveChanges();


                        Response.Redirect("~/admin/product_view");

                    }

                    catch (Exception ex)
                    {

                        lblerror.Text = ex.Message;
                    }

                }


                else
                {
                    try
                    {
                        catinsert(id);
                        brandinsert(id);
                        statusinsert(id);
                        tagsinsert(id);



                        pbcheck.ProductGUID = id;
                        pbcheck.ProductName = product_info_uc.ProductBasic_txtproductname;
                        pbcheck.URLPath = cph.createurlpath(product_info_uc.ProductBasic_txtproductname);
                        pbcheck.ShortDescription = product_info_uc.ProductBasic_txtshortdescription;
                        pbcheck.Description = product_info_uc.ProductBasic_txtdescription;
                        pbcheck.SKU = product_info_uc.ProductBasic_txtsku;
                        pbcheck.IsPublished = product_info_uc.ProductBasic_chkpublish;
                        pbcheck.QTY = int.Parse(product_info_uc.ProductBasic_txtqty);
                        pbcheck.CoverImage = Image_uploadasync_uc.IMG_imgbanner;
                        pbcheck.ProductStartDate = DateTime.Parse(product_info_uc.ProductBasic_txtstartdate);
                        pbcheck.ProductEndDate = DateTime.Parse(product_info_uc.ProductBasic_txtenddate);
                        pbcheck.OrgId = orgid;
                        pbcheck.ModifiedDate = DateTime.Now;
                        db.SaveChanges();


                        Product_Price productpricecheck = db.Product_Price.FirstOrDefault(u => u.ProductGUID == id);

                        productpricecheck.ProductGUID = id;
                        productpricecheck.Price = decimal.Parse(product_price_uc.ProductPrice_txtprice);
                        productpricecheck.OldPrice = decimal.Parse(product_price_uc.ProductPrice_txtoldprice);
                        productpricecheck.DeliveryFees = decimal.Parse(product_price_uc.ProductPrice_txtdeliveryfees);
                        productpricecheck.DisableBuyButton = product_price_uc.ProductPrice_chckdisablebuybutton;
                        productpricecheck.TaxExempt = product_price_uc.ProductPrice_chcktaxexempt;
                        productpricecheck.CurrencyId = int.Parse(product_price_uc.ProductPrice_ddlcurrency);


                        db.SaveChanges();




                        Product_SEO pscheck = db.Product_SEO.FirstOrDefault(u => u.ProductGUID == id);

                        if (pscheck != null)
                        {
                            pscheck.ProductGUID = id;
                            pscheck.SEO_PageName = seo_uc.SEO_txtpagename;
                            pscheck.SEO_MetaTItle = seo_uc.SEO_txtmetatitle;
                            pscheck.SEO_Keywords = seo_uc.SEO_txtkeywords;
                            pscheck.SEO_Metadescription = seo_uc.SEO_txtmetadescription;


                            db.SaveChanges();

                        }
                        Response.Redirect("~/admin/product_view");

                    }

                    catch (Exception ex)
                    {

                        lblerror.Text = ex.Message;
                    }

                }

            }

        }


    }

      
    }

            


          
        
    
