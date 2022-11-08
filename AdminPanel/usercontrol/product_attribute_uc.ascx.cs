using DataLayer;
using DataLayer.Helper;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminPanel.usercontrol
{
    public partial class product_attribute_uc : System.Web.UI.UserControl
    {
        Entities db = new Entities();
        CommaSeperation cs = new CommaSeperation();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                getdata();
                getproductattributes();


              


            }
        }



        protected void getdata()
        {

             var q=(from p in db.Attributes_Setup
                        orderby p.AttributeName
                        select p);

             //chkattribute.DataTextField = "AttributeName";
             //chkattribute.DataValueField = "AttributeId";


             ListView2.DataSource = q.ToList();
             ListView2.DataBind();
        }


        protected void insert()
        {

            Product_Attribute pa = new Product_Attribute();
              Guid id = Guid.Parse(Request.QueryString["ID"].ToString());



              //foreach (ListItem listItem in chkattribute.Items)
              //{
              //    if (listItem.Selected)
              //    {
              //        pa.ProductGUID = id;
              //        pa.AttributeId = int.Parse(listItem.Value);
              //        pa.InsertDate = DateTime.Now;
              //        pa.UserName = this.Page.User.Identity.Name;

              //        db.Product_Attribute.Add(pa);
              //        db.SaveChanges();
              //    }
                  
              //}


            

        }

        protected void delete()
        {

            Guid id = Guid.Parse(Request.QueryString["ID"].ToString());
          
            var q=(from pa in db.Product_Specification
                       where  pa.ProductGUID==id
                       select pa).ToList();


            foreach (var item in q)
            {


                int did = int.Parse(item.ProductSpecificationId.ToString());
                Product_Specification pa = db.Product_Specification.FirstOrDefault(u => u.ProductSpecificationId == did);

                db.Product_Specification.Remove(pa);
                    db.SaveChanges();
                
            }
            


        }
      

        //protected void chkattribute_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Guid id = Guid.Parse(Request.QueryString["ID"].ToString());
        //    Product_Attribute pa = db.Product_Attribute.FirstOrDefault(u => u.ProductGUID == id);

        //    if (pa != null)
        //    {
        //        delete();
        //        insert();
        //    }

        //    else
        //    {

        //        insert();
        //    }


        //    getproductattributes();
        //}



        protected void getproductattributes()
        {
            Guid id = Guid.Parse(Request.QueryString["ID"].ToString());

         var q=(from Attributesetup in db.Attributes_Setup
                    join specificationsetup in db.Specification_Setup on Attributesetup.AttributeId equals specificationsetup.AttributeId
                join productspecification in db.Product_Specification on specificationsetup.SpecificationId equals productspecification.SpecificationId
                where productspecification.ProductGUID==id
                orderby specificationsetup.SpecificationName

                select new
                {

                    AttributeName=Attributesetup.AttributeName,
                    Specificationname=specificationsetup.SpecificationName,
                    specificationid=productspecification.SpecificationId,
                    productspecificationid= productspecification.ProductSpecificationId,
                    price=productspecification.Price,
                    image=productspecification.Image
                   

                }
                    
                    );




            ListView1.DataSource = q.ToList();
            ListView1.DataBind();

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

           Guid id = Guid.Parse(Request.QueryString["ID"].ToString());
           
            foreach (ListViewItem item in ListView2.Items)
            {
                //Label productattributeid = (Label)item.FindControl("Label3");
                //FileUpload fileicon = (FileUpload)item.FindControl("fuicon");
                //TextBox txtvariationprice = (TextBox)item.FindControl("txtprice");
                //DropDownList ddlcontroltype = (DropDownList)item.FindControl("DropDownList1");

                CheckBoxList chklist = (CheckBoxList)item.FindControl("chkattribute");

                foreach (ListItem listItem in chklist.Items)
                {

                    int sid = int.Parse(listItem.Value);
                    if (listItem.Selected==false)
                    {
                        Product_Specification delps = db.Product_Specification.FirstOrDefault(u => u.ProductSpecificationId == sid && u.ProductGUID == id);


                        if(delps !=null)
                        {

                            db.Product_Specification.Remove(delps);
                            db.SaveChanges();
                        }
                    }
                   
                }

             



          

                string a = cs.chcklistreturn(chklist);
                // string f="NA";
                // decimal variationprice = 0;

                //if (fileicon.HasFile)
                //{
                //   f = cf.UploadImages(fileicon);
                //}


                //if(txtvariationprice.Text !=string.Empty)
                //{

                //  variationprice=  decimal.Parse(txtvariationprice.Text);
                //}

                List<string> abclist = a.Split(',').ToList();
                foreach (string s in abclist)
                {
                    if (s != string.Empty)
                    {
                        int sid = int.Parse(s.ToString());

                        Product_Specification delps = db.Product_Specification.FirstOrDefault(u => u.SpecificationId == sid && u.ProductGUID == id);



                        if (delps == null)
                        {

                            Product_Specification ps = new Product_Specification();



                            ps.ProductGUID = id;
                            ps.SpecificationId = sid;
                            //ps.ControlType = ddlcontroltype.SelectedValue;
                            //ps.Price = variationprice;
                            ps.Image = "/images/noimage.png";
                            ps.Insertdate = DateTime.Now;
                            ps.UserName = this.Page.User.Identity.Name;

                            db.Product_Specification.Add(ps);
                            db.SaveChanges();
                        }
                    }
                }

              


            }


            getproductattributes();
        }

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string id = ((Label)e.Item.FindControl("Label5")).Text;
            if (e.CommandName == "del")
            {
                int delid = int.Parse(id);

                Product_Specification pa = db.Product_Specification.FirstOrDefault(u => u.ProductSpecificationId == delid);

                db.Product_Specification.Remove(pa);
                db.SaveChanges();


                getproductattributes();
               
            }
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            //CheckFile cf = new CheckFile();
            AWS_Helper aw = new AWS_Helper();
            foreach (ListViewItem item in ListView1.Items)
            {
                Label id = (Label)item.FindControl("Label5");
                FileUpload fileicon = (FileUpload)item.FindControl("fuicon");
                TextBox txtvariationprice = (TextBox)item.FindControl("txtprice");
                DropDownList ddlcontroltype = (DropDownList)item.FindControl("DropDownList1");


                string f = "/images/noimage.png";
                decimal variationprice = 0;

                if (fileicon.HasFile)
                {
                    String masterDropDown = (((this.Parent.Page.Master) as MasterPage).FindControl("ddlorganization") as DropDownList).SelectedItem.Value;
                    int selectedOrg = Convert.ToInt32(masterDropDown);
                    string fileconfigpath = WebConfigurationManager.AppSettings["filepath"];
                    string filepath = fileconfigpath + selectedOrg + "/Status/"+ fileicon.FileName;
                    f = aw.uploadfile(fileicon, filepath);
                }


                if (txtvariationprice.Text != string.Empty)
                {

                    variationprice = decimal.Parse(txtvariationprice.Text);
                }

                int updateid = int.Parse(id.Text);

                Product_Specification ps = db.Product_Specification.FirstOrDefault(u => u.ProductSpecificationId == updateid);



                ps.ControlType = ddlcontroltype.SelectedValue;
                ps.Price = variationprice;
                ps.Image = f;
                 

                  
                    db.SaveChanges();
                


            }


            getproductattributes();
        }

        protected void ListView2_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                // Display the e-mail address in italics.

            
                 Guid id = Guid.Parse(Request.QueryString["ID"].ToString());
                CheckBoxList chklist = (CheckBoxList)e.Item.FindControl("chkattribute");


                var q = (from ps in db.Product_Specification
                         where ps.ProductGUID == id
                         select ps).ToList();

                foreach (var item in q)
                {
                    int spid = int.Parse(item.SpecificationId.ToString());



                    foreach (ListItem listItem in chklist.Items)
                    {

                        if(listItem.Value == spid.ToString())
                        {

                            listItem.Selected = true;
                        }


                       
                    }
                }
               
            }
        }
    }
}