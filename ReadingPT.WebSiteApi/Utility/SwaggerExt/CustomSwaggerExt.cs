using Microsoft.OpenApi.Models;

namespace ReadingPT.WebSiteApi.Utility.SwaggerExt
{
    /// <summary>
    /// Swagger版本配置及使用类
    /// </summary>
    public static class CustomSwaggerExt
    {
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(option =>
            {
                #region api版本(初始化界面中swagger标题可以根据这里面的配置来显示)
                typeof(ApiVersions).GetEnumNames().ToList().ForEach(version =>
                {
                    option.SwaggerDoc(version, new OpenApiInfo()
                    {
                        Title = $"样例读书平台Api文档1106",
                        Version = version,
                        Description = $"CoreApi版本{version}"
                    });
                });

                #endregion

                #region 支持注释
                //根据控制器的API生成的xml文件
                var file = Path.Combine(AppContext.BaseDirectory,
                    "ReadingPT.WebSiteApi.xml");
                //true:显示控制器层注释
                option.IncludeXmlComments(file, true);
                //对action的名称进行排序
                option.OrderActionsBy(o => o.RelativePath);
                #endregion

            });


        }

        public static void UseSwaggerConfig(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                #region 使用Swagger
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    //使用什么版本,在初始化Swagger界面中右上角可以选择版本
                    foreach (string version in typeof(ApiVersions).GetEnumNames())
                    {
                        c.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"样例读书平台版本{version}");
                    }
                });
                #endregion

            }
        }


    }
}
