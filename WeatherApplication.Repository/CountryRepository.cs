using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApplication.DataAccess.Core.Models;
using WeatherApplication.Repository.Core;

namespace WeatherApplication.Repository
{
    public class CountryRepository : ICountryRepository
    {
        WeatherDB weatherDb = new WeatherDB();

        public CountryRepository(WeatherDB weatherDb)
        {
            this.weatherDb = weatherDb;
        }
        public async Task<CountryInfo> Get(string countryCode)
        {
            var country = await (from countryInfo in weatherDb.Countries
                          where countryInfo.iso_3166_2 == countryCode || countryInfo.country_code == countryCode
                          select
                          new CountryInfo
                          {
                              Name = countryInfo.name,
                              Code = countryInfo.country_code,
                              ISO_3166_code=countryInfo.iso_3166_2
                          }).FirstOrDefaultAsync();
            return country;
        }

        public async Task<List<CountryInfo>> GetAllCountries()
        {
            var countries = await (from countryInfo in weatherDb.Countries
                            select
                            new CountryInfo
                            {
                                Name = countryInfo.name,
                                Code = countryInfo.country_code,
                                ISO_3166_code = countryInfo.iso_3166_2,
                            }).ToListAsync();
            return countries;
        }
        public async Task<List<CityInfo>> GetCities(string countryCode)
        {
            var cities = await(from cityInfo in weatherDb.Cities
                         where cityInfo.Country == countryCode
                         select
                         new CityInfo
                         {
                             Id = cityInfo.Id.ToString(),
                             Country = cityInfo.Country,
                             Name = cityInfo.Name,
                             Latitude = cityInfo.Coord_Lat,
                             Longitude = cityInfo.Coord_Long
                         }).ToListAsync();
            return cities;

        }
    }
}
