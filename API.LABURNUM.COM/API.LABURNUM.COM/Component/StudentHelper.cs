using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class StudentHelper
    {
        private List<API.LABURNUM.COM.Student> Students;

        public StudentHelper()
        {
            this.Students = new List<API.LABURNUM.COM.Student>();
        }

        public StudentHelper(List<API.LABURNUM.COM.Student> students)
        {
            if (students == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.Students = students;
        }

        public StudentHelper(API.LABURNUM.COM.Student student)
        {
            if (student == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.Students = new List<API.LABURNUM.COM.Student>();
            this.Students.Add(student);
        }

        public List<DTO.LABURNUM.COM.StudentModel> Map()
        {
            if (this.Students == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.StudentModel> dtoStudent = new List<DTO.LABURNUM.COM.StudentModel>();
            foreach (API.LABURNUM.COM.Student item in this.Students)
            {
                dtoStudent.Add(MapCore(item));
            }
            return dtoStudent;
        }

        public DTO.LABURNUM.COM.StudentModel MapSingle()
        {
            if (this.Students == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.Students.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.Students[0]);
        }

        private DTO.LABURNUM.COM.StudentModel MapCore(API.LABURNUM.COM.Student student)
        {

            DTO.LABURNUM.COM.StudentModel dtoClass = new DTO.LABURNUM.COM.StudentModel()
            {
                StudentId = student.StudentId,
                ClassId = student.ClassId,
                SectionId = student.SectionId,
                Address = student.Address,
                BusRouteNumber = student.BusRouteNumber,
                ClassStartWithId = student.ClassStartWithId,
                DOB = student.DOB,
                EmailId = student.EmailId,
                FatherAadharNumber = student.FatherAadharNumber,
                FatherMobile = student.FatherMobile,
                FatherName = student.FatherName,
                FatherProfession = student.FatherProfession,
                FirstName = student.FirstName,
                Landline = student.Landline,
                LastName = student.LastName,
                MiddleName = student.MiddleName,
                Mobile = student.Mobile,
                MotherAadharNumber = student.MotherAadharNumber,
                MotherMobile = student.MotherMobile,
                MotherName = student.MotherName,
                MotherProfession = student.MotherProfession,
                PAN = student.PAN,
                SalutationId = student.SalutationId,
                StudentAadharNumber = student.StudentAadharNumber,
                CreatedOn = student.CreatedOn,
                IsActive = student.IsActive,
                LastUpdated = student.LastUpdated
            };
            return dtoClass;
        }
    }
}