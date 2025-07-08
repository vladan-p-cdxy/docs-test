using Microsoft.AspNetCore.Mvc;

namespace DocumentationTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing",
            "Bracing",
            "Chilly",
            "Cool",
            "Mild",
            "Warm",
            "Balmy",
            "Hot",
            "Sweltering",
            "Scorching",
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable
                .Range(1, 5)
                .Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                })
                .ToArray();
        }

        /// <summary>
        /// Calculates the age of a person on a certain date based on the supplied date of birth.  Takes account of leap years,
        /// using the convention that someone born on 29th February in a leap year is not legally one year older until 1st March
        /// of a non-leap year.
        /// </summary>
        /// <param name="dateOfBirth">Individual's date of birth.</param>
        /// <param name="date">Date at which to evaluate age at.</param>
        /// <returns>Age of the individual in years (as an integer).</returns>
        /// <remarks>This code is not guaranteed to be correct for non-UK locales, as some countries have skipped certain dates
        /// within living memory.</remarks>
        public static int AgeAt(DateOnly dateOfBirth, DateOnly date)
        {
            int age = date.Year - dateOfBirth.Year;

            return dateOfBirth > date.AddYears(-age) ? --age : age;
        }
    }
}
