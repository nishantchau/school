using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class StudentFeeModel
    {
        public StudentFeeModel()
        {
            this.ApiClientModel = new ApiClientModel();
        }

        public long StudentFeeId { get; set; }
        public long StudentId { get; set; }
        public long ClassId { get; set; }
        public long AdmissionTypeId { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }

        public DTO.LABURNUM.COM.ApiClientModel ApiClientModel { get; set; }
    }
}
