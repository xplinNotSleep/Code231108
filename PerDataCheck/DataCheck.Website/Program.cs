using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text;
using DataCheck.Website.Utility;

var builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;

// Add services to the container.
builder.Services.AddControllers();

// If using Kestrel:
services.Configure<KestrelServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
    options.Limits.MaxRequestBodySize = 1242880000;
});


builder.Services.AddControllers().AddJsonOptions(op => {
    op.JsonSerializerOptions.PropertyNamingPolicy = null;
    op.JsonSerializerOptions.Converters.Add(new DateTimeConverterClass());
    op.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
});

services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "个人搭建的质检平台1108", Version = "v23.11.08" });
    //var xmlPath = Path.Combine(AppContext.BaseDirectory, typeof(Startup).Assembly.GetName().Name + ".xml");
    var xmlPath = Path.Combine(AppContext.BaseDirectory, "DataCheck.Website.xml");
    if (!File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath, true);
        //throw new FileNotFoundException("请生成配置文件：" + xmlPath);
    }
    c.IncludeXmlComments(xmlPath);
});
services.AddControllersWithViews();
services.AddCors(options =>
{
    options.AddPolicy("AllowCorsOrigin", builder =>
    {
        //开放任意访问
        builder
         .AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader()
         .SetPreflightMaxAge(TimeSpan.FromSeconds(2000000));
    });
});

#region  增加全局配置注入
services.AddHttpClient();
#endregion

//解决中文被编码
services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

services.AddMemoryCache();//启用MemoryCache
                          // session 设置
services.AddSession(options =>
{
    // 设置 Session 过期时间
    options.IdleTimeout = TimeSpan.FromHours(3);
    options.Cookie.HttpOnly = true;
});

services.Configure<KestrelServerOptions>(x => x.AllowSynchronousIO = true)
    .Configure<IISServerOptions>(x => x.AllowSynchronousIO = true);

//services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());
//var provider = services.BuildDefaultServiceProvider();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        //使用什么版本,在初始化Swagger界面中右上角可以选择版本
        c.SwaggerEndpoint($"/swagger/v23.11.08/swagger.json", $"样例平台版本v23.11.08");
        
    });
}

app.UseRouting();
app.UseAuthorization();
app.UseCors("AllowCorsOrigin");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.UseStaticFiles();

app.Run();
