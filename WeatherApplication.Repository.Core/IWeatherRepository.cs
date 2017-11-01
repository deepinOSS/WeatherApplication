using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApplication.DataAccess.Core.Models;

namespace WeatherApplication.Repository.Core
{
    public interface IWeatherRepository
    {
        Task<WeatherInfo> GetWeather(string cityId);
        Task<WeatherInfo> GetWeather(string countryName, string cityName);
    }
}
