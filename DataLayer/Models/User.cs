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
    
    public partial class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> LastLoginDate { get; set; }
        public System.Guid GUID { get; set; }
        public Nullable<int> OrgId { get; set; }
    }
}
