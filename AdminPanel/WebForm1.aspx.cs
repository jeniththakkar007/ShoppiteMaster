using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace AdminPanel
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DropDownList Categories = Master.FindControl("Categories") as DropDownList;
            DropDownList masterDropDown = (DropDownList)Master.FindControl("Categories");
            String selectedValue = masterDropDown.SelectedValue.ToString();

            //Master.Button1_Click();
        }

        private void GetData(String Search)
        {
            string Cs = "Data Source=103.150.186.216;Initial Catalog=Shoppite_master;User ID=sa;password=Z8Lix[jg3K@R74";
            using (SqlConnection con = new SqlConnection(Cs))
            {
                SqlCommand cmd = new SqlCommand("spSearch", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameter = new SqlParameter("@SearchTerm", Search ?? string.Empty);
                cmd.Parameters.Add(sqlParameter);
                con.Open();
                //GridView.DataSource = cmd.ExecuteReader();
                //GridView.DataBind();
            }
        }
    }
}