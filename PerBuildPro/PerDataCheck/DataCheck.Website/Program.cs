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
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "���˴���ʼ�ƽ̨1108", Version = "v23.11.08" });
    //var xmlPath = Path.Combine(AppContext.BaseDirectory, typeof(Startup).Assembly.GetName().Name + ".xml");
    var xmlPath = Path.Combine(AppContext.BaseDirectory, "DataCheck.Website.xml");
    if (!File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath, true);
        //throw new FileNotFoundException("�����������ļ���" + xmlPath);
    }
    c.IncludeXmlComments(xmlPath);
});
services.AddControllersWithViews();
services.AddCors(options =>
{
    options.AddPolicy("AllowCorsOrigin", builder =>
    {
        //�����������
        builder
         .AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader()
         .SetPreflightMaxAge(TimeSpan.FromSeconds(2000000));
    });
});

#region  ����ȫ������ע��
services.AddHttpClient();
#endregion

//������ı�����
services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

services.AddMemoryCache();//����MemoryCache
                          // session ����
services.AddSession(options =>
{
    // ���� Session ����ʱ��
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
        //ʹ��ʲô�汾,�ڳ�ʼ��Swagger���������Ͻǿ���ѡ��汾
        c.SwaggerEndpoint($"/swagger/v23.11.08/swagger.json", $"����ƽ̨�汾v23.11.08");
        
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
