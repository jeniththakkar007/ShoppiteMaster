﻿using DataLayer.Models;
using System;
using System.Linq;

namespace DataLayer.Helper
{
    public class Website_Setup_Helper
    {
        public string logo { get; set; }
        public string companyname { get; set; }
        public string favicon { get; set; }

        public string title { get; set; }
        public string keyword { get; set; }
        public string description { get; set; }

        public string emailfrom { get; set; }

        public string bcc { get; set; }
        public string password { get; set; }
        public string smtp { get; set; }
        public int port { get; set; }

        private Entities db = new Entities();
        private Product_Helper ph = new Product_Helper();

        public void getwebsiteinfo()
        {
            Logo lo = db.Logoes.FirstOrDefault(x => x.LogoId == 1);
            if (lo != null)
            {
                logo = lo.Logo1;
                companyname = lo.CompanyName;
                favicon = lo.Favicon;

                ///meta tag
                ///
                title = lo.Title;
                keyword = lo.Keyword;
                description = lo.Description;
            }
        }

        public string paymetgateway_return(string type)
        {
            string value;
            Website_Setup md = db.Website_Setup.FirstOrDefault(u => u.ItemKey == type);

            value = md.ItemDescription;

            return value;
        }

        public string Website_description_return(string type)
        {
            string value;
            Website_Setup md = db.Website_Setup.FirstOrDefault(u => u.ItemKey == type);

            value = md.ItemDescription.ToString();

            return value;
        }

        public string Vendormembershipstatus_return(string type)
        {
            string value;
            Website_Setup md = db.Website_Setup.FirstOrDefault(u => u.ItemKey == type);

            value = md.ItemValue.ToString();

            return value;
        }

        public bool Setup_Enable(string itemname)
        {
            bool isactive = false;

            Website_Setup ws = db.Website_Setup.FirstOrDefault(u => u.ItemKey == itemname && u.IsActive == true);

            if (ws != null)
            {
                isactive = bool.Parse(ws.IsActive.ToString());
            }

            return isactive;
        }

        public string GetSubDomain(Uri url)
        {
            if (url.HostNameType == UriHostNameType.Dns)
            {
                string host = url.Host;

                var nodes = host.Split('.');
                int startNode = 0;
                if (nodes[0] == "www") startNode = 1;

                return string.Format("{0}.{1}", nodes[startNode], nodes[startNode]);
            }

            return null;
        }

        public void setupemail()
        {
            Email_Setup es = db.Email_Setup.FirstOrDefault(u => u.EmailSettingId == 1);

            if (es != null)
            {
                emailfrom = es.EmailFrom;
                password = es.Password;
                bcc = es.BCC;
                port = int.Parse(es.SMTPPort.ToString());
                smtp = es.Host;
            }
        }
    }
}