using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherApplication.API.Common;

namespace WeatherApplication.Web.Controllers
{
    public class ErrorController : BaseViewController
    {
        // GET: Error
        public ActionResult Index()
        {
            return View();
        }
    }
}