using Microsoft.OpenApi.Models;
using ReadingPT.WebSiteApi.Utility.SwaggerExt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
#region Swagger������

builder.Services.AddSwaggerConfig();

#endregion


WebApplication app = builder.Build();

#region
//ʹ��Swagger������
app.UseSwaggerConfig();

#endregion

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
