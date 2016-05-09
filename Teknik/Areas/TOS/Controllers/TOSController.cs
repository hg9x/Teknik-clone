﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Teknik.Areas.TOS.ViewModels;
using Teknik.Controllers;

namespace Teknik.Areas.TOS.Controllers
{
    public class TOSController : DefaultController
    {
        // GET: Privacy/Privacy
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.Title = "Terms of Service - " + Config.Title;
            ViewBag.Description = "Teknik Terms of Service.";

            return View(new TOSViewModel());
        }
    }
}