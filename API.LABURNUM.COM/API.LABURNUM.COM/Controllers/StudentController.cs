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
    }
}