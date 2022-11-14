﻿using System;

namespace DataLayer.Helper
{
    public class Latlong
    {
        public string v_lat { get; set; }
        public string v_lon { get; set; }

        private double distance = 0;

        private string milesaway = "0";

        public string destinatoinlat(string destination)
        {
            string returnlat = "";

            //Website_Setup_Helper ws = new Website_Setup_Helper();
            //string apikey = ws.Website_description_return("GoogleMAPKey");

            //    string url = "https://maps.google.com/maps/api/geocode/xml?address=" + destination + "&sensor=false&key="+apikey;
            //    WebRequest request = WebRequest.Create(url);
            //    using (WebResponse response = (HttpWebResponse)request.GetResponse())
            //    {
            //        using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            //        {
            //            DataSet dsResult = new DataSet();
            //            dsResult.ReadXml(reader);
            //            foreach (DataRow row in dsResult.Tables["result"].Rows)
            //            {
            //                string geometry_id = dsResult.Tables["geometry"].Select("result_id = " + row["result_id"].ToString())[0]["geometry_id"].ToString();
            //                DataRow location = dsResult.Tables["location"].Select("geometry_id = " + geometry_id)[0];

            //                v_lat = location["lat"].ToString();
            //                v_lon = location["lng"].ToString();
            //            }

            //        }

            //    }
            v_lat = "23.014509";
            v_lon = "77.4977";

            return returnlat;
        }

        public double distancebetweenreturn(double lat1, double long1, double lat2, double long2)
        {
            System.Device.Location.GeoCoordinate source = new System.Device.Location.GeoCoordinate(lat1, long1);

            System.Device.Location.GeoCoordinate destination = new System.Device.Location.GeoCoordinate(lat2, long2);

            distance = source.GetDistanceTo(destination);

            if (distance >= 0)
            {
                //milesaway = Math.Round(Convert.ToDecimal(distance / 1000 * 0.62137), 2) + "";

                milesaway = Math.Round(Convert.ToDecimal(distance / 1000), 2) + "";
                milesaway = milesaway.ToString().Replace("Kms.", "").Replace("miles", "");
                milesaway = milesaway.ToString();

                distance = double.Parse(milesaway.ToString());
            }

            return distance;
        }
    }
}