//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer.Models
{
    using System;
    
    public partial class SP_Order_Master_Result
    {
        public string orderid { get; set; }
        public Nullable<System.Guid> OrderGUID { get; set; }
        public string orderdeliverystatus { get; set; }
        public string orderdeliverystatusdate { get; set; }
        public Nullable<System.DateTime> orderdate { get; set; }
        public Nullable<decimal> totalPrice { get; set; }
        public int ProfileId { get; set; }
        public int BuyerId { get; set; }
    }
}
