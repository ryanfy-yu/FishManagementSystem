using Autofac;
using Autofac.Extensions.DependencyInjection;
using FishManagementSystem.BusinessService;
using FishManagementSystem.IBussinessService;
using FishManagementSystem.IoC;
using FishManagementSystem.Mapping;
using FishManagementSystem.Server.Utils;
using FishManagementSystem.Swagger;
using Microsoft.Extensions.Hosting;
using NLog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerSetup();

builder.Services.AddControllers().AddNewtonsoftJson(option =>
{
    //时间统一格式
    option.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm";
});


#region 注册 AutoMapper

builder.Services.AddAutoMapper(typeof(AutoMaperConfigProfile));

#endregion


#region 日志配置

string logName = builder.Configuration["LoggingConfigs:Name"];
string LogConfigFile = builder.Configuration["LoggingConfigs:ConfigFile"];

if (logName == "nlog")
{
    builder.Logging.AddNLog(LogConfigFile);
}
else
{
    builder.Logging.AddLog4Net(LogConfigFile);
}

#endregion


#region IoC/DI 配置




//builder.Host.AutofacRegister();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(o =>
{
    o.RegisterModule(new AutofacBusinessModule(builder.Configuration));
});



#endregion


#region 跨域

builder.Services.AddCors(options =>
{
    options.AddPolicy("allcors", o =>
    {
        o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

    });

});

#endregion


#region JWT


#endregion


var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
    app.useSwaggerExt();
}

app.UseHttpsRedirection();


//app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.UseCors("allcors");


app.Run();
