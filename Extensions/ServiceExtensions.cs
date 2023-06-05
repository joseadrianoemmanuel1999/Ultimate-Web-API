using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service;
using Service.Contracts;
using LoggerService;
using Contratcs;

namespace Utimate_Web_API.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureCors(this  IServiceCollection services)
        => services.AddCors(options=>
        {
            options.AddPolicy("CorsPolicy",builder =>
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
        });
        public static void ConfigurationIISIntegration(this IServiceCollection services )
        => services.Configure<IISOptions>(options =>
        {

        });
 public static void ConfigureServiceManager(this IServiceCollection services)
 =>services.AddScoped<IServiceManager,ServiceManager>();
public static void ConfigureRepositoryManager(this IServiceCollection services) =>
 services.AddScoped<IRepositoryManager, RepositoryManager>();
 public static void ConfigureLoggerService(this IServiceCollection services) => 
    services.AddSingleton<ILoggerManager, LoggerManager>();

 public static void ConfigureSqlContext(this IServiceCollection services, 
IConfiguration configuration) => 
 services.AddDbContext<RepositoryContext>(opts => 
  opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
  public static IMvcBuilder AddCustomCSVFormatter(this IMvcBuilder builder) =>         
    builder.AddMvcOptions(config => config.OutputFormatters.Add(new 
CsvOutputFormatter()));

    }
}