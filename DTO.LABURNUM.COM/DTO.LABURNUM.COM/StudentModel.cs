using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class StudentModel
    {
        public StudentModel()
        {
            this.ApiClientModel = new ApiClientModel();
        }

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
        public string StudentUserName { get; set; }
        public string StudentPassword { get; set; }
        public string ParentUserName { get; set; }
        public string ParentPassword { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }

        public DTO.LABURNUM.COM.ApiClientModel ApiClientModel { get; set; }
        public bool IsStudentLogin { get; set; }
    }
}
