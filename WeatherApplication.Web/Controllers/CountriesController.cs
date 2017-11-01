using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WeatherApplication.API.Common;
using WeatherApplication.DataAccess.Core.Models;
using WeatherApplication.Repository.Core;

namespace WeatherApplication.API.Controllers
{
    public class CountriesController : BaseAPIController
    {
        ICountryRepository countryRepo;

        public CountriesController(ICountryRepository countryRepo)
        {
            this.countryRepo = countryRepo;
        }

        [HttpGet]
        [Route("api/countries")]
        public async Task<IHttpActionResult> GetAllCountries()
        {
            Logger.Trace<string>("GetAllCountries - METHOD START:");
            List<CountryInfo> countries = null;
            try
            {
                countries = await countryRepo.GetAllCountries();
                Logger.Trace<string>("GetAllCountries - METHOD:Got the response from countryRepo");
                Logger.Trace<List<CountryInfo>>(countries);
            }
            catch (Exception ex)
            {
                Logger.Error("GetAllCountries - ERROR:" + ex.Message);
                Logger.Error(ex.StackTrace);
                if (ex.InnerException != null)
                {
                    Logger.Error("GetAllCountries - INNEREXCEPTION:" + ex.Message);
                    Logger.Error(ex.InnerException.StackTrace);
                }

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, "Unable to Get Countries"));
            }
            Logger.Trace<string>("GetAllCountries - METHOD END:");
            return Ok(countries);       
        }

        [HttpGet]
        [Route("api/countries/{countryCode}")]
        public async Task<IHttpActionResult> Get(string countryCode)
        {
            Logger.Trace<string>("Get - METHOD START:");
            CountryInfo country = null;
            try
            {
                country = await countryRepo.Get(countryCode);
                Logger.Trace<string>("Get - METHOD:Got the response from countryRepo");
                Logger.Trace<CountryInfo>(country);
            }
            catch (Exception ex)
            {
                Logger.Error("GetCities - ERROR:" + ex.Message);
                Logger.Error(ex.StackTrace);
                if (ex.InnerException != null)
                {
                    Logger.Error("GetCities - INNEREXCEPTION:" + ex.Message);
                    Logger.Error(ex.InnerException.StackTrace);
                }

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, "Unable to Get country information"));
            }
            Logger.Trace<string>("Get - METHOD END:");
            return Ok(country);
        }

        [HttpGet]
        [Route("api/countries/{countryCode}/cities")]
        public async Task<IHttpActionResult> GetCities(string countryCode)
        {
            Logger.Trace<string>("GetCities - METHOD START:");
            List<CityInfo> cities = null;
            try
            {
                cities = await countryRepo.GetCities(countryCode);
                Logger.Trace<string>("GetCities - METHOD:Got the response from countryRepo");
                Logger.Trace<List<CityInfo>>(cities);
            }
            catch (Exception ex)
            {
                Logger.Error("GetCities - ERROR:" + ex.Message);
                Logger.Error(ex.StackTrace);
                if (ex.InnerException != null)
                {
                    Logger.Error("GetCities - INNEREXCEPTION:" + ex.Message);
                    Logger.Error(ex.InnerException.StackTrace);
                }

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.InternalServerError, "Unable to Get cities"));
            }
            Logger.Trace<string>("GetCities - METHOD END:");
            return Ok(cities);
        }
    }
}