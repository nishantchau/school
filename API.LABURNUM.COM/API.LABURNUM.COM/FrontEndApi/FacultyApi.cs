using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.FrontEndApi
{
    public class FacultyApi
    {
        private LaburnumEntities _laburnum;

        public FacultyApi()
        {
            this._laburnum = new LaburnumEntities();
        }

        private long AddFaculty(DTO.LABURNUM.COM.FacultyModel model)
        {
            API.LABURNUM.COM.Faculty apifaculty = new Faculty()
            {
                FacultyName = model.FacultyName,
                UserName = model.UserName,
                Password = model.Password,
                CreatedOn = System.DateTime.Now,
                IsActive = true
            };
            this._laburnum.Faculties.Add(apifaculty);
            this._laburnum.SaveChanges();
            return apifaculty.FacultyId;
        }

        private long AddValidation(DTO.LABURNUM.COM.FacultyModel model)
        {
            model.FacultyName.TryValidate();
            model.UserName.TryValidate();
            model.Password.TryValidate();
            return AddFaculty(model);
        }

        public long Add(DTO.LABURNUM.COM.FacultyModel model)
        {
            return AddValidation(model);
        }

        public void Update(DTO.LABURNUM.COM.FacultyModel model)
        {
            model.FacultyId.TryValidate();
            IQueryable<API.LABURNUM.COM.Faculty> iQuery = this._laburnum.Faculties.Where(x => x.FacultyId == model.FacultyId && x.IsActive == true);
            List<API.LABURNUM.COM.Faculty> dbFacutlies = iQuery.ToList();
            if (dbFacutlies.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbFacutlies.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbFacutlies[0].FacultyName = model.FacultyName;
            dbFacutlies[0].UserName = model.UserName;
            dbFacutlies[0].Password = model.Password;
            dbFacutlies[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public void UpdateIsActive(DTO.LABURNUM.COM.FacultyModel model)
        {
            model.FacultyId.TryValidate();
            IQueryable<API.LABURNUM.COM.Faculty> iQuery = this._laburnum.Faculties.Where(x => x.FacultyId == model.FacultyId && x.IsActive == true);
            List<API.LABURNUM.COM.Faculty> dbFacutlies = iQuery.ToList();
            if (dbFacutlies.Count == 0) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.NO_RECORD_FOUND); }
            if (dbFacutlies.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.MORE_THAN_ONE_RECORDFOUND); }
            dbFacutlies[0].IsActive = model.IsActive;
            dbFacutlies[0].LastUpdated = System.DateTime.Now;
            this._laburnum.SaveChanges();
        }

        public List<API.LABURNUM.COM.Faculty> GetActiveFaculty()
        {
            return this._laburnum.Faculties.Where(x => x.IsActive == true).ToList();
        }

        public List<API.LABURNUM.COM.Faculty> GetInActiveFaculty()
        {
            return this._laburnum.Faculties.Where(x => x.IsActive == false).ToList();
        }

        public List<API.LABURNUM.COM.Faculty> GetAllFaculties()
        {
            return this._laburnum.Faculties.ToList();
        }

        public List<API.LABURNUM.COM.Faculty> GetFacultyByAdvanceSearch(DTO.LABURNUM.COM.FacultyModel model)
        {
            IQueryable<API.LABURNUM.COM.Faculty> iQuery = null;

            //Search By Faculty Id.
            if (model.FacultyId > 0)
            {
                iQuery = this._laburnum.Faculties.Where(x => x.FacultyId == model.FacultyId && x.IsActive == true);
            }

            //Seach By Faculty Name
            if (iQuery != null)
            {
                if (model.FacultyName != null)
                {
                    iQuery = iQuery.Where(x => x.FacultyName.Trim().ToLower().Equals(model.FacultyName.Trim().ToLower()) && x.IsActive == true);
                }
            }
            else
            {
                if (model.FacultyName != null)
                {
                    iQuery = this._laburnum.Faculties.Where(x => x.FacultyName.Trim().ToLower().Equals(model.FacultyName.Trim().ToLower()) && x.IsActive == true);
                }
            }

            List<API.LABURNUM.COM.Faculty> dbFaculties = iQuery.ToList();
            return dbFaculties;
        }
    }
}