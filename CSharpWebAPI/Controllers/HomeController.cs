﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharpWebAPI.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            ViewBag.Title = "Demo";

            return View();
        }
    }
}
