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
    using System.Collections.Generic;
    
    public partial class Order_Disbursement
    {
        public int OrderEarningId { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<System.DateTime> DisburseDate { get; set; }
        public string DisbursementMode { get; set; }
        public string DisbursementId { get; set; }
        public string InsertBy { get; set; }
        public Nullable<int> OrgId { get; set; }
    }
}
