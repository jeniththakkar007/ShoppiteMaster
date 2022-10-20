
using DataLayer.Helper;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminPanel.usercontrol
{
    public partial class imagemultiupload_uc : System.Web.UI.UserControl
    {

        Entities db = new Entities();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                getallimags();
            }
        }


        protected  void insertimages(string image)
        {


            Guid id = Guid.Parse(Request.QueryString["ID"].ToString());
            Product_Images pi = new Product_Images();


            pi.Image = image;
            pi.ProductGUID = id;
            pi.InsertDate = DateTime.Now;
            pi.UserName = this.Page.User.Identity.Name;

            db.Product_Images.Add(pi);
            db.SaveChanges();





         


        }



        protected void getallimags()
        {
                Guid id = Guid.Parse(Request.QueryString["ID"].ToString());
            var q = (from pi in db.Product_Images
                   where pi.ProductGUID==id
                       select pi);

            ListView1.DataSource = q.ToList();
            ListView1.DataBind();

        }

        public void Upload()
        {
         

            if (fuUpload1.HasFiles)
            {
                foreach (HttpPostedFile postedFile in fuUpload1.PostedFiles)
                {
                    //CheckFile cf = new CheckFile();

                    AWS_Helper aw = new AWS_Helper();
                    lblfile.Text = aw.uploadfilemulti(postedFile);

                    insertimages(lblfile.Text);
                }
            }



            getallimags();
        }


        protected void delimage(int id)
        {
            Product_Images pi = db.Product_Images.FirstOrDefault(u => u.ProductImagesId == id);


            db.Product_Images.Remove(pi);
            db.SaveChanges();


        }

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string id = ((Label)e.Item.FindControl("Label1")).Text;
            if (e.CommandName == "del")
            {
                delimage(int.Parse(id));
                getallimags();
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            Upload();
        }
    }
}