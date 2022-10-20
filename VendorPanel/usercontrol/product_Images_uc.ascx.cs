using DataLayer;
using DataLayer.Helper;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VendorPanel.usercontrol
{
    public partial class product_Images_uc : System.Web.UI.UserControl
    {

        Entities db = new Entities();

        AWS_Helper aw = new AWS_Helper();

        //CheckFile cf = new CheckFile();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                getproductimage();
            }
            
            
        }


        protected void getproductimage()
        {
                Guid id = Guid.Parse(Request.QueryString["ID"].ToString());
            var q=(from pimage in db.Product_Images
                       where pimage.ProductGUID==id
                       select pimage);


            ListView1.DataSource = q.ToList();
            ListView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Guid id = Guid.Parse(Request.QueryString["ID"].ToString());
            Product_Images pid = new Product_Images();

            fileupload();
            pid.ProductGUID = id;
            pid.Image = aw.uploadfile(fuicon);
            pid.AltText = txtalt.Text;
            pid.Title = txtimagetitle.Text;
            pid.Displayorder = int.Parse(txtdisplayorder.Text);
            pid.InsertDate = DateTime.Now;
            pid.UserName = this.Page.User.Identity.Name;

            db.Product_Images.Add(pid);
            db.SaveChanges();


            getproductimage();
        }


        protected void fileupload()
        {
            if (fuicon.HasFile)
            {
               //imgicon.ImageUrl= cf.UploadImages(fuicon);

                imgicon.ImageUrl = aw.uploadfile(fuicon);
            }

        }

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string ID = ((Label)e.Item.FindControl("Label3")).Text;
            if (e.CommandName == "rem")
            {

                int id = int.Parse(ID);
                Product_Images pi = db.Product_Images.FirstOrDefault(u => u.ProductImagesId == id);

                db.Product_Images.Remove(pi);
                db.SaveChanges();

                getproductimage();
            }
        }
    }
}