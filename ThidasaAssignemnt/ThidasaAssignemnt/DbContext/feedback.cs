//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThidasaAssignemnt.DbContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class feedback
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public string ClientId { get; set; }
        public string Comment { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual AspNetUser AspNetUser1 { get; set; }
    }
}