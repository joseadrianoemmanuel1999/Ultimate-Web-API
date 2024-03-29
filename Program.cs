global using global::Microsoft.AspNetCore.Builder;
global using global::Microsoft.AspNetCore.Hosting;
global using global::Microsoft.AspNetCore.Http;
global using global::Microsoft.AspNetCore.Routing;
global using global::Microsoft.Extensions.Configuration;
global using global::Microsoft.Extensions.DependencyInjection;
global using global::Microsoft.Extensions.Hosting;
global using global::Microsoft.Extensions.Logging;
global using global::System;
global using global::System.Collections.Generic;
global using global::System.IO;
global using global::System.Linq;
global using global::System.Net.Http.Json;
global using global::System.Threading;
global using global::System.Threading.Tasks;
using Microsoft.AspNetCore.HttpOverrides;
using Utimate_Web_API.Extensions;
using NLog;
using CompanyEmployees.Presentation;
using Service; 
using Service.Contracts;
using Contratcs;
using Entities.ErrorModel;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;
using Utimate_Web_API.ActionFilters;
using Contracts;
using Shared.DataTransferObjects;
using Utimate_Web_API.Utility;

var builder = WebApplication.CreateBuilder(args);
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),"/nlog.config"));

builder.Services.ConfigureSqlContext(builder.Configuration);
// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.ConfigurationIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<ValidationFilterAttribute>();
 builder.Services.AddControllers(config => { 
 config.RespectBrowserAcceptHeader = true;
 config.ReturnHttpNotAcceptable = true; 
 
 config.InputFormatters.Insert(0, GetJsonPatchInputFormatter());

}).AddXmlDataContractSerializerFormatters()
 .AddCustomCSVFormatter()
 .AddApplicationPart(typeof(CompanyEmployees.Presentation.AssemblyReference).Assembly);
 builder.Services.Configure<ApiBehaviorOptions>(options =>
{
options.SuppressModelStateInvalidFilter = true;
});


NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter() =>
new ServiceCollection().AddLogging().AddMvc().AddNewtonsoftJson()
.Services.BuildServiceProvider()
.GetRequiredService<IOptions<MvcOptions>>().Value.InputFormatters
.OfType<NewtonsoftJsonPatchInputFormatter>().First();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDataShaper<EmployeeDto>, DataShaper<EmployeeDto>>();
builder.Services.AddCustomMediaTypes();
builder.Services.AddScoped<IEmployeeLinks, EmployeeLinks>();
builder.Services.AddScoped<ValidateMediaTypeAttribute>();


var app = builder.Build();

// Configure the HTTP request pipeline.

var logger = app.Services.GetRequiredService<ILoggerManager>(); 
app.ConfigureExceptionHandler(logger); 
 
if (app.Environment.IsProduction()) 
 app.UseHsts();
if (app.Environment.IsDevelopment())
{
    
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
 
app.UseCors("CorsPolicy");

app.UseAuthorization();



app.MapControllers();

app.Run();
