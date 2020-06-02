using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Na.TodoList.Domain.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Na.TodoList.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("[action]")]
        public SimpleObject GetSimpleObject()
        {
            return new SimpleObject
            {
                Id = 1,
                URL = "http://simple-form-bootstrap.plataformatec.com.br/documentation",
                FieldId = "user_name",
                ValueToInject = "2847394738245",
                RequestTime = DateTime.Now
            };
        }
    }
}
