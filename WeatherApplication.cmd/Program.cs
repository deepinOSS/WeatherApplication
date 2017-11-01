using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApplication.WeatherService;

namespace WeatherApplication.cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetWeatherByCityId().Wait();
            GetWeatherByCityCountry().Wait();
        }
        public static async Task GetWeatherByCityId()
        {
            string cityId = "2172797";
            OpenWeatherService ows = new OpenWeatherService();
            dynamic res = await ows.GetWeather(cityId);
        }

        public static async Task GetWeatherByCityCountry()
        {
            string cityName = "London";
            string countryName = "uk";
            OpenWeatherService ows = new OpenWeatherService();
            dynamic res = await ows.GetWeather(cityName,countryName);
        }
    }
}
