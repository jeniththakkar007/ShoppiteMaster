using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminPanel.usercontrol
{
    public partial class discount_module_uc : System.Web.UI.UserControl
    {

        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {


                    int Id = int.Parse(Request.QueryString["ID"].ToString());

                    Product_Discount pd = db.Product_Discount.FirstOrDefault(u => u.DiscountId == Id);


                    RadioButtonList1.SelectedValue =pd.DiscountType;
                   txtdiscountoffer.Text=pd.DiscountOffer.ToString();
                   txtdisstartdate.Text=pd.DiscountStartDate.ToString();
                   txtdisenddate.Text=pd.DiscountEndDate.ToString();
                   CheckBox1.Checked = bool.Parse(pd.IsActive.ToString());
                   
                  
                }
            }
        }




       

        public string Dis_RadioButtonList1
        {
            get { return RadioButtonList1.SelectedValue; }
            set { RadioButtonList1.SelectedValue = value; }
        }



        public string Dis_txtdiscountoffer
        {
            get { return txtdiscountoffer.Text; }
            set { txtdiscountoffer.Text = value; }
        }




        public string Dis_txtdisstartdate
        {
            get { return txtdisstartdate.Text; }
            set { txtdisstartdate.Text = value; }
        }



        public string Dis_txtdisenddate
        {
            get { return txtdisenddate.Text; }
            set { txtdisenddate.Text = value; }
        }

      

        protected void Button1_Click(object sender, EventArgs e)
        {
            string moduletype = "All";
            string moduleid = string.Empty;

            if (Request.QueryString["ID"] == null)
            {
                Product_Discount pd = new Product_Discount();


                pd.DiscountType = RadioButtonList1.SelectedValue;
                pd.DiscountOffer = decimal.Parse(txtdiscountoffer.Text);
                pd.DiscountStartDate = DateTime.Parse(txtdisstartdate.Text);
                pd.DiscountEndDate = DateTime.Parse(txtdisenddate.Text);
                pd.ModuleType = moduletype;
                pd.ModuleID = moduleid;
                pd.InsertDate = DateTime.Now;
                pd.IsActive = CheckBox1.Checked;


                db.Product_Discount.Add(pd);
                db.SaveChanges();

            }

            else
            {

                int Id = int.Parse(Request.QueryString["ID"].ToString());

                Product_Discount pd = db.Product_Discount.FirstOrDefault(u => u.DiscountId == Id);


                pd.DiscountType = RadioButtonList1.SelectedValue;
                pd.DiscountOffer = decimal.Parse(txtdiscountoffer.Text);
                pd.DiscountStartDate = DateTime.Parse(txtdisstartdate.Text);
                pd.DiscountEndDate = DateTime.Parse(txtdisenddate.Text);
                pd.ModuleType = moduletype;
                pd.ModuleID = moduleid;
                pd.InsertDate = DateTime.Now;
                pd.IsActive = CheckBox1.Checked;



                db.SaveChanges();
            }


            Response.Redirect(Request.RawUrl);
        }

        
    }
}