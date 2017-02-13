using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace LABURNUM.COM.Controllers
{
    public class SeachClassByAdvanceSearchController : Controller
    {
        //
        // GET: /SeachClassByAdvanceSearch/

        public ActionResult Index()
        {
            DTO.LABURNUM.COM.ClassModel model = new DTO.LABURNUM.COM.ClassModel();
            return View(model);
        }

        public ActionResult SeachClassByAdvanceSearch(DTO.LABURNUM.COM.ClassModel model)
        {
            try
            {
                List<DTO.LABURNUM.COM.ClassModel> dbClassList = new LABURNUM.COM.Component.Class().GetClassesByAdvanceSearch(model);
                string html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/SeachClassByAdvanceSearch/Search.cshtml", dbClassList);
                return Json(new { code = 0, message = "success", result = html });
            }
            catch (Exception)
            {
                //string html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/SeachClassByAdvanceSearch/Search.cshtml", dbClassList);
                return Json(new { code = -2, message = "failed" });
            }
        }
    }
}
