using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public class CustomFeesCalculation
    {

        decimal v_standarddeliveryfees = 24;
        int v_cartlimit = 3;
        decimal v_cartcost = 0;
        decimal v_addontax = 2;
        decimal v_calpercentage = 0;
        decimal customer_calpercentage = 0;
        decimal eachpriceqty = 0;
     




        public decimal customfees = 0;
        public decimal deliveryfees = 0;
        public decimal vat = 0;


        public void calculatefees(decimal price, int cartcount )
        {
            

            if(price <=100)
            {
                if (cartcount <= v_cartlimit)
                {
                    deliveryfees = v_standarddeliveryfees;

                }


                if (cartcount > v_cartlimit)
                {
                    v_addontax = (cartcount - v_cartlimit) * 2;
                    deliveryfees = v_standarddeliveryfees + v_addontax;
                }

            }


            if(price >100)
            {


                if(price >100 && price <=300)
                {

                    v_calpercentage = (price * 8)/100;

                    deliveryfees = v_standarddeliveryfees + v_calpercentage;
                }


                if (price > 300 && price <= 600)
                {

                    v_calpercentage = (price * 6)/100;

                    deliveryfees = v_standarddeliveryfees + v_calpercentage;
                }


                if (price > 600 && price <= 1200)
                {

                    v_calpercentage = (price * 5)/100;
                    deliveryfees = v_standarddeliveryfees + v_calpercentage;
                }

                if (price > 1200 && price <= 3000)
                {

                    v_calpercentage = (price * 4)/100;
                    deliveryfees = v_standarddeliveryfees + v_calpercentage;
                }

                if (price > 3000)
                {

                    v_calpercentage = (price * 3)/100;
                    deliveryfees = v_standarddeliveryfees + v_calpercentage;
                }

            }


            
            

        }



        public void calculat_VAT( decimal eachproductprice, int qty)
        {
            eachpriceqty = eachproductprice * qty;

            if (eachpriceqty > 50)
            {
                customer_calpercentage = (eachpriceqty * 19) / 100;
                vat = customer_calpercentage;

            }
        }


    }
