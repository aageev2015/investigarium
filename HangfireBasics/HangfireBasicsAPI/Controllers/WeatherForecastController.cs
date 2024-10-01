using Hangfire;
using HangfireBasicsServiceContract;
using Microsoft.AspNetCore.Mvc;

namespace HangfireBasics.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(
        ILogger<WeatherForecastController> logger,
        IBackgroundJobClient backgroundJobClient
        ) : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger = logger;
        private readonly IBackgroundJobClient _backgroundJobClient = backgroundJobClient;

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var clientTicks = DateTime.Now.Ticks;
            Console.WriteLine($"{clientTicks}. {Thread.CurrentThread.ManagedThreadId}. Invoked  {nameof(WeatherForecastController)}.{nameof(Get)}");

            var job1 = _backgroundJobClient.Schedule(
                    (IHangfireBasicsService service) => service.DoSomeWeatherJob()
                , new DateTimeOffset(DateTime.UtcNow.AddSeconds(2))
            );
            _backgroundJobClient.ContinueJobWith(job1, () => Console.WriteLine("After Previous job finished"));

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("recurring", Name = "GetWeatherForecastRecurring")]
        public IResult GetRecurring()
        {
            RecurringJob.AddOrUpdate("GetWeatherForecastRecurringJob",
                (IHangfireBasicsService service) => service.DoSomethingRecurringJob(), "* * * * *");
            return Results.Ok();
        }
    }
}
