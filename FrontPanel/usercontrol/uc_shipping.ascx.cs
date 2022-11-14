using DataLayer.Models;
using System;
using System.Linq;

namespace FrontPanel.usercontrol
{
    public partial class uc_shipping : System.Web.UI.UserControl
    {
        private Entities db = new Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.Identity.Name != "")
            {
                if (!IsPostBack)
                {
                    getlastshipping();
                    txtemail.Text = this.Page.User.Identity.Name;
                }
            }
        }

        public void insertshipping()
        {
            Guid id = Guid.Parse(Session["OrderID"].ToString());
            Order_Shipping ose = db.Order_Shipping.FirstOrDefault(u => u.OrderGUID == id);

            if (ose == null)
            {
                Order_Shipping os = new Order_Shipping();

                os.FirstName = txtfirstname.Text;
                os.LastName = txtlastname.Text;
                os.Address = txtaddress.Text;
                os.Street = txtstreet.Text;
                os.City = txtcity.Text;
                os.Zipcode = txtzipcode.Text;
                os.Phone = txtphone.Text;
                os.UserName = this.Page.User.Identity.Name;
                os.InsertDate = DateTime.Now;
                os.Email = txtemail.Text;
                os.OrderGUID = id;

                db.Order_Shipping.Add(os);
                db.SaveChanges();
            }
            else

            {
                Order_Shipping osei = db.Order_Shipping.FirstOrDefault(u => u.OrderGUID == id);
                osei.FirstName = txtfirstname.Text;
                osei.LastName = txtlastname.Text;
                osei.Address = txtaddress.Text;
                osei.Street = txtstreet.Text;
                osei.City = txtcity.Text;
                osei.Zipcode = txtzipcode.Text;
                osei.Phone = txtphone.Text;
                osei.UserName = this.Page.User.Identity.Name;
                osei.InsertDate = DateTime.Now;
                osei.Email = txtemail.Text;
                osei.OrderGUID = id;

                db.SaveChanges();
            }
        }

        protected void getlastshipping()
        {
            Order_Shipping os = db.Order_Shipping.FirstOrDefault(u => u.UserName == this.Page.User.Identity.Name);

            if (os != null)
            {
                txtfirstname.Text = os.FirstName;
                txtlastname.Text = os.LastName;
                txtaddress.Text = os.Address;
                txtstreet.Text = os.Street;
                txtcity.Text = os.City;
                txtphone.Text = os.Phone;
                txtzipcode.Text = os.Zipcode;
                txtemail.Text = os.Email;
            }
        }
    }
}