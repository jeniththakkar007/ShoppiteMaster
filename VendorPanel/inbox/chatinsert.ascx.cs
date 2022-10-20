using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VendorPanel.inbox
{
    public partial class chatinsert : System.Web.UI.UserControl
    {


        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            //FileUpload1.Attributes["onchange"] = "UploadFile(this)";


            if (Request.QueryString["ID"] == null)
            {

                Button1.Enabled = false;
            }
        }


        //protected void Upload(object sender, EventArgs e)
        //{

        //    if (FileUpload1.HasFile)
        //    {
        //        CheckFile image = new CheckFile();

        //        HiddenField1.Value = image.UploadImages(FileUpload1);
        //    }

        //}








        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Message i = new Message();

            string recipient = "";


            Guid id = Guid.Parse(this.Request.QueryString["ID"].ToString());

            Message m = db.Messages.FirstOrDefault(u => u.ChatID == id);

            if (m.sender == Page.User.Identity.Name)
            {

                recipient = m.recipient;
            }

            else
            {

                recipient = m.sender;
            }


            i.ChatID = id;
            i.sender = Page.User.Identity.Name;
            i.senddate = DateTime.Parse(DateTime.Now.ToString());
            i.recipient = recipient.ToString();
            i.recieveddate = DateTime.Parse(DateTime.Now.ToString());
            i.status = "UnRead";
            i.Message1 = TextBox1.Text;
            i.Attachment = HiddenField1.Value;
            db.Messages.Add(i);
            db.SaveChanges();

            if (Global.IsEmailOnChat.ToString() == "True")
            {

                //if (Session["Email"] == null)
                //{
                C_ContactMe cht = new C_ContactMe();
                cht.sendmail(TextBox1.Text, recipient.ToString());
                Session["Email"] = "Sent";

                //}
            }

            TextBox1.Text = string.Empty;
            //Response.Redirect(Request.RawUrl);

        }
    }
}