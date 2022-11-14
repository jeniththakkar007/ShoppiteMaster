using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminPanel
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ddlorganization.Items.FindByValue("1").Selected = true;
                if (Page.User.Identity.Name == "")
                {
                    Response.Redirect("~/account/login");
                }
                else

                {
                    if (Page.User.Identity.Name == "Admin" || Page.User.Identity.Name == "admin")
                    {
                    }
                    else

                    {
                        Response.Redirect("~/account/login");
                    }
                }
            }
            string constr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            // connection string
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand com = new SqlCommand("SELECT [id], [org_name], [org_logo], [vender_name], [v_email], [v_phone], [v_mobile], [state], [city], [pincode], [org_address], [org_description], [v_bank_name], [v_account_number], [v_ifsc_code], [v_id_proof], [v_upi_id], [v_bank_branch_name] FROM [organization]", con);
            // table name
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset
            ddlorganization.DataTextField = ds.Tables[0].Columns["org_name"].ToString(); // text field name of table dispalyed in dropdown
            ddlorganization.DataValueField = ds.Tables[0].Columns["id"].ToString();
            // to retrive specific  textfield name
            ddlorganization.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist
            ddlorganization.DataBind();  //binding dropdownlist
            ddlorganization.SelectedIndex = 0;
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        }

        public string SelectedValue
        {
            get
            {
                return ddlorganization.SelectedValue;
            }
            set
            {
                ddlorganization.SelectedValue = value;
            }
        }

        protected void ddlorganization_DataBound(object sender, EventArgs e)
        {
            ddlorganization.SelectedValue = "1";
            SelectedValue = "1";
        }

        //public Button Button1Click
        //{
        //    get;
        //    set;
        //}
    }
}