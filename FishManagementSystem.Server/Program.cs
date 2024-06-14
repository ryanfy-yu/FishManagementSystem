using Autofac;
using Autofac.Extensions.DependencyInjection;
using FishManagementSystem.BusinessService;
using FishManagementSystem.IBussinessService;
using FishManagementSystem.IoC;
using FishManagementSystem.Server.Utils;
using Microsoft.Extensions.Hosting;
using NLog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Log config

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


#region IoC/DI


//builder.Host.AutofacRegister();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});



#endregion



var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
