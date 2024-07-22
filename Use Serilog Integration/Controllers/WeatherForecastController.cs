using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Use_Serilog_Integration.Controllers
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

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            try
            {
                _logger.LogInformation("weather forcast processing has started");
                Log.Information("weather forcast processing has started");

                var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray();

              //  throw new Exception("test logs");

                _logger.LogInformation("The results are  {@result}", result); //return one record of json 
                Log.Information("The results are  {@result}", result);

                return result;
            }
            catch (Exception e)
            {
                Log.Error(e, "unable to get forecast"); //show stack trace
                throw;
            }
        }
    }
}
