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