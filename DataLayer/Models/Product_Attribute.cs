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
    
    public partial class Product_Attribute
    {
        public int ProductAttributeID { get; set; }
        public Nullable<System.Guid> ProductGUID { get; set; }
        public Nullable<int> AttributeId { get; set; }
        public Nullable<System.DateTime> InsertDate { get; set; }
        public string UserName { get; set; }
        public Nullable<int> OrgId { get; set; }
    }
}
