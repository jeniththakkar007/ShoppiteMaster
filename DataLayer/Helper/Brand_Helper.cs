using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public class Brand_Helper
    {


        Entities db = new Entities();


        int brandid = 0;
        string brandname = "";


        public string getbrandname(int value)
        {

            if (value != null)
            {

                Brand b = db.Brands.FirstOrDefault(u => u.BrandId==value);

                if (b != null)
                {


                    brandname = b.BrandName;
                }
            }


            return brandname;
        }
        public int getbrandid(string value)
        {

            CreateURLPath_Helper c= new CreateURLPath_Helper();
            if(value!=null)
            {

                Brand b = db.Brands.FirstOrDefault(u => u.BrandName.ToLower() == value.ToLower());

                if(b!=null)
                {


                    brandid = int.Parse(b.BrandId.ToString());
                }

                else
                {


                    Brand bi = new Brand();


                    bi.Category_Id = 1;
                    bi.BrandName = value;
                    bi.BrandURLPath = c.createurlpath(value);
                    bi.BrandDescription = value;
                   
                    bi.IsPublished = true;
                    bi.InsertDate = DateTime.Now;
                    bi.UserName = HttpContext.Current.User.Identity.Name;


                    db.Brands.Add(bi);
                    db.SaveChanges();

                    brandid = int.Parse(bi.BrandId.ToString());
                }



            }


            return brandid;
        }
    
    
    }
