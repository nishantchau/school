using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class FeeModel
    {
        public FeeModel()
        {
            this.ApiClientModel = new ApiClientModel();
        }

        public long FeeId { get; set; }
        public long ClassId { get; set; }
        public long AdmissionTypeId { get; set; }
        public double AdmissionFee { get; set; }
        public Nullable<double> DevelopementCharges { get; set; }
        public Nullable<double> AnnualCharges { get; set; }
        public Nullable<double> ExamFee { get; set; }
        public Nullable<double> SportsFee { get; set; }
        public Nullable<double> MonthlyFee { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }

        public DTO.LABURNUM.COM.ApiClientModel ApiClientModel { get; set; }
    }
}
