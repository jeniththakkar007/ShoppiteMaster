using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public class Packages_Helper
    {



        Entities db = new Entities();

        public decimal fees=0;
        public string currency = "";
        public int recurringdays = 0;
        public void getpackagebyid(int packageid)
        {


            var q=(from vm in db.Vendor_Membership_Package
                       join c in db.Currencies on vm.CurrencyId equals c.CurrencyId
                       where vm.Membershipid==packageid
                   select new
                   {

                       fess=vm.Fees,
                       currency=c.CurrencyName,
                       recurringdays=vm.RecurringPeriod
                   }
                       
                       );


            foreach (var item in q)
            {
                fees=decimal.Parse(item.fess.ToString());
                currency=item.currency;
                recurringdays =int.Parse(item.recurringdays.ToString());
            }



        }
    }
