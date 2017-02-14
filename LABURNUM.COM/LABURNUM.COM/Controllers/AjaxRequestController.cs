using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LABURNUM.COM.Controllers
{
    public class AjaxRequestController : Controller
    {
        public ActionResult EditClassPopup(long id)
        {
            DTO.LABURNUM.COM.ClassModel model = new DTO.LABURNUM.COM.ClassModel();
            string html;
            try
            {
                model = new LABURNUM.COM.Component.Class().GetClassByClassId(id);
                html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/AjaxRequest/EditClassPopup.cshtml", model);
                return Json(new { code = 0, message = "success", result = html });
            }
            catch (Exception)
            {
                html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/Error404.cshtml", model);
                return Json(new { code = -1, message = "failed", result = html });
            }
        }

        public ActionResult StatusUpdateAlert(long id, bool cIsActive)
        {
            try
            {
                DTO.LABURNUM.COM.ClassModel model = new DTO.LABURNUM.COM.ClassModel() { ClassId = id, IsActive = cIsActive };
                string html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/AjaxRequest/StatusUpdateAlert.cshtml", model);
                return Json(new { code = 0, message = "success", result = html });
            }
            catch (Exception)
            {
                return Json(new { code = -1, message = "failed", result = new LABURNUM.COM.Component.Common().GetErrorView() });
            }
        }

        public ActionResult EditAdmissionTypePopup(long id)
        {
            try
            {
                DTO.LABURNUM.COM.AdmissionTypeModel model = new DTO.LABURNUM.COM.AdmissionTypeModel();
                model = new LABURNUM.COM.Component.AdmissionType().GetAdmissionTypeByAdmissionTypeId(id);
                string html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/AjaxRequest/EditAdmissionTypePopup.cshtml", model);
                return Json(new { code = 0, message = "success", result = html });
            }
            catch (Exception)
            {
                return Json(new { code = -1, message = "failed", result = new LABURNUM.COM.Component.Common().GetErrorView() });
            }
        }

        public ActionResult AdmissionTypeStatusUpdateAlert(long id, bool cIsActive)
        {
            try
            {
                DTO.LABURNUM.COM.AdmissionTypeModel model = new DTO.LABURNUM.COM.AdmissionTypeModel() { AdmissionTypeId = id, IsActive = cIsActive };
                string html = new LABURNUM.COM.Component.HtmlHelper().RenderViewToString(this.ControllerContext, "~/Views/AjaxRequest/AdmissionTypeStatusUpdateAlert.cshtml", model);
                return Json(new { code = 0, message = "success", result = html });
            }
            catch (Exception)
            {
                return Json(new { code = -1, message = "failed", result = new LABURNUM.COM.Component.Common().GetErrorView() });
            }
        }
    }
}
