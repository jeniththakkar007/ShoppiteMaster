using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPanel.Helpers
{
    public class Common
    {
        public int GetOrganizationId()
        {
            Entities db = new Entities();
            if (HttpContext.Current == null) return 0;
            var host = HttpContext.Current.Request.Url.Host;
            if(host == "localhost")
                return 1;
            var subdomain = host.Split('.')[0];
            var orgdetails = db.organizations.FirstOrDefault(x => x.org_name == subdomain);
            return orgdetails.id;
        }

    }
}