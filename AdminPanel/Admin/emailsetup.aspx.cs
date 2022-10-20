using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminPanel.Admin
{
    public partial class emailsetup : System.Web.UI.Page
    {

        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                Email_Setup es = db.Email_Setup.FirstOrDefault(u => u.EmailSettingId == 1);

                if(es!=null)
                {

                    txtemail.Text = es.EmailFrom;
                    txtpaswod.Text = es.Password;
                    txtsmtpport.Text = es.SMTPPort.ToString();
                    txtsmtp.Text = es.Host;

                    txtbcc.Text = es.BCC;
                }

                
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Email_Setup es = db.Email_Setup.FirstOrDefault(u => u.EmailSettingId == 1);

            if (es != null)
            {

                es.EmailFrom = txtemail.Text ;
                 es.Password = txtpaswod.Text;
                 es.SMTPPort =int.Parse(txtsmtpport.Text) ;
                es.Host = txtsmtp.Text;

                 es.BCC = txtbcc.Text ;
                db.SaveChanges();

            }

            else

            {
                Email_Setup esi = new Email_Setup();

                esi.EmailFrom = txtemail.Text;
                esi.Password = txtpaswod.Text;
                esi.SMTPPort = int.Parse(txtsmtpport.Text);
                esi.Host = txtsmtp.Text;

                esi.BCC = txtbcc.Text;
                db.SaveChanges();
                db.Email_Setup.Add(esi);
                db.SaveChanges();


            }

            lblerror.Text = "Updated successfully";
        }
    }
}