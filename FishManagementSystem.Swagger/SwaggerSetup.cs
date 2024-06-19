using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace FishManagementSystem.Swagger
{
    public static class SwaggerSetup
    {

        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var ApiName = "File Management System";
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(options =>
            {

                foreach (var version in typeof(ApiVersion).GetEnumNames())
                {

                    options.SwaggerDoc(version, new OpenApiInfo
                    {

                        Version = version,
                        Title = $"{ApiName} 接口文档",
                        Description = $"{ApiName} Web API {version}",
                        Contact = new OpenApiContact()
                        {
                            Name = "Ryan Yu",
                            Email = "ryayu@outlook.com",
                            Url = null
                        }

                    });

                }

                //定义JwtBearer认证方式一
                options.AddSecurityDefinition("JwtBearer", new OpenApiSecurityScheme()
                {
                    Description = "这是方式一(直接在输入框中输入认证信息，不需要在开头添加Bearer)",
                    Name = "Authorization",//jwt默认的参数名称
                    In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });


                //获取注释
                var xmlPath = Path.Combine(AppContext.BaseDirectory, $"{AppDomain.CurrentDomain.FriendlyName}.xml");

                options.IncludeXmlComments(xmlPath);

                //排序
                options.OrderActionsBy(o => o.RelativePath);
            });

        }

        public static void useSwaggerExt(this WebApplication app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(option =>
            {
                foreach (var version in typeof(ApiVersion).GetEnumNames())
                {
                    option.SwaggerEndpoint($"/swagger/{version}/swagger.json", version);

                }


            });

        }




    }
}
