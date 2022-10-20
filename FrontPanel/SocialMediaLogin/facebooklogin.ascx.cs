using ASPSnippets.FaceBookAPI;
using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontPanel.SocialMediaLogin
{
    public partial class facebooklogin : System.Web.UI.UserControl
    {

      Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            FaceBookConnect.API_Key = "443912082955492";
            FaceBookConnect.API_Secret = "f3003ef8fee6af3e2af8aca91d82abaf";
            if (!IsPostBack)
            {
                try
                {

            

                if (Session["Code"] != null)
                {

                    if (Session["Code"].ToString() == "Facebook")
                    {
                        if (Request.QueryString["error"] == "access_denied")
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('User has denied access.')", true);
                            return;
                        }

                        string facebookcode = Request.QueryString["code"];
                        if (!string.IsNullOrEmpty(facebookcode))
                        {
                            string data = FaceBookConnect.Fetch(facebookcode, "me?fields=id,name,email");
                            FaceBookUser faceBookUser = new JavaScriptSerializer().Deserialize<FaceBookUser>(data);
                            faceBookUser.PictureUrl = string.Format("https://graph.facebook.com/{0}/picture", faceBookUser.Id);
                            pnlFaceBookUser.Visible = true;
                            lblId.Text = faceBookUser.Id;
                            lblUserName.Text = faceBookUser.UserName;
                            lblName.Text = faceBookUser.Name;
                            lblEmail.Text = faceBookUser.Email;
                            ProfileImage.ImageUrl = faceBookUser.PictureUrl;
                            //btnLogin.Enabled = false;



                            if (lblUserName.Text != null)
                            {

                                createuser(lblId.Text, lblId.Text, lblEmail.Text, lblId.Text, lblName.Text);
                            }
                        }
                    }
                }
                }
                catch (Exception ex)
                {

                    lblerror.Text = ex.Message;
                }
            }
        }


        UserRegisterHelper ur = new UserRegisterHelper();
        protected void createuser(string username, string password, string email, string id, string name)
        {

         
            string type = "Client";

            if (Request.QueryString["Type"] != null)
            {

                type = Request.QueryString["Type"].ToString();
            }


            ErrorMessage.Text = ur.register(email, password, email);

            if (ErrorMessage.Text == "Success")
            {

                ur.login(email, password, true);
                pageredirect();

            }


            if (ErrorMessage.Text == "User Name already Exists. Please try another username.")
            {
                ur.login(email, password, true);
                pageredirect(); ;

            }

           
         
        }

        protected void pageredirect()
        {

            if (Session["OrderID"] != null)
            {


                Response.Redirect("~/customer/shippingdetail.aspx");
            }

            else
            {

                Response.Redirect("~/Default");
            }

        }

        protected void FacebookLogin(object sender, EventArgs e)
        {
            Session["Code"] = "Facebook";
            FaceBookConnect.Authorize("user_photos,email", Request.Url.AbsoluteUri.Split('?')[0]);
        }


        public class FaceBookUser
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string UserName { get; set; }
            public string PictureUrl { get; set; }
            public string Email { get; set; }
        }
    }
}