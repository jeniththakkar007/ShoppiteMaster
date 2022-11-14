using DataLayer.Helper;
using DataLayer.Models;
using System;

namespace FrontPanel.Account
{
    public partial class Register : Page
    {
        private Entities db = new Entities();

        public string mapapi = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Website_Setup_Helper ws = new Website_Setup_Helper();
                HiddenField1.Value = "Client";
                hypterms.NavigateUrl = ws.Website_description_return("CustomerT&S");
                if (Request.QueryString["Type"] != null)
                {
                    HiddenField1.Value = Request.QueryString["Type"].ToString();

                    if (HiddenField1.Value == "Vendor")
                    {
                        vendor.Visible = true;
                        txtshopname.Text = string.Empty;

                        hypterms.NavigateUrl = ws.Website_description_return("VendorT&S");
                    }
                    else
                    {
                        txtshopname.Text = "Client";
                        vendor.Visible = false;
                    }
                }
                checkloggedin();
            }
        }

        protected void checkloggedin()
        {
            if (Page.User.Identity.Name != "")
            {
                Response.Redirect("~/Error/Error?Error=UserLogin");
            }
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            UserRegisterHelper ur = new UserRegisterHelper();

            ErrorMessage.Text = ur.register(txtemail.Text, txtpassword.Text, txtemail.Text);

            if (ErrorMessage.Text == "Success")
            {
                Profile_Helper ph = new Profile_Helper();

                Latlong ll = new Latlong();
                ll.destinatoinlat(txtaddress.Text);

                string lat = ll.v_lat;
                string lng = ll.v_lon;

                ph.create_Profile(txtemail.Text, HiddenField1.Value, txtshopname.Text, null, "Pending", "Active", txtphone.Text, txtaddress.Text, lat, lng);

                ur.login(txtemail.Text, txtpassword.Text, true);

                loging_redirection();
            }
        }

        protected void loging_redirection()
        {
            if (Session["OrderID"] != null)
            {
                Response.Redirect("~/cart");
            }
            else
            {
                if (HiddenField1.Value == "Vendor")
                {
                    Response.Redirect("~/Vendor");
                }
                else
                {
                    txtshopname.Text = "Client";
                    vendor.Visible = false; Response.Redirect("~/default");
                }
            }
        }
    }
}