using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace LABURNUM.COM.Component
{
    public class Student
    {
        public List<DTO.LABURNUM.COM.StudentModel> GetStudentByAdvanceSearch(DTO.LABURNUM.COM.StudentModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Student/SearchStudentByAdvanceSearch", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.StudentModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Student List");
            }
        }

        public void UpdateStudentStatus(DTO.LABURNUM.COM.StudentModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("Student/UpdateStatus", model).Result;
                if (response.IsSuccessStatusCode)
                {
                }
                else { }
            }
            catch (Exception)
            {
                throw new Exception("Error While Updating Student Status");
            }
        }
    }
}