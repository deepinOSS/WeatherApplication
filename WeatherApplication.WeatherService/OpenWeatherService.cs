using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApplication.ExternalService;

namespace WeatherApplication.WeatherService
{
    public class OpenWeatherService : IWeatherService
    {
        private Logger _logger;

        const string urifmtcityid = @"http://api.openweathermap.org/data/2.5/weather?id={0}&appid=3cd3b1e4beae9d7c9212ca7489b44a07";
        const string urifmtcitycountry = @"http://api.openweathermap.org/data/2.5/weather?q={0},{1}&appid=3cd3b1e4beae9d7c9212ca7489b44a07";
        #region Public methods
        public async Task<dynamic> GetWeather(string cityId)
        {
            //return GetWeatherImpl(cityId);
            Logger.Trace<string>("GetWeather(cityId) - METHOD START:");
            dynamic response = String.Empty;
            try
            {
                response = await GetWeatherImpl(cityId);
                Logger.Trace<string>("GetWeather(cityId) - METHOD:Got the response from OpenWeatherMap");
                Logger.Trace(response);
            }
            catch (Exception ex)
            {
                Logger.Error("GetWeather(cityId) - ERROR:" + ex.Message);
                Logger.Error(ex.StackTrace);
                if (ex.InnerException != null)
                {
                    Logger.Error("GetWeather(cityId) - INNEREXCEPTION:" + ex.Message);
                    Logger.Error(ex.InnerException.StackTrace);
                }
            }
            Logger.Trace<string>("GetWeather(cityId) - METHOD END:");
            return response;

        }

        public async Task<dynamic> GetWeather(string cityName, string countryName)
        {
            Logger.Trace<string>("GetWeather(cityName,countryName) - METHOD START:");
            dynamic response = String.Empty;
            try
            {
                response = await GetWeatherImpl(cityName, countryName);
                Logger.Trace<string>("GetWeather(cityName,countryName) - METHOD:Got the response from OpenWeatherMap");
                Logger.Trace(response);
            }
            catch (Exception ex)
            {
                Logger.Error("GetWeather(cityName,countryName) - ERROR:" + ex.Message);
                Logger.Error(ex.StackTrace);
                if (ex.InnerException != null)
                {
                    Logger.Error("GetWeather(cityName,countryName) - INNEREXCEPTION:" + ex.Message);
                    Logger.Error(ex.InnerException.StackTrace);
                }
            }
            Logger.Trace<string>("GetWeather(cityName,countryName) - METHOD END:");
            return response;         
        }
        #endregion

        #region protected methods
        protected Logger Logger
        {
            get
            {
                return (_logger ?? (_logger = NLog.LogManager.GetCurrentClassLogger()));
            }
        }
        protected Uri GetWeatherUri(string cityId)
        {
            string finaluri = string.Format(urifmtcityid, cityId);
            Uri weatherUri = new Uri(finaluri);
            return weatherUri;
        }

        protected Uri GetWeatherUri(string cityName, string countryName)
        {
            string finaluri = string.Format(urifmtcitycountry, cityName, countryName);
            Uri weatherUri = new Uri(finaluri);
            return weatherUri;
        }

        protected async Task<dynamic> GetWeatherImpl(string cityId)
        {
            HttpClient weatherClient = new HttpClient();
            Uri weatherUri = GetWeatherUri(cityId);
            weatherClient.BaseAddress = weatherUri;
            return await GetResponse(weatherClient);
        }

        protected async Task<dynamic> GetWeatherImpl(string cityName, string countryName)
        {
            HttpClient weatherClient = new HttpClient();
            Uri weatherUri = GetWeatherUri(cityName, countryName);
            weatherClient.BaseAddress = weatherUri;
            return await GetResponse(weatherClient);
        }

        protected async Task<dynamic> GetResponse(HttpClient httpclient)
        {
            string response = string.Empty;
            using (httpclient)
            {
                HttpResponseMessage weatherhttpresponsemessage = await httpclient.GetAsync(string.Empty);
                string weatherResponse = await weatherhttpresponsemessage.Content.ReadAsStringAsync();
                response = weatherResponse;
            }
            return response;
        }

        #endregion
    }
}
