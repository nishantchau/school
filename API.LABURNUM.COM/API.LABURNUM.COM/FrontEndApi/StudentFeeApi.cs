using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class StudentFeeApi
    {
        private LaburnumEntities _laburnum;

        public StudentFeeApi()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddStudentFee(DTO.LABURNUM.COM.StudentFeeModel model)
        {
            API.LABURNUM.COM.StudentFee apiStudentFee = new StudentFee()
            {
                StudentId = model.StudentId,
                AdmissionTypeId = model.AdmissionTypeId,
                ClassId = model.ClassId,
                CreatedOn = System.DateTime.Now,
                IsActive = true
            };
            this._laburnum.StudentFees.Add(apiStudentFee);
            this._laburnum.SaveChanges();
            return apiStudentFee.ClassId;
        }

        private long AddValidation(DTO.LABURNUM.COM.StudentFeeModel model)
        {
            model.TryValidate();
            return AddStudentFee(model);
        }

        public long Add(DTO.LABURNUM.COM.StudentFeeModel model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.StudentFeeModel model)
        {
            model.StudentFeeId.TryValidate();
            IQueryable<API.LABURNUM.COM.StudentFee> iQuery = this._laburnum.StudentFees.Where(x => x.StudentFeeId == model.StudentFeeId && x.IsActive == true);
            List<API.LABURNUM.COM.StudentFee> dbStudentFees = iQuery.ToList();
            if (dbStudentFees.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbStudentFees.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbStudentFees[0].ClassId = model.ClassId;
            dbStudentFees[0].AdmissionTypeId = model.AdmissionTypeId;
            dbStudentFees[0].StudentId = model.StudentId;
            dbStudentFees[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.StudentFeeModel model)
        {
            model.StudentFeeId.TryValidate();
            IQueryable<API.LABURNUM.COM.StudentFee> iQuery = this._laburnum.StudentFees.Where(x => x.StudentFeeId == model.StudentFeeId && x.IsActive == true);
            List<API.LABURNUM.COM.StudentFee> dbStudentFees = iQuery.ToList();
            if (dbStudentFees.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbStudentFees.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbStudentFees[0].IsActive = model.IsActive;
            dbStudentFees[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.StudentFee> GetStudentFeeByAdvanceSearch(DTO.LABURNUM.COM.StudentFeeModel model)
        {
            IQueryable<API.LABURNUM.COM.StudentFee> iQuery = null;
            //Search By Student Fee Id.
            if (iQuery != null) { if (model.StudentFeeId > 0) { iQuery = iQuery.Where(x => x.StudentFeeId == model.StudentFeeId && x.IsActive == true); } }
            else { if (model.StudentFeeId > 0) { iQuery = this._laburnum.StudentFees.Where(x => x.StudentFeeId == model.StudentFeeId && x.IsActive == true); } }
            //Search By Admission Type Id.
            if (iQuery != null) { if (model.AdmissionTypeId > 0) { iQuery = iQuery.Where(x => x.AdmissionTypeId == model.AdmissionTypeId && x.IsActive == true); } }
            else { if (model.AdmissionTypeId > 0) { iQuery = this._laburnum.StudentFees.Where(x => x.AdmissionTypeId == model.AdmissionTypeId && x.IsActive == true); } }
            //Search By Student Id.
            if (iQuery != null) { if (model.StudentId > 0) { iQuery = iQuery.Where(x => x.StudentId == model.StudentId && x.IsActive == true); } }
            else { if (model.StudentId > 0) { iQuery = this._laburnum.StudentFees.Where(x => x.StudentId == model.StudentId && x.IsActive == true); } }
            //Search By Class Id.
            if (iQuery != null) { if (model.ClassId > 0) { iQuery = iQuery.Where(x => x.ClassId == model.ClassId && x.IsActive == true); } }
            else { if (model.ClassId > 0) { iQuery = this._laburnum.StudentFees.Where(x => x.ClassId == model.ClassId && x.IsActive == true); } }



            List<API.LABURNUM.COM.StudentFee> dbStudentFee = iQuery.ToList();
            return dbStudentFee;
        }
    }
}