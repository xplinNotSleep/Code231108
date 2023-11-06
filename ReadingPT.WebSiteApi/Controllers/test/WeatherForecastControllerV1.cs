using Microsoft.AspNetCore.Mvc;
using ReadingPT.WebSiteApi.testDemo;
using ReadingPT.WebSiteApi.Utility.SwaggerExt;

namespace ReadingPT.WebSiteApi.Controllers.test
{
    /// <summary>
    /// 项目自带天气预报控制器
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    //指定当前控制器归属哪个版本,当切换另外的版本时swagger中将不显示控制器调用方法
    [ApiExplorerSettings(IgnoreApi =false, GroupName =nameof(ApiVersions.V1))]
    public class WeatherForecastControllerV1 : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastControllerV1> _logger;

        public WeatherForecastControllerV1(ILogger<WeatherForecastControllerV1> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecastV1")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}