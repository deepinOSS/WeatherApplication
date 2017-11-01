using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherApplication.API.Controllers;
using WeatherApplication.Repository.Core;
using Moq;
using System.Net.Http;
using System.Web.Http;
using WeatherApplication.DataAccess.Core.Models;
using System.Web.Http.Results;
using System.Threading.Tasks;

namespace WeatherApplication.APITests
{
    [TestClass]
    public class WeatherTest
    {
        [TestMethod]
        public async Task TestGetWeatherByIdExists()
        {
            // Arrange
            var mockRepository = new Mock<IWeatherRepository>();
            mockRepository.Setup(x => x.GetWeather("1163626"))
                .Returns(Task.FromResult<WeatherInfo>(new WeatherInfo { Cod = "200" }));
            var controller = new WeatherController(mockRepository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            IHttpActionResult actionResult = await controller.GetWeatherByCityId("1163626");
            var contentResult = actionResult as OkNegotiatedContentResult<WeatherInfo>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual("200", contentResult.Content.Cod);
        }

        [TestMethod]
        public async Task TestGetWeatherByIdNotExists()
        {
            // Arrange
            var mockRepository = new Mock<IWeatherRepository>();
            mockRepository.Setup(x => x.GetWeather("1163"))
                .Returns(Task.FromResult<WeatherInfo>(new WeatherInfo { Cod = "404" }));
            var controller = new WeatherController(mockRepository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            IHttpActionResult actionResult = await controller.GetWeatherByCityId("1163626");
            var contentResult = actionResult as ResponseMessageResult;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Response);
            Assert.AreEqual(System.Net.HttpStatusCode.NotFound, contentResult.Response.StatusCode);
        }

        [TestMethod]
        public async Task TestGetWeatherByIdThrowsEx()
        {
            // Arrange
            var mockRepository = new Mock<IWeatherRepository>();
            mockRepository.Setup(x => x.GetWeather("1163")).ThrowsAsync(new Exception());
               
            var controller = new WeatherController(mockRepository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            IHttpActionResult actionResult = await controller.GetWeatherByCityId("1163626");
            var contentResult = actionResult as ResponseMessageResult;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Response);
            Assert.AreEqual(System.Net.HttpStatusCode.NotFound, contentResult.Response.StatusCode);
        }
    }
}
