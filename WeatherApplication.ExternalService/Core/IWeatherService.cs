using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApplication.ExternalService
{
    public interface IWeatherService
    {
        Task<dynamic> GetWeather(string cityName, string countryName);
        Task<dynamic> GetWeather(string cityId); 
    }
}
