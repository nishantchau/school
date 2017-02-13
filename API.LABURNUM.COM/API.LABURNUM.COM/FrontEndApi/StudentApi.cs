﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class StudentApi
    {
        private LaburnumEntities _laburnum;

        public StudentApi()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddStudent(DTO.LABURNUM.COM.StudentModel model)
        {
            API.LABURNUM.COM.Student apiStudent = new Student()
            {
                ClassId = model.ClassId,
                ClassStartWithId = model.ClassStartWithId,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                SalutationId = model.SalutationId,
                EmailId = model.EmailId,
                Mobile = model.Mobile,
                Address = model.Address,
                DOB = model.DOB,
                Landline = model.Landline,
                FatherName = model.FatherName,
                FatherMobile = model.FatherMobile,
                FatherProfession = model.FatherProfession,
                MotherName = model.MotherName,
                MotherMobile = model.MotherMobile,
                MotherProfession = model.MotherProfession,
                FatherAadharNumber = model.FatherAadharNumber,
                MotherAadharNumber = model.MotherAadharNumber,
                PAN = model.PAN,
                StudentAadharNumber = model.StudentAadharNumber,
                SectionId = model.SectionId,
                BusRouteNumber = model.BusRouteNumber,
                CreatedOn = System.DateTime.Now,
                IsActive = true
            };
            this._laburnum.Students.Add(apiStudent);
            this._laburnum.SaveChanges();
            return apiStudent.ClassId;
        }

        private long AddValidation(DTO.LABURNUM.COM.StudentModel model)
        {
            model.TryValidate();
            return AddStudent(model);
        }

        public long Add(DTO.LABURNUM.COM.StudentModel model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.StudentModel model)
        {
            model.StudentId.TryValidate();
            IQueryable<API.LABURNUM.COM.Student> iQuery = this._laburnum.Students.Where(x => x.StudentId == model.StudentId && x.IsActive == true);
            List<API.LABURNUM.COM.Student> dbStudents = iQuery.ToList();
            if (dbStudents.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbStudents.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbStudents[0].ClassId = model.ClassId;
            dbStudents[0].ClassStartWithId = model.ClassStartWithId;
            dbStudents[0].FirstName = model.FirstName;
            dbStudents[0].MiddleName = model.MiddleName;
            dbStudents[0].LastName = model.LastName;
            dbStudents[0].SalutationId = model.SalutationId;
            dbStudents[0].EmailId = model.EmailId;
            dbStudents[0].Mobile = model.Mobile;
            dbStudents[0].Address = model.Address;
            dbStudents[0].DOB = model.DOB;
            dbStudents[0].Landline = model.Landline;
            dbStudents[0].FatherName = model.FatherName;
            dbStudents[0].FatherMobile = model.FatherMobile;
            dbStudents[0].FatherProfession = model.FatherProfession;
            dbStudents[0].MotherName = model.MotherName;
            dbStudents[0].MotherMobile = model.MotherMobile;
            dbStudents[0].MotherProfession = model.MotherProfession;
            dbStudents[0].FatherAadharNumber = model.FatherAadharNumber;
            dbStudents[0].MotherAadharNumber = model.MotherAadharNumber;
            dbStudents[0].PAN = model.PAN;
            dbStudents[0].SectionId = model.SectionId;
            dbStudents[0].BusRouteNumber = model.BusRouteNumber;
            dbStudents[0].StudentAadharNumber = model.StudentAadharNumber;
            dbStudents[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.StudentModel model)
        {
            model.StudentId.TryValidate();
            IQueryable<API.LABURNUM.COM.Student> iQuery = this._laburnum.Students.Where(x => x.StudentId == model.StudentId && x.IsActive == true);
            List<API.LABURNUM.COM.Student> dbStudents = iQuery.ToList();
            if (dbStudents.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbStudents.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbStudents[0].IsActive = model.IsActive;
            dbStudents[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.Student> GetStudentByAdvanceSearch(DTO.LABURNUM.COM.StudentModel model)
        {
            IQueryable<API.LABURNUM.COM.Student> iQuery = null;
            //Search By Student Id.
            if (iQuery != null) { if (model.StudentId > 0) { iQuery = iQuery.Where(x => x.StudentId == model.StudentId && x.IsActive == true); } }
            else { if (model.StudentId > 0) { iQuery = this._laburnum.Students.Where(x => x.StudentId == model.StudentId && x.IsActive == true); } }
            //Search By ClassId.
            if (iQuery != null) { if (model.ClassId > 0) { iQuery = iQuery.Where(x => x.ClassId == model.ClassId && x.IsActive == true); } }
            else { if (model.ClassId > 0) { iQuery = this._laburnum.Students.Where(x => x.ClassId == model.ClassId && x.IsActive == true); } }
            //Search By Class Start With Id.
            if (iQuery != null) { if (model.ClassStartWithId > 0) { iQuery = iQuery.Where(x => x.ClassStartWithId == model.ClassStartWithId && x.IsActive == true); } }
            else { if (model.ClassStartWithId > 0) { iQuery = this._laburnum.Students.Where(x => x.ClassStartWithId == model.ClassStartWithId && x.IsActive == true); } }
            //Search By FirstName.
            if (iQuery != null) { if (model.FirstName != null) { iQuery = iQuery.Where(x => x.FirstName.Trim().ToLower().Contains(model.FirstName.Trim().ToLower()) && x.IsActive == true); } }
            else { if (model.FirstName != null) { iQuery = this._laburnum.Students.Where(x => x.FirstName.Trim().ToLower().Contains(model.FirstName.Trim().ToLower()) && x.IsActive == true); } }
            //Search By MiddleName.
            if (iQuery != null) { if (model.MiddleName != null) { iQuery = iQuery.Where(x => x.MiddleName.Trim().ToLower().Contains(model.MiddleName.Trim().ToLower()) && x.IsActive == true); } }
            else { if (model.MiddleName != null) { iQuery = this._laburnum.Students.Where(x => x.MiddleName.Trim().ToLower().Contains(model.MiddleName.Trim().ToLower()) && x.IsActive == true); } }
            //Search By LastName.
            if (iQuery != null) { if (model.LastName != null) { iQuery = iQuery.Where(x => x.LastName.Trim().ToLower().Contains(model.LastName.Trim().ToLower()) && x.IsActive == true); } }
            else { if (model.LastName != null) { iQuery = this._laburnum.Students.Where(x => x.LastName.Trim().ToLower().Contains(model.LastName.Trim().ToLower()) && x.IsActive == true); } }
            //Search By SalutationId.
            if (iQuery != null) { if (model.SalutationId > 0) { iQuery = iQuery.Where(x => x.SalutationId == model.SalutationId && x.IsActive == true); } }
            else { if (model.SalutationId > 0) { iQuery = this._laburnum.Students.Where(x => x.SalutationId == model.SalutationId && x.IsActive == true); } }
            //Search By EmailId.
            if (iQuery != null) { if (model.EmailId != null) { iQuery = iQuery.Where(x => x.EmailId.Trim().Equals(model.EmailId.Trim()) && x.IsActive == true); } }
            else { if (model.EmailId != null) { iQuery = this._laburnum.Students.Where(x => x.EmailId.Trim().Equals(model.EmailId.Trim()) && x.IsActive == true); } }
            //Search By Mobile.
            if (iQuery != null) { if (model.Mobile != null) { iQuery = iQuery.Where(x => x.Mobile.Trim().Equals(model.Mobile.Trim()) && x.IsActive == true); } }
            else { if (model.Mobile != null) { iQuery = this._laburnum.Students.Where(x => x.Mobile.Trim().Equals(model.Mobile.Trim()) && x.IsActive == true); } }
            //Search By FatherName.
            if (iQuery != null) { if (model.FatherName != null) { iQuery = iQuery.Where(x => x.FatherName.Trim().ToLower().Contains(model.FatherName.Trim().ToLower()) && x.IsActive == true); } }
            else { if (model.FatherName != null) { iQuery = this._laburnum.Students.Where(x => x.FatherName.Trim().ToLower().Contains(model.FatherName.Trim().ToLower()) && x.IsActive == true); } }
            //Search By MotherName.
            if (iQuery != null) { if (model.MotherName != null) { iQuery = iQuery.Where(x => x.MotherName.Trim().ToLower().Contains(model.MotherName.Trim().ToLower()) && x.IsActive == true); } }
            else { if (model.MotherName != null) { iQuery = this._laburnum.Students.Where(x => x.MotherName.Trim().ToLower().Contains(model.MotherName.Trim().ToLower()) && x.IsActive == true); } }
            //Search By PAN.
            if (iQuery != null) { if (model.PAN != null) { iQuery = iQuery.Where(x => x.PAN.Equals(model.PAN) && x.IsActive == true); } }
            else { if (model.PAN != null) { iQuery = this._laburnum.Students.Where(x => x.PAN.Equals(model.PAN) && x.IsActive == true); } }
            //Search By FatherAadharNumber.
            if (iQuery != null) { if (model.FatherAadharNumber != null) { iQuery = iQuery.Where(x => x.FatherAadharNumber == x.FatherAadharNumber && x.IsActive == true); } }
            else { if (model.FatherAadharNumber != null) { iQuery = this._laburnum.Students.Where(x => x.FatherAadharNumber == x.FatherAadharNumber && x.IsActive == true); } }
            //Search By MotherAadharNumber.
            if (iQuery != null) { if (model.MotherAadharNumber != null) { iQuery = iQuery.Where(x => x.MotherAadharNumber == x.MotherAadharNumber && x.IsActive == true); } }
            else { if (model.MotherAadharNumber != null) { iQuery = this._laburnum.Students.Where(x => x.MotherAadharNumber == x.MotherAadharNumber && x.IsActive == true); } }
            //Search By StudentAadharNumber.
            if (iQuery != null) { if (model.StudentAadharNumber != null) { iQuery = iQuery.Where(x => x.StudentAadharNumber == x.StudentAadharNumber && x.IsActive == true); } }
            else { if (model.StudentAadharNumber != null) { iQuery = this._laburnum.Students.Where(x => x.StudentAadharNumber == x.StudentAadharNumber && x.IsActive == true); } }
            //Search By Bus Route No.
            if (iQuery != null) { if (model.BusRouteNumber != null) { iQuery = iQuery.Where(x => x.BusRouteNumber == x.BusRouteNumber && x.IsActive == true); } }
            else { if (model.BusRouteNumber != null) { iQuery = this._laburnum.Students.Where(x => x.BusRouteNumber == x.BusRouteNumber && x.IsActive == true); } }
            //Search By SectionId.
            if (iQuery != null) { if (model.SectionId != null) { iQuery = iQuery.Where(x => x.SectionId == x.SectionId && x.IsActive == true); } }
            else { if (model.SectionId != null) { iQuery = this._laburnum.Students.Where(x => x.SectionId == x.SectionId && x.IsActive == true); } }
            
            List<API.LABURNUM.COM.Student> dbStudents = iQuery.ToList();
            return dbStudents;
        }
    }
}