using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using WeatherApplication.ExternalService;
using WeatherApplication.Repository;
using WeatherApplication.Repository.Core;
using WeatherApplication.WeatherService;

namespace WeatherApplication.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IWeatherService, OpenWeatherService>(new HierarchicalLifetimeManager());
            container.RegisterType<IWeatherRepository, WeatherRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICountryRepository, CountryRepository>(new HierarchicalLifetimeManager());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}