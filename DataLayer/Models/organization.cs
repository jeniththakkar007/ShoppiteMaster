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
    
    public partial class organization
    {
        public int id { get; set; }
        public string org_name { get; set; }
        public string org_logo { get; set; }
        public string vender_name { get; set; }
        public string v_email { get; set; }
        public string v_phone { get; set; }
        public string v_mobile { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public Nullable<int> pincode { get; set; }
        public string org_address { get; set; }
        public string org_description { get; set; }
        public string v_bank_name { get; set; }
        public string v_account_number { get; set; }
        public string v_ifsc_code { get; set; }
        public string v_bank_branch_name { get; set; }
        public string v_upi_id { get; set; }
        public string v_id_proof { get; set; }
    }
}
