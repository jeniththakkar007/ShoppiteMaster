using DataLayer.Models;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace FrontPanel.SocialMediaLogin
{
    public partial class googleauth : System.Web.UI.Page
    {
        private Entities db = new Entities();

        public class Tokenclass
        {
            public string access_token { get; set; }
            public string token_type { get; set; }
            public int expires_in { get; set; }
            public string refresh_token { get; set; }
        }

        public class Userclass
        {
            public string id { get; set; }
            public string name { get; set; }
            public string given_name { get; set; }
            public string family_name { get; set; }
            public string link { get; set; }
            public string picture { get; set; }
            public string gender { get; set; }
            public string locale { get; set; }

            public string email { get; set; }
        }

        private string clientid = "736889147266-vmbpgdbes6fmbljbfbh1tghnmu58m4kh.apps.googleusercontent.com";
        private string clientsecret = "Fo1oBnkw2ZjcahJnJF-i1y-F";
        private string redirection_url = "http://ecomfront.kitaablife.com/SocialMediaLogin/googleauth";
        private string url = "https://accounts.google.com/o/oauth2/token";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["code"] != null)
                {
                    GetToken(Request.QueryString["code"].ToString());
                }
            }
        }

        public void GetToken(string code)
        {
            string poststring = "grant_type=authorization_code&code=" + code + "&client_id=" + clientid + "&client_secret=" + clientsecret + "&redirect_uri=" + redirection_url + "";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";
            UTF8Encoding utfenc = new UTF8Encoding();
            byte[] bytes = utfenc.GetBytes(poststring);
            Stream outputstream = null;
            try
            {
                request.ContentLength = bytes.Length;
                outputstream = request.GetRequestStream();
                outputstream.Write(bytes, 0, bytes.Length);
            }
            catch
            { }
            var response = (HttpWebResponse)request.GetResponse();
            var streamReader = new StreamReader(response.GetResponseStream());
            string responseFromServer = streamReader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Tokenclass obj = js.Deserialize<Tokenclass>(responseFromServer);
            GetuserProfile(obj.access_token);
        }

        public void GetuserProfile(string accesstoken)
        {
            string url = "https://www.googleapis.com/oauth2/v1/userinfo?alt=json&access_token=" + accesstoken + "";
            WebRequest request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Userclass userinfo = js.Deserialize<Userclass>(responseFromServer);

            imgprofile.ImageUrl = userinfo.picture;
            lblid.Text = userinfo.id;
            lblgender.Text = userinfo.gender;
            lbllocale.Text = userinfo.locale;
            lblname.Text = userinfo.name;
            hylprofile.NavigateUrl = userinfo.link;
            lblemail.Text = userinfo.email;

            if (lblid.Text != null)
            {
                createuser(lblemail.Text, lblid.Text, lblemail.Text, lblid.Text, lblname.Text);
            }
        }

        protected void createuser(string username, string password, string email, string id, string name)
        {
            UserRegisterHelper ur = new UserRegisterHelper();
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
                pageredirect();
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
    }
}