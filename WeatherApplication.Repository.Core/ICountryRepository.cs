using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApplication.DataAccess.Core.Models;

namespace WeatherApplication.Repository.Core
{
    public interface ICountryRepository
    {
        Task<List<CountryInfo>> GetAllCountries();
        Task<CountryInfo> Get(string countryCode);
        Task<List<CityInfo>> GetCities(string countryCode);
    }
}
