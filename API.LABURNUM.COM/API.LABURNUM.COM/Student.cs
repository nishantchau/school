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
    
    public partial class Student
    {
        public long StudentId { get; set; }
        public long ClassId { get; set; }
        public long ClassStartWithId { get; set; }
        public long SectionId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public long SalutationId { get; set; }
        public string EmailId { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public System.DateTime DOB { get; set; }
        public string Landline { get; set; }
        public string StudentAadharNumber { get; set; }
        public string FatherName { get; set; }
        public string FatherMobile { get; set; }
        public string FatherProfession { get; set; }
        public string PAN { get; set; }
        public string FatherAadharNumber { get; set; }
        public string MotherName { get; set; }
        public string MotherMobile { get; set; }
        public string MotherProfession { get; set; }
        public string MotherAadharNumber { get; set; }
        public Nullable<long> BusRouteNumber { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
    
        public virtual Class Class { get; set; }
        public virtual Class Class1 { get; set; }
        public virtual Salutation Salutation { get; set; }
        public virtual Section Section { get; set; }
    }
}
