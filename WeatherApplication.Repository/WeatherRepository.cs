using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApplication.DataAccess.Core.Models;
using WeatherApplication.ExternalService;
using WeatherApplication.Repository.Core;
using WeatherApplication.WeatherService;

namespace WeatherApplication.Repository
{
    public class WeatherRepository : IWeatherRepository
    {
        IWeatherService weatherService = new OpenWeatherService();

        public WeatherRepository(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }
        public async Task<WeatherInfo> GetWeather(string cityId)
        {
            var response = await weatherService.GetWeather(cityId);
            WeatherInfo weather = JsonConvert.DeserializeObject<WeatherInfo>(response);
            return weather;
            //return weatherService.GetWeather(cityId);
        }

        public async Task<WeatherInfo> GetWeather(string countryName, string cityName)
        {
            var response = await weatherService.GetWeather(cityName, countryName);
            WeatherInfo weather = JsonConvert.DeserializeObject<WeatherInfo>(response);
            return weather;
            //return weatherService.GetWeather(cityName,countryName);
        }
    }
}
