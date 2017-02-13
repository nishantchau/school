using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class StudentFeeDetailHelper
    {
        private List<API.LABURNUM.COM.StudentFeeDetail> StudentFeeDetails;

        public StudentFeeDetailHelper()
        {
            this.StudentFeeDetails = new List<API.LABURNUM.COM.StudentFeeDetail>();
        }

        public StudentFeeDetailHelper(List<API.LABURNUM.COM.StudentFeeDetail> studentFeeDetails)
        {
            if (studentFeeDetails == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.StudentFeeDetails = studentFeeDetails;
        }

        public StudentFeeDetailHelper(API.LABURNUM.COM.StudentFeeDetail studentFeeDetail)
        {
            if (studentFeeDetail == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.StudentFeeDetails = new List<API.LABURNUM.COM.StudentFeeDetail>();
            this.StudentFeeDetails.Add(studentFeeDetail);
        }

        public List<DTO.LABURNUM.COM.StudentFeeDetailModel> Map()
        {
            if (this.StudentFeeDetails == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.StudentFeeDetailModel> dtoStudentFeeDetails = new List<DTO.LABURNUM.COM.StudentFeeDetailModel>();
            foreach (API.LABURNUM.COM.StudentFeeDetail item in this.StudentFeeDetails)
            {
                dtoStudentFeeDetails.Add(MapCore(item));
            }
            return dtoStudentFeeDetails;
        }

        public DTO.LABURNUM.COM.StudentFeeDetailModel MapSingle()
        {
            if (this.StudentFeeDetails == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.StudentFeeDetails.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.StudentFeeDetails[0]);
        }

        private DTO.LABURNUM.COM.StudentFeeDetailModel MapCore(API.LABURNUM.COM.StudentFeeDetail studentFeeDetail)
        {

            DTO.LABURNUM.COM.StudentFeeDetailModel dtoStudentFeeDetail = new DTO.LABURNUM.COM.StudentFeeDetailModel()
            {
                StudentFeeDetailId = studentFeeDetail.StudentFeeDetailId,
                StudentFeeId = studentFeeDetail.StudentFeeId,
                AdmissionFee = studentFeeDetail.AdmissionFee,
                AnnualCharges = studentFeeDetail.AnnualCharges,
                DevelopementCharges = studentFeeDetail.DevelopementCharges,
                ExamFee = studentFeeDetail.ExamFee,
                MonthlyFee = studentFeeDetail.MonthlyFee,
                SportsFee = studentFeeDetail.SportsFee,
                CreatedOn = studentFeeDetail.CreatedOn,
                IsActive = studentFeeDetail.IsActive,
                LastUpdated = studentFeeDetail.LastUpdated
            };
            return dtoStudentFeeDetail;
        }
    }
}