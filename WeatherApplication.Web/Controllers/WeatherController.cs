using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WeatherApplication.API.Common;
using WeatherApplication.DataAccess.Core.Models;
using WeatherApplication.ExternalService;
using WeatherApplication.Repository.Core;
using WeatherApplication.WeatherService;

namespace WeatherApplication.API.Controllers
{
    public class WeatherController : BaseAPIController
    {
        IWeatherRepository weatherRepo;

        public WeatherController(IWeatherRepository weatherRepo)
        {
            this.weatherRepo = weatherRepo;
        }

        [HttpGet]
        [Route("api/Weather/{cityId:int}")]
        public async Task<IHttpActionResult> GetWeatherByCityId(string cityId)
        {
            Logger.Trace<string>("GetWeatherByCityId - METHOD START:");
            WeatherInfo weather = null;
            try
            {
                weather = await weatherRepo.GetWeather(cityId);
                Logger.Trace<string>("GetWeatherByCityId - METHOD:Got the response from weatherrepo");
                Logger.Trace<WeatherInfo>(weather);                
            }
            catch(Exception ex)
            {
                Logger.Error("GetWeatherByCityId - ERROR:" + ex.Message);                
                Logger.Error(ex.StackTrace);
                if (ex.InnerException != null)
                {
                    Logger.Error("GetWeatherByCityId - INNEREXCEPTION:" + ex.Message);
                    Logger.Error(ex.InnerException.StackTrace);
                }

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, "Unable to Get weather information"));
            }
            Logger.Trace<string>("GetWeatherByCityId - METHOD END:");
            if (weather != null && weather.Cod == "200")
                return Ok(weather);

            else
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, "Unable to Get weather information"));
        }

        [HttpGet]
        [Route("api/Weather/{countryName}/{cityName}")]
        public async Task<IHttpActionResult> GetWeatherByCountryCity(string countryName, string cityName)
        {
            Logger.Trace<string>("GetWeatherByCountryCity - METHOD START:");
            WeatherInfo weather = null;
            try
            {
                weather = await weatherRepo.GetWeather(countryName,cityName);
                Logger.Trace<string>("GetWeatherByCountryCity - METHOD:Got the response from weatherrepo");
                Logger.Trace<WeatherInfo>(weather);           
            }
            catch (Exception ex)
            {
                Logger.Error("GetWeatherByCountryCity - ERROR:" + ex.Message);
                Logger.Error(ex.StackTrace);
                if (ex.InnerException != null)
                {
                    Logger.Error("GetWeatherByCountryCity - INNEREXCEPTION:" + ex.Message);
                    Logger.Error(ex.InnerException.StackTrace);
                }

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, "Unable to Get weather information"));
            }
            Logger.Trace<string>("GetWeatherByCountryCity - METHOD END:");
            if (weather!= null && weather.Cod == "200")
                return Ok(weather);
            else
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, "Unable to Get weather information"));
        }
    }
}