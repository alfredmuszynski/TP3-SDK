using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.Controllers;

namespace WebApplication1.Tests
{
    [TestClass]
    public class WeatherControllerTests
    {
        [TestMethod]
        public void GetWeatherForecasts_ReturnsSuccessfulResponse()
        {
            // Arrange
            var controller = new WeatherController();

            // Act
            var result = controller.GetWeatherForecasts();

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetWeatherForecast_WithInvalidId_ReturnsNotFoundResult()
        {
            // Arrange
            var controller = new WeatherController();
            var id = -1;

            // Act
            var result = controller.GetWeatherForecast(id);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void CreateWeatherForecast_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var controller = new WeatherController();
            var newForecast = new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = 30,
                Summary = "Cloudy"
            };

            // Act
            var result = controller.CreateWeatherForecast(newForecast);

            // Assert
            Assert.IsInstanceOfType(result, typeof(CreatedAtActionResult));
        }
    }
}