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
    
    public partial class StudentFeeDetail
    {
        public long StudentFeeDetailId { get; set; }
        public long StudentFeeId { get; set; }
        public double AdmissionFee { get; set; }
        public Nullable<double> DevelopementCharges { get; set; }
        public Nullable<double> AnnualCharges { get; set; }
        public Nullable<double> ExamFee { get; set; }
        public Nullable<double> SportsFee { get; set; }
        public Nullable<double> MonthlyFee { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
    
        public virtual StudentFee StudentFee { get; set; }
    }
}