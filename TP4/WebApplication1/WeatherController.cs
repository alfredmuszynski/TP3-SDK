using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private static readonly List<WeatherForecast> _weatherForecasts = new List<WeatherForecast>
        {
            new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = 25,
                Summary = "Sunny"
            },
            // Add more initial data as needed
        };

        // GET API (weather)
        [HttpGet]
        public ActionResult<IEnumerable<WeatherForecast>> GetWeatherForecasts()
        {
            return _weatherForecasts;
        }

        // GET API 2 (id)
        [HttpGet("{id}")]
        public ActionResult<WeatherForecast> GetWeatherForecast(int id)
        {
            if (id >= 0 && id < _weatherForecasts.Count)
            {
                return _weatherForecasts[id];
            }
            else
            {
                return NotFound();
            }
        }

        // POST API
        [HttpPost]
        public IActionResult CreateWeatherForecast([FromBody] WeatherForecast newForecast)
        {
            _weatherForecasts.Add(newForecast);
            return CreatedAtAction(nameof(GetWeatherForecast), new { id = _weatherForecasts.Count - 1 }, newForecast);
        }
    }
}

