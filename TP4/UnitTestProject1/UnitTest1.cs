using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApplication1.Controllers;
using Xunit;

namespace WebApplication1.Tests
{
    public class WeatherControllerTests
    {
        [Fact]
        public void GetWeatherForecasts_ReturnsOkResult()
        {
            // Arrange
            var controller = new WeatherController();

            // Act
            var result = controller.GetWeatherForecasts();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetWeatherForecast_WithValidId_ReturnsWeatherForecast()
        {
            // Arrange
            var controller = new WeatherController();
            var id = 0;

            // Act
            var result = controller.GetWeatherForecast(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var weatherForecast = Assert.IsType<WeatherForecast>(okResult.Value);
            Assert.Equal(id, weatherForecast.Id);
        }

        [Fact]
        public void GetWeatherForecast_WithInvalidId_ReturnsNotFoundResult()
        {
            // Arrange
            var controller = new WeatherController();
            var id = -1;

            // Act
            var result = controller.GetWeatherForecast(id);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
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
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetWeatherForecast", createdAtActionResult.ActionName);
        }
    }
}
