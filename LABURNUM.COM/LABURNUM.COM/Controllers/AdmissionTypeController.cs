using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class AdmissionTypeController : Controller
    {
        //
        // GET: /AdmissionType/

        public ActionResult AddIndex()
        {
            DTO.LABURNUM.COM.AdmissionTypeModel model = new DTO.LABURNUM.COM.AdmissionTypeModel();
            return View(model);
        }

        public ActionResult AddAdmissionType(DTO.LABURNUM.COM.AdmissionTypeModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("AdmissionType/Add", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Json(new { code = 0, message = "success" });
                }
                else
                {
                    return Json(new { code = -1, message = "failed" });
                }
            }
            catch (Exception)
            {
                return Json(new { code = -2, message = "failed" });
            }
        }

        public ActionResult EditAdmissionType(DTO.LABURNUM.COM.AdmissionTypeModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("AdmissionType/Update", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Json(new { code = 0, message = "success" });
                }
                else
                {
                    return Json(new { code = -1, message = "failed" });
                }
            }
            catch (Exception)
            {
                return Json(new { code = -2, message = "failed" });
            }
        }

        public ActionResult StatusUpdate(DTO.LABURNUM.COM.AdmissionTypeModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("AdmissionType/UpdateStatus", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Json(new { code = 0, message = "success" });
                }
                else
                {
                    return Json(new { code = -1, message = "failed" });
                }
            }
            catch (Exception)
            {
                return Json(new { code = -2, message = "failed" });
            }
        }

        public ActionResult SearchAdmissionTypeByAdvanceSearchIndex()
        {
            DTO.LABURNUM.COM.AdmissionTypeModel model = new DTO.LABURNUM.COM.AdmissionTypeModel();
            return View(model);
        }

        public ActionResult SeachAdmissionTypeByAdvanceSearch(DTO.LABURNUM.COM.AdmissionTypeModel model)
        {
            try
            {
                List<DTO.LABURNUM.COM.AdmissionTypeModel> dbAdmissionTypeList = new LABURNUM.COM.Component.AdmissionType().GetAdmissionTypeByAdvanceSearch(model);
                string html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/AdmissionType/SearchResult.cshtml", dbAdmissionTypeList);
                return Json(new { code = 0, message = "success", result = html });
            }
            catch (Exception)
            {
                return Json(new { code = -2, message = "failed", result = new LABURNUM.COM.Component.Common().GetErrorView() });
            }
        }
    }
}
