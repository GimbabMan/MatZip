//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThirdProject.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Registration
    {
        public int RestaurantId { get; set; }
        public int MemberId { get; set; }
        public Nullable<bool> dummy { get; set; }
    
        public virtual Member Member { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
