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
    
    public partial class Chat
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> Date_Time { get; set; }
        public string SenderId { get; set; }
        public string RecieverId { get; set; }
        public string Msg { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual AspNetUser AspNetUser1 { get; set; }
    }
}