namespace VendorPanel.Admin
{
    using DataLayer.Helper;
    using DataLayer.Models;
    using System;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    /// <summary>
    /// Defines the <see cref="Order_Master" />.
    /// </summary>
    public partial class Order_Master : System.Web.UI.Page
    {
        /// <summary>
        /// Defines the db.
        /// </summary>
        private Entities db = new Entities();

        /// <summary>
        /// Defines the phd.
        /// </summary>
        private Product_Helper phd = new Product_Helper();

        /// <summary>
        /// The Page_Load.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getdata();
            }
        }

        /// <summary>
        /// The getdata.
        /// </summary>
        protected void getdata()
        {
            Profile_Helper ph = new Profile_Helper();

            int profileid = ph.profile_return_id(Page.User.Identity.Name);

            Website_Setup_Helper website_Setup_Helper = new Website_Setup_Helper();
            var Url = HttpContext.Current.Request.Url;
            var subdomain = website_Setup_Helper.GetSubDomain(Url);
            var orgid = phd.GetOrgID();

            var q = db.SP_Order_Master(orgid).Where(u => u.ProfileId == profileid && u.orderdeliverystatus == RadioButtonList1.SelectedValue);

            if (txtsearch.Text != string.Empty)
            {
                q = q.Where(u => u.orderid.ToLower().Contains(txtsearch.Text.ToLower()));
            }

            ListView1.DataSource = q.ToList();
            ListView1.DataBind();
        }

        /// <summary>
        /// The RadioButtonList1_SelectedIndexChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getdata();
        }

        /// <summary>
        /// The LinkButton1_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            getdata();
        }
    }
}
