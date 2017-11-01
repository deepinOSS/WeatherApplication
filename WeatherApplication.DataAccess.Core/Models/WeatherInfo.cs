using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApplication.DataAccess.Core.Models
{
    public class WeatherResponse
    {
        public string Code { get; set; }
        public WeatherInfo WeatherInfo { get; set; }
    }

    public class WeatherInfo
    {
        public Coord Coord { get; set; }
        public Weather[] Weather { get; set; }
        public string Base { get; set; }
        public Main Main { get; set; }
        public string Visibility { get; set; }
        public Wind Wind { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Cod { get; set; }
        public string Dt { get; set; }
    }

    public class Coord
    {
        public string Lat { get; set; }
        public string Lon{ get; set; }
    }
    public class Weather
    {
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class Main
    {
        public string Pressure { get; set; }
        public string Temp { get; set; }
    }

    public class Wind
    {
        public string Speed { get; set; }
    }
}
