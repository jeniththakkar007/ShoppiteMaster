using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontPanel.inbox
{
    public partial class allmessages : System.Web.UI.UserControl
    {


        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            HiddenField1.Value = this.Page.User.Identity.Name;





        }

        protected void msgbinding()
        {



            //var q = db.F_AllContacts(this.Page.User.Identity.Name);


            //          var infoQuery =
            //(from cust in db.Messages
            // join p in db.Profiles on cust.sender equals p.UserName
            // where cust.sender==Page.User.Identity.Name
            // select new


            // {

            //   sender=  cust.sender,
            //   receiver=cust.recipient,
            //   image =p.Avatar

            // }
            // )
            //.Union
            //    (from emp in db.Messages
            //     join p in db.Profiles on emp.recipient equals p.UserName
            //     where emp.recipient == Page.User.Identity.Name
            //     select new{

            //         sender=  emp.sender,
            //         receiver=emp.recipient,
            //         image = p.Avatar



            //     }


            //    ).Distinct();








            //ListView1.DataSource = q.ToList();
            //ListView1.DataBind();


        }

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string id = ((Label)e.Item.FindControl("Label1")).Text;

            if (e.CommandName == "chat")
            {


                Response.RedirectToRoute("Detail", new { URL = this.Page.RouteData.Values["URL"].ToString(), ID=id });
                //Response.Redirect("~/Inbox/chat?ID=" + id);
            }



            if (e.CommandName == "del")
            {
                Guid delid = Guid.Parse(id);

                var q = (from m in db.Messages
                         where m.ChatID == delid
                         select m).ToList();

                foreach (var item in q)
                {
                    db.Messages.Remove(item);
                    db.SaveChanges();
                }


                ListView1.DataBind();

            }
        }

        protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {

                Label lblchatid = ((Label)e.Item.FindControl("Label1"));
                Panel pnl = ((Panel)e.Item.FindControl("Panel1"));
                Label lblusername = ((Label)e.Item.FindControl("Label2"));
                Label lblunread = ((Label)e.Item.FindControl("Label3"));

                if (Request.QueryString["ID"] != null)
                {




                    if (lblchatid.Text == Request.QueryString["ID"].ToString())
                    {

                        pnl.CssClass = "inbox";
                    }

                    else
                    {
                        pnl.CssClass = "inbox-selected";

                    }





                }

                else
                {


                    var q = (from m in db.Messages
                             where m.recipient == this.Page.User.Identity.Name && m.status == "UnRead" && m.sender == lblusername.Text
                             select m).Count();

                    if (q > 0)
                    {
                        lblunread.Text = q.ToString();

                    }



                }
            }

        }
    }
}