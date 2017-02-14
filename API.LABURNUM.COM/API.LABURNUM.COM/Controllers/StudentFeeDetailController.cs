﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class StudentFeeDetailController : ApiController
    {
        public long Add(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new FrontEndApi.StudentFeeDetailApi().Add(model);
            }
            else
            {
                return -1;
            }
        }

        public void Update(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.StudentFeeDetailApi().Update(model);
            }
        }

        public void UpdateStatus(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                new FrontEndApi.StudentFeeDetailApi().UpdateIsActive(model);
            }
        }

        public List<DTO.LABURNUM.COM.StudentFeeDetailModel> SearchStudentByAdvanceSearch(DTO.LABURNUM.COM.StudentFeeDetailModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return new StudentFeeDetailHelper(new FrontEndApi.StudentFeeDetailApi().GetStudentFeeDetailByAdvanceSearch(model)).Map();
            }
            else { return null; }
        }
    }
}