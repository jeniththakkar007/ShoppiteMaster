using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontPanel.usercontrol
{
    public partial class header_productstatus : System.Web.UI.UserControl
    {


        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                getproductstatus();
            }
        }



        protected void getproductstatus()
        {
            var q = db.SP_Status_HasProducts();
            //var q=(from stat in db.Status
            //           join productstatus in db.Product_Status on stat.StatusId equals productstatus.StatusId
            //           orderby stat.Status1 ascending
            //           where stat.ShowOnFront==true
            //           select stat).Distinct().ToList();


            ListView1.DataSource = q.ToList();
            ListView1.DataBind();
        }
    }
}