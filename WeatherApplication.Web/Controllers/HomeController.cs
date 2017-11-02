using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherApplication.API.Common;

namespace WeatherApplication.Web.Controllers
{
    public class HomeController : BaseViewController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
