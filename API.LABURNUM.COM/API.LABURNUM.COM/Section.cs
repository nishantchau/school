//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API.LABURNUM.COM
{
    using System;
    using System.Collections.Generic;
    
    public partial class Section
    {
        public Section()
        {
            this.Students = new HashSet<Student>();
        }
    
        public long SectionId { get; set; }
        public string SectionName { get; set; }
        public long ClassId { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
    
        public virtual Class Class { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}