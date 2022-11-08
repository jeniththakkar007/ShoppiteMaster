
using DataLayer.Helper;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

    public class Order_Helper
    {


        Entities db = new Entities();


        public static int currencyid;
         public static string getsetcurrencies;


    public static string currency_code;
    public static decimal currency_value =1;

    public Guid MasterOrderID()
        {

        

        Guid orderid = new Guid();
            Order_Master om= new Order_Master();


            om.OrderKeyStatus="Active";
            om.InsertDate =DateTime.Now;
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
            om.OrgId = orgid;
            db.Order_Master.Add(om);
            db.SaveChanges();

            if(om!=null)
            {

               orderid= om.OrderGUID;
            }

        
  
        return orderid;
        }


        public void Order_Update(Guid id, string orderstatus, string username, string paymentmode, string referenceid)
        {
        
        var q = (from ob in db.Order_Basic
                     where ob.OrderGUID == id
                     select ob).ToList();


            foreach (var item in q)
            {

                int oid = int.Parse(item.OrderId.ToString());
                Order_Basic obupdate = db.Order_Basic.FirstOrDefault(u => u.OrderId == oid);

                obupdate.OrderStatus = orderstatus;
                obupdate.UserName = username;
                obupdate.PaymentDate = DateTime.Now;
                obupdate.PaymentMode = paymentmode;
                obupdate.ReferenceID = referenceid;
                
                db.SaveChanges();
            }
        }


        // not use any where yet
        public void order_details_crud(Guid id, decimal DeliveryFees, decimal TotalOrderAmount)
        {

            Order_Detail od = db.Order_Detail.FirstOrDefault(u => u.OrderGUID == id);

            if(od==null)
            {

                Order_Detail odi = new Order_Detail();

                odi.OrderGUID = id;
                odi.DeliveryFees = DeliveryFees;
                odi.TotalOrderAmount = TotalOrderAmount;


                db.Order_Detail.Add(odi);
                db.SaveChanges();
            }

            else
            {

                od.DeliveryFees = DeliveryFees;
                od.TotalOrderAmount = TotalOrderAmount;

             
                db.SaveChanges();
            }
        }



        public string cartcount(Guid Id)
        {


            var cartcounter = (from o in db.Order_Basic
                               where o.OrderGUID == Id
                               select o).Count();
           
            
            
            string a = cartcounter.ToString();



            return a;
        }





        public decimal  get_commission(string itemname, decimal price, int qty)
        {

            decimal value = 0;
            decimal cal = 0;
            decimal totalprice = price * qty;
            Website_Setup ws = db.Website_Setup.FirstOrDefault(u => u.ItemKey == itemname  && u.IsActive==true);

            if (ws != null)
            {
                cal = totalprice * decimal.Parse(ws.ItemValue.ToString());

                value = cal / 100;

            }

            return value;
        }


    }
