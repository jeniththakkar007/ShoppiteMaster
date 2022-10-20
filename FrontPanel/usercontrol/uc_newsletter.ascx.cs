using DataLayer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontPanel.usercontrol
{
    public partial class uc_newsletter : System.Web.UI.UserControl
    {

        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            NewsLetter nl = new NewsLetter();

            nl.Email = TextBox1.Text;
            nl.InsertDate = DateTime.Now;


            db.NewsLetters.Add(nl);
            db.SaveChanges();
            Label1.Text = "Subscribed Successfully";

            try
            {
                 ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                ServicePointManager.DefaultConnectionLimit = 9999;


                var apiKey = "b2b930e76b25d494b3d1d204fc4b3348-us4";
                var listId = "bca7d647ac";
                var email = TextBox1.Text;

                using (var wc = new System.Net.WebClient())
                {
                    // Data to be posted to add email address to list
                    var data = new { email_address = email, status = "subscribed" };

                    // Serialize to JSON using Json.Net
                    var json = JsonConvert.SerializeObject(data);

                    // Base URL to MailChimp API
                    string apiUrl = "https://us4.api.mailchimp.com/3.0/";

                    // Construct URL to API endpoint being used
                    var url = string.Concat(apiUrl, "lists/", listId, "/members");

                    // Set content type
                    wc.Headers.Add("Content-Type", "application/json");

                    // Generate authorization header
                    string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(":" + apiKey));

                    // Set authorization header
                    wc.Headers[HttpRequestHeader.Authorization] = string.Format("Basic {0}", credentials);

                    // Post and get JSON response
                    //string result = wc.UploadString(url, json);


                    string myresult = wc.UploadString(url, json);
                }
            }
            catch (Exception ex)
            {
                
                  Label1.Text = "Subscribed Successfully";
            }
        }
    }
}