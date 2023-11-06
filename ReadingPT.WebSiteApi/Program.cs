using Microsoft.OpenApi.Models;
using ReadingPT.WebSiteApi.Utility.SwaggerExt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
#region Swagger的配置

builder.Services.AddSwaggerConfig();

#endregion


WebApplication app = builder.Build();

#region
//使用Swagger的配置
app.UseSwaggerConfig();

#endregion

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
