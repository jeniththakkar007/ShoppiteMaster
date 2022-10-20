using DataLayer.Helper;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VendorPanel.usercontrol
{
    public partial class alert_membership : System.Web.UI.UserControl
    {


        Entities db = new Entities();
        Profile_Helper ph = new Profile_Helper();
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {
                string host = HttpContext.Current.Request.Url.Host.ToLower();

                if (host == "localhost")
                {

                    check_loginstatus();
                }
                bool membershipisfree = ph.vendormembershipstatus(this.Page.User.Identity.Name);

                ///global status of vendor membership
                Website_Setup_Helper wsh = new Website_Setup_Helper();

             

               string membershiptype= wsh.Vendormembershipstatus_return("VendorMembership");


                if(decimal.Parse(membershiptype.ToString()) >0)
                {



                    if (membershipisfree == false)
                    {
                        membershipstatus();

                    }


                }

            }

        }



        protected void vendorredirection()
        {
            PageCategory pg = db.PageCategories.FirstOrDefault(u => u.PageCategory1 == "Become a Vendor");

            if (pg != null)
            {

                Response.Redirect(pg.URL);
            }

        }

        protected void check_loginstatus()
        {

               if(this.Page.User.Identity.Name=="")
                {

                    vendorredirection();
                }

                else

                {
                    Profile_Helper ph = new Profile_Helper();

                    bool isvendor=ph.isvendor_status(this.Page.User.Identity.Name);

                     if(isvendor==false)
                     {
                         vendorredirection();
                     }


                }
        }

        protected void membershipstatus()
        {

           

            int profileid = ph.profile_return_id(this.Page.User.Identity.Name);

            Users_Membership um = db.Users_Membership.FirstOrDefault(u => u.ProfileId == profileid);


            if(um==null)
            {

                Response.Redirect("~/Lockout");
            }

            else
            {


                check_Paid_status(profileid);



               
            }
        }


        protected void check_Paid_status(int profileid)
        {

            var q = (from ms in db.Users_Membership
                     where ms.ProfileId == profileid
                     orderby ms.MembershipId descending
                     select ms

                          ).Take(1).ToList();


            if (q.Count != 0)
            {

                foreach (var item in q)
                {

                    DateTime membershipexpirydate = DateTime.Parse(item.EndDate.ToString());
                    string paymentstatus = item.PaymentStatus;

                    if (paymentstatus == "Pending")
                    {

                        Response.Redirect("~/Lockout?Status=Pending");
                    }

                        //membership expired
                    else if (membershipexpirydate < DateTime.Now)
                    {

                        Response.Redirect("~/Lockout?Status=Expired&ID=" + item.MembershipId);
                    }

                    else if (item.Cancellationdate != null && membershipexpirydate < DateTime.Now)
                    {

                        Response.Redirect("~/Lockout.aspx?Status=Cancelled&ID=" + item.MembershipId);
                    }

                }
            }

            else
            {

                Response.Redirect("~/Lockout.aspx");
            }
        }



    }
}