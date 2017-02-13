using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class StudentFeeDetailApi
    {
        private LaburnumEntities _laburnum;

        public StudentFeeDetailApi()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddStudentFeeDetail(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            API.LABURNUM.COM.StudentFeeDetail apiStudentFeeDetail = new StudentFeeDetail()
            {
                StudentFeeId = model.StudentFeeId,
                AdmissionFee = model.AdmissionFee,
                AnnualCharges = model.AnnualCharges,
                DevelopementCharges = model.DevelopementCharges,
                ExamFee = model.ExamFee,
                MonthlyFee = model.MonthlyFee,
                SportsFee = model.SportsFee,
                CreatedOn = System.DateTime.Now,
                IsActive = true
            };
            this._laburnum.StudentFeeDetails.Add(apiStudentFeeDetail);
            this._laburnum.SaveChanges();
            return apiStudentFeeDetail.StudentFeeDetailId;
        }

        private long AddValidation(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            model.TryValidate();
            return AddStudentFeeDetail(model);
        }

        public long Add(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            model.StudentFeeDetailId.TryValidate();
            IQueryable<API.LABURNUM.COM.StudentFeeDetail> iQuery = this._laburnum.StudentFeeDetails.Where(x => x.StudentFeeDetailId == model.StudentFeeDetailId && x.IsActive == true);
            List<API.LABURNUM.COM.StudentFeeDetail> dbStudentFeeDetails = iQuery.ToList();
            if (dbStudentFeeDetails.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbStudentFeeDetails.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbStudentFeeDetails[0].StudentFeeId = model.StudentFeeId;
            dbStudentFeeDetails[0].AdmissionFee = model.AdmissionFee;
            dbStudentFeeDetails[0].AnnualCharges = model.AnnualCharges;
            dbStudentFeeDetails[0].DevelopementCharges = model.DevelopementCharges;
            dbStudentFeeDetails[0].ExamFee = model.ExamFee;
            dbStudentFeeDetails[0].SportsFee = model.SportsFee;
            dbStudentFeeDetails[0].MonthlyFee = model.MonthlyFee;
            dbStudentFeeDetails[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            model.StudentFeeDetailId.TryValidate();
            IQueryable<API.LABURNUM.COM.StudentFeeDetail> iQuery = this._laburnum.StudentFeeDetails.Where(x => x.StudentFeeDetailId == model.StudentFeeDetailId && x.IsActive == true);
            List<API.LABURNUM.COM.StudentFeeDetail> dbStudentFeeDetails = iQuery.ToList();
            if (dbStudentFeeDetails.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbStudentFeeDetails.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbStudentFeeDetails[0].IsActive = model.IsActive;
            dbStudentFeeDetails[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.StudentFeeDetail> GetStudentFeeDetailByAdvanceSearch(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            IQueryable<API.LABURNUM.COM.StudentFeeDetail> iQuery = null;
            if (model.StudentFeeDetailId > 0)
            {
                iQuery = this._laburnum.StudentFeeDetails.Where(x => x.StudentFeeDetailId == model.StudentFeeDetailId && x.IsActive == true);
            }
            if (iQuery != null) { if (model.StudentFeeId > 0) { iQuery = iQuery.Where(x => x.StudentFeeId == model.StudentFeeId && x.IsActive == true); } }
            else { if (model.StudentFeeId > 0) { iQuery = this._laburnum.StudentFeeDetails.Where(x => x.StudentFeeId == model.StudentFeeId && x.IsActive == true); } }

            List<API.LABURNUM.COM.StudentFeeDetail> dbStudentFeeDetails = iQuery.ToList();
            return dbStudentFeeDetails;
        }
    }
}