using DataLayer.Helper;
using DataLayer.Models;
using System;
using System.Linq;

public class Profile_Helper
{
    private Entities db = new Entities();

    private Product_Helper phd = new Product_Helper();

    public string getvendoruser_byshopname(string shopnameurlpath)
    {
        string vendorusername = "";
        Users_Profile up = db.Users_Profile.FirstOrDefault(u => u.ProfileId + "-" + u.ShopURLPath == shopnameurlpath);

        if (up != null)
        {
            vendorusername = up.UserName;
        }

        return vendorusername;
    }

    public int profile_return_id(string username)
    {
        var orgid = phd.GetOrgID();
        int id = 0;

        Users_Profile up = db.Users_Profile.FirstOrDefault(u => u.UserName == username && u.OrgId == orgid);

        if (up != null)
        {
            id = up.ProfileId;
        }

        return id;
    }

    public bool isvendor_status(string username)
    {
        bool isvendor = true;

        Users_Profile up = db.Users_Profile.FirstOrDefault(u => u.UserName == username);

        if (up != null)
        {
            if (up.Type != "Vendor")
            {
                isvendor = false;
            }
        }

        return isvendor;
    }

    public bool vendormembershipstatus(string username)
    {
        bool isfree = true;
        Users_Profile up = db.Users_Profile.FirstOrDefault(u => u.UserName == username);

        if (up != null)
        {
            isfree = bool.Parse(up.IsMembershipFree.ToString());
        }

        return isfree;
    }

    public void create_Profile(string username, string type, string shopname, string logo, string adminstatus, string status, string phone, string address, string lat, string lang)
    {
        Users_Profile upudate = db.Users_Profile.FirstOrDefault(u => u.UserName == username);
        CreateURLPath_Helper ch = new CreateURLPath_Helper();

        Website_Setup_Helper wsh = new Website_Setup_Helper();

        string membershiptype = wsh.Vendormembershipstatus_return("VendorMembership");

        bool memberstatus = true;
        if (decimal.Parse(membershiptype.ToString()) > 0)
        {
            memberstatus = false;
        }

        if (upudate == null)
        {
            Users_Profile up = new Users_Profile();
            up.UserName = username;
            up.Type = type;
            up.InsertDate = DateTime.Now;
            up.AdminStatus = "Pending";
            up.Status = status;
            up.ShopName = shopname;
            up.ShopURLPath = ch.createurlpath(shopname);
            up.IsMembershipFree = memberstatus;
            up.ContactNumber = phone;
            up.Address = address;
            up.latitude = lat;
            up.longitude = lang;
            //up.ProfileGUID = Guid.NewGuid();

            db.Users_Profile.Add(up);
            db.SaveChanges();
        }
        else
        {
            upudate.ShopName = shopname;
            upudate.Logo = logo;
            upudate.AdminStatus = adminstatus;
            upudate.Status = status;

            db.SaveChanges();
        }
    }

    public int profileid { get; set; }
    public string profileguid { get; set; }
    public string type { get; set; }
    public string insertdate { get; set; }
    public string adminstatus { get; set; }
    public string status { get; set; }

    public string shopname { get; set; }
    public string logo { get; set; }
    public string contactnumber { get; set; }
    public string country { get; set; }
    public string city { get; set; }
    public string zip { get; set; }
    public string state { get; set; }
    public string address { get; set; }
    public string shopdescription { get; set; }
    public string paypalid { get; set; }

    private Product_Helper ph = new Product_Helper();

    public void getprofile(string username)
    {
        var orgid = ph.GetOrgID();

        Users_Profile p = db.Users_Profile.FirstOrDefault(u => u.UserName == username && u.OrgId == orgid);

        profileid = p.ProfileId;
        profileguid = p.ProfileGUID.ToString();
        type = p.Type;
        insertdate = p.InsertDate.ToString();
        adminstatus = p.AdminStatus;
        status = p.Status;
        shopname = p.ShopName;
        logo = p.Logo;
        contactnumber = p.ContactNumber;
        country = p.Country;
        city = p.City;
        zip = p.Zip;
        state = p.State;
        address = p.Address;
        shopdescription = p.ShopDescription;
        paypalid = p.PaypalId;
    }
}