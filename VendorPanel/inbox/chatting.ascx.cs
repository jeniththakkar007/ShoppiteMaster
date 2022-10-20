using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VendorPanel.inbox
{
    public partial class chatting : System.Web.UI.UserControl
    {

        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{

                allmessagebinding();
            //}



        }
        public string ConvertTextUrlToLink(string url)
        {
            string str = @"((www\.|(http|https)+\:\/\/)[_.a-z0-9-]+\.[a-z0-9\/_:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])";
            Regex regex = new Regex(str, RegexOptions.IgnoreCase);
            return regex.Replace(url, "<a href=\"$1\" target=\"_blank\">$1</a>").Replace("href=\"www", "href=\"https://www");
        }

        protected void allmessagebinding()
        {
            if (this.Request.QueryString["ID"] != null)
            {
                Guid id = Guid.Parse(this.Request.QueryString["ID"].ToString());

                var q = (from m in db.Messages
                         orderby m.MesageId descending
                         join p in db.Users_Profile on m.sender equals p.UserName
                         where m.ChatID == id
                         select new
                         {
                             messageid=m.MesageId,
                             shopname=p.ShopName,
                             sender=m.sender,
                             message1=m.Message1,
                             senddate=m.senddate,
                             attachment=m.Attachment,
                             sessionbookingid=m.SessionBookingId
                         }

                           );

                Label1.Text = id.ToString();
                ListView1.DataSource = q.OrderByDescending(u=>u.messageid).ToList();
                ListView1.DataBind();
            }
        }

        protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Label lblusername = ((Label)e.Item.FindControl("lblusername"));
                Label lblshopname = ((Label)e.Item.FindControl("Label2"));


                
                Image imguserimage = ((Image)e.Item.FindControl("Image1"));
                LinkButton lnkbtn = ((LinkButton)e.Item.FindControl("LinkButton1"));

                Label lblattachment = ((Label)e.Item.FindControl("lblattachment"));
                Label lblmessage = ((Label)e.Item.FindControl("Label5"));



                Panel pnl = ((Panel)e.Item.FindControl("Panel1"));




                Panel pnloofer = ((Panel)e.Item.FindControl("Panel2"));
                Label lbldatetime = ((Label)e.Item.FindControl("lbldatetime"));
                Label lblfees = ((Label)e.Item.FindControl("lblfees"));
                Label lbldescription = ((Label)e.Item.FindControl("lbldescription"));
                Label lblbookingid = ((Label)e.Item.FindControl("lblbookingid"));
                Label lblofferstatus = ((Label)e.Item.FindControl("lblofferstatus"));

                LinkButton Lnkaccept = ((LinkButton)e.Item.FindControl("lnkinvoice"));
                LinkButton Lnkwithdraw = ((LinkButton)e.Item.FindControl("lnkwithdraw"));

                var q = (from m in db.Users_Profile
                         where m.UserName == lblusername.Text
                         select m);



                Users_Profile p = db.Users_Profile.FirstOrDefault(u => u.UserName == lblusername.Text);


                //imguserimage.ImageUrl = p.avatar;

                if (lblusername.Text == Page.User.Identity.Name)
                {

                    pnl.CssClass = "chat2";
                }

                else
                {
                    pnl.CssClass = "chat1";

                }

                if (lblattachment.Text == "No")
                {

                    lnkbtn.Visible = false;
                }
                else
                {
                    lnkbtn.Visible = true;

                }




                Guid id = Guid.Parse(this.Request.QueryString["ID"].ToString());

                var qs = (from m in db.Messages
                          where m.recipient == this.Page.User.Identity.Name && m.status == "UnRead" && m.ChatID == id
                          select m).ToList();

                foreach (var item in qs)
                {
                    Message m = db.Messages.FirstOrDefault(u => u.MesageId == item.MesageId);


                    m.status = "Read";
                    db.SaveChanges();
                }



            }
        }

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string id = ((Label)e.Item.FindControl("lblattachment")).Text;

            Label lblbookingid = ((Label)e.Item.FindControl("lblbookingid"));


            if (e.CommandName == "download")
            {
                Response.Redirect(id);
            }



        }


        protected void Timer1_Tick(object sender, EventArgs e)
        {
            // your stuff to refresh after some interval
            allmessagebinding();
        }
    }
}