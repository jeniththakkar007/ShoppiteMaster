using System;

namespace FrontPanel.moncash
{
    public partial class Success : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        //protected void vendorsendemails(Guid id)
        //{
        //    var q = (from ob in db.Order_Basic
        //             join p in db.Product_Basic on ob.ProductId equals p.ProductId
        //             join pr in db.Users_Profile on p.ProfileId equals pr.ProfileId
        //             join os in db.Order_Shipping on ob.OrderGUID equals os.OrderGUID
        //             where ob.OrderGUID == id
        //             select new
        //             {
        //                 email = pr.UserName,
        //                 FirstName = os.FirstName,
        //                 LastName = os.LastName
        //             }
        //               ).ToList().Distinct();

        //    foreach (var item in q)
        //    {
        //        emailsent2(item.email, item.FirstName + "-" + item.LastName, lblorder.Text);
        //    }
        //}
    }
}