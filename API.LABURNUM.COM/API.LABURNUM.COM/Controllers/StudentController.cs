using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class StudentController : ApiController
    {
        public long Add(DTO.LABURNUM.COM.StudentModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FrontEndApi.StudentApi().Add(model);
            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.StudentModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.StudentApi().Update(model);
            }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.StudentModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.StudentApi().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.StudentModel> SearchStudentByAdvanceSearch(DTO.LABURNUM.COM.StudentModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new StudentHelper(new FrontEndApi.StudentApi().GetStudentByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }

        public DTO.LABURNUM.COM.StudentModel ParentStudentLogin(DTO.LABURNUM.COM.StudentModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                DTO.LABURNUM.COM.StudentModel studentmodel = new DTO.LABURNUM.COM.StudentModel();
                long studentId;
                if (model.IsStudentLogin)
                {
                    studentId = new FrontEndApi.StudentApi().IsStudentValid(model.StudentUserName, model.StudentPassword);
                }
                else
                {
                    studentId = new FrontEndApi.StudentApi().IsParentValid(model.ParentUserName, model.ParentPassword);
                }

                if (studentId > 0)
                {
                    studentmodel = new StudentHelper(new FrontEndApi.StudentApi().GetStudentByStudentId(studentId)).MapSingle();
                }
                return studentmodel;
            }
            else
            {
                return null;
            }
        }
    }
}