
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public class Product_Helper
    {


        Entities db = new Entities();




        public void recentlyviewedcrud(int id)
        {

            UserRegisterHelper ur = new UserRegisterHelper();
            Product_Recently_Viewed prv = db.Product_Recently_Viewed.FirstOrDefault(u => u.ProductId == id);

            if (prv == null)
            {
                Product_Recently_Viewed pr = new Product_Recently_Viewed();

                pr.ProductId = id;
                pr.IP = ur.getuserip();
                pr.Insertdate = DateTime.Now;

                db.Product_Recently_Viewed.Add(pr);
                db.SaveChanges();

            }










        }


        public string wishlisthstatus= "";
        public void Wishlist_Crud(int productid, string username)
        {


            string ip = "";



            string ipAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ipAddress))
            {
                ipAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            ip = ipAddress;



            Customer_Wishlist cw = db.Customer_Wishlist.FirstOrDefault(u => u.ProductId == productid && u.UserName == username);

            if(cw!=null)
            {
                db.Customer_Wishlist.Remove(cw);
                db.SaveChanges();
                wishlisthstatus = "True";
            }

            else
            {



                Customer_Wishlist cwinsert =  new Customer_Wishlist();


                cwinsert.ProductId = productid;
                cwinsert.UserName = username;
                cwinsert.InsertDate = DateTime.Now;
                cwinsert.IP = ip;

                db.Customer_Wishlist.Add(cwinsert);
                db.SaveChanges();

            }


        }



        public void Wishlist_Crud_Like(int productid, string username)
        {


            string ip = "";



            string ipAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ipAddress))
            {
                ipAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            ip = ipAddress;



            Customer_Wishlist cw = db.Customer_Wishlist.FirstOrDefault(u => u.ProductId == productid && u.IP == ip);

            if (cw != null)
            {
                db.Customer_Wishlist.Remove(cw);
                db.SaveChanges();
                wishlisthstatus = "True";
            }

            else
            {



                Customer_Wishlist cwinsert = new Customer_Wishlist();


                cwinsert.ProductId = productid;
                cwinsert.UserName = username;
                cwinsert.InsertDate = DateTime.Now;
                cwinsert.IP = ip;

                db.Customer_Wishlist.Add(cwinsert);
                db.SaveChanges();

            }


        }





        public void getwishliststatus(int productid, string username)
        {



            Customer_Wishlist cw = db.Customer_Wishlist.FirstOrDefault(u => u.ProductId == productid && u.UserName == username);

            if (cw != null)
            {
              
                wishlisthstatus = "True";
            }

        }


        public void getwishliststatus_ByIP(int productid)
        {
            wishlisthstatus = "";
            string ip = "";


            
            string ipAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ipAddress))
            {
                ipAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            ip = ipAddress;

            
            Customer_Wishlist cw = db.Customer_Wishlist.FirstOrDefault(u => u.ProductId == productid && u.IP==ip);

            if (cw != null)
            {

                wishlisthstatus = "True";
            }

        }




        public int Get_ProductId(string Urlpath)
        {
            int id=0 ;
            Product_Basic p = db.Product_Basic.FirstOrDefault(u => u.ProductId + "-" + u.URLPath == Urlpath);

            if (p != null)
            {

                id= p.ProductId;
            }

            return id;
        }


        public string Get_ProductGUID(string Urlpath)
        {
            string guid="";
            Product_Basic p = db.Product_Basic.FirstOrDefault(u => u.ProductId + "-" + u.URLPath == Urlpath);

            if (p != null)
            {

                guid = p.ProductGUID.ToString();
            }

            return guid;
        }



        public int averagerating = 0;
        public int totalrating = 0;
        public void Get_StarRating(int productid)
        {


            var q = db.f_startrating_productwise(productid);


            foreach (var item in q)
            {
                averagerating = item.AverageRating;
                totalrating = int.Parse(item.RatingCount.ToString());
            }
        }
    }
