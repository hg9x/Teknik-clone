﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Teknik.Controllers;

namespace Teknik.Areas.Dev.Controllers
{
    public class DevController : DefaultController
    {
        [AllowAnonymous]
        // GET: Dev
        public ActionResult Index()
        {
            return Redirect(Url.SubRouteUrl("www", "Home.Index"));
        }
    }
}