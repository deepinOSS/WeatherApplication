using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WeatherApplication.API.Common
{
    public class BaseAPIController:ApiController
    {
        private Logger _logger;
        protected Logger Logger
        {
            get
            {
                return (_logger ?? (_logger = NLog.LogManager.GetCurrentClassLogger()));
            }
        }
    }
}