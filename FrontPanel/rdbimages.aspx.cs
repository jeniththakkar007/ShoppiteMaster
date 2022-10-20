using DataLayer.Helper;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontPanel
{
    public partial class rdbimages : System.Web.UI.Page
    {
        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {



                this.BindRadioButtonList();

                Donation_Received dr = new Donation_Received();



                string amount = "214";



                //decimal amountdiv = decimal.Parse(amount.ToString()) / 100;

                string perf = "1.07";

                decimal reverseamount = decimal.Parse(amount.ToString()) / decimal.Parse(perf.ToString());


                dr.AdministrativeAmount = decimal.Parse(amount.ToString()) - reverseamount;

                dr.Amount = reverseamount;
                dr.PaymentDate = DateTime.Now;
                dr.PaypalId = ";;";

                db.Donation_Received.Add(dr);
                db.SaveChanges();
            }



        }

        protected void Save(object sender, EventArgs e)
        {
            string value = rblImages.SelectedValue;
            string name = rblImages.SelectedItem.ToString();

            //string name = GetImagesData().Select("Id=" + value)[0]["ImageName"].ToString();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "", "alert('Selected Image\\nName : " + name
                                                                        + "\\nValue : " + value + "')", true);
        }

        private void BindRadioButtonList()
        {

            Entities db = new Entities();

           var q=(from p in db.Product_Basic
                  select new
                  {

                      Path=p.CoverImage,
                      ImageName=p.ProductName,
                      Id=p.ProductId
                  }
                      
                      ).Take(5);


           foreach (var data in q)
           {
              
               ListItem item = new ListItem("<img src='" + data.Path + "' alt='" + data.ImageName + "'/>",data.Id.ToString());
               rblImages.Items.Add(item);
           }


            //for (int i = 0; i < this.GetImagesData().Rows.Count; i++)
            //{
               
            //}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            AWS_Helper aws= new AWS_Helper();

          aws.uploadfile(FileUpload1);

        }


        //private DataTable GetImagesData()
        //{
        //    string conString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        //    string query = "SELECT top 5 productid as Id, coverimage as path, 'abc' as imagename FROM Product_basic";
        //    SqlCommand cmd = new SqlCommand(query);
        //    using (SqlConnection con = new SqlConnection(conString))
        //    {
        //        cmd.Connection = con;
        //        using (SqlDataAdapter sda = new SqlDataAdapter())
        //        {
        //            sda.SelectCommand = cmd;
        //            using (DataTable dt = new DataTable())
        //            {
        //                sda.Fill(dt);

        //                return dt;
        //            }
        //        }
        //    }
        //}
    }
}