using Microsoft.AspNetCore.Mvc;
using ReadingPT.WebSiteApi.testDemo;
using ReadingPT.WebSiteApi.Utility.SwaggerExt;

namespace ReadingPT.WebSiteApi.Controllers.test
{
    /// <summary>
    /// ��Ŀ�Դ�����Ԥ��������
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    //ָ����ǰ�����������ĸ��汾,���л�����İ汾ʱswagger�н�����ʾ���������÷���
    [ApiExplorerSettings(IgnoreApi =false, GroupName =nameof(ApiVersions.V2))]
    public class WeatherForecastControllerV2 : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastControllerV2> _logger;

        public WeatherForecastControllerV2(ILogger<WeatherForecastControllerV2> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecastV2")]
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