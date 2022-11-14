using System;

namespace FrontPanel
{
    public partial class search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                callgetproductfunction();
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                homepage_brands.getbrands();
            }
        }

        protected void SortList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["SortList"] = SortList.SelectedValue;
            Session["DirectionList"] = DirectionList.SelectedValue;

            callgetproductfunction();
        }

        protected void callgetproductfunction()
        {
            if (txtpricestart.Text != string.Empty && txtpriceend.Text != string.Empty)
            {
                search_allproducts.pricestart = int.Parse(txtpricestart.Text);
                search_allproducts.priceend = int.Parse(txtpriceend.Text);
            }

            if (homepage_brands.Br_lblselectedbrand != string.Empty)
            {
                search_allproducts.brands = homepage_brands.Br_lblselectedbrand;
            }

            search_allproducts.getproduct();
            //lblitemfound.Text = search_allproducts.totalrecordfound;
            lbltotalrecords.Text = search_allproducts.totalavailrecords;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            callgetproductfunction();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
    }
}