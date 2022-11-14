using DataLayer.Models;
using System;

namespace FrontPanel.SocialMediaLogin
{
    public partial class googlelogin : System.Web.UI.UserControl
    {
        private Entities db = new Entities();

        private string clientid = "736889147266-vmbpgdbes6fmbljbfbh1tghnmu58m4kh.apps.googleusercontent.com";
        private string clientsecret = "Fo1oBnkw2ZjcahJnJF-i1y-F";

        protected void Page_Load(object sender, EventArgs e)

        {
        }

        protected void GoogleLogin(object sender, EventArgs e)
        {
            Session["Code"] = "Google";

            string clientid = "736889147266-vmbpgdbes6fmbljbfbh1tghnmu58m4kh.apps.googleusercontent.com";
            string clientsecret = "Fo1oBnkw2ZjcahJnJF-i1y-F";
            string redirection_url = "http://ecomfront.kitaablife.com/SocialMediaLogin/googleauth";
            string url = "https://accounts.google.com/o/oauth2/v2/auth?scope=email&include_granted_scopes=true&redirect_uri=" + redirection_url + "&response_type=code&client_id=" + clientid + "";
            Response.Redirect(url);
        }
    }
}