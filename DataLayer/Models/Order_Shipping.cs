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
    
    public partial class Order_Shipping
    {
        public int ShippingId { get; set; }
        public Nullable<System.Guid> OrderGUID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string Phone { get; set; }
        public Nullable<System.DateTime> InsertDate { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Contactnumber { get; set; }
        public Nullable<int> OrgId { get; set; }
    }
}
