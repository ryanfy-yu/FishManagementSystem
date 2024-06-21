using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace FishManagementSystem.Swagger
{
    public static class SwaggerSetup
    {

        public static void AddSwaggerSetup(this IServiceCollection services, string ApiName)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //var ApiName = "File Management System";
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

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "在下框中输入请求头中需要添加Jwt授权Token：Bearer Token",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme{
                                Reference = new OpenApiReference {
                                            Type = ReferenceType.SecurityScheme,
                                            Id = "Bearer"}
                           },new string[] { }
                        }
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
