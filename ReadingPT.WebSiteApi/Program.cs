using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ReadingPT.BusinessService;
using ReadingPT.BusinessService.Interface;
using ReadingPT.DataAccess;
using ReadingPT.WebSiteApi.Utility.SwaggerExt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DbContext, ReadingDbContext>(option=>
{
    option.UseNpgsql($"Server=127.0.0.1;Port=5432;User Id=postgres;Password=postgres; " +
                    $" Database=dbreadingpt; Pooling=False");
});//添加数据库连接

#region IOC
builder.Services.AddTransient<IBookService, BookService>();

#endregion

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
