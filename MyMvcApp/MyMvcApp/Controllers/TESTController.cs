﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMvcApp.Controllers
{
    public class TESTController : Controller
    {
        //
        // GET: /TEST/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddTest()
        {
            return View();
        }
    }
}
