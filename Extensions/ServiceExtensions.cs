using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Repository;

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
public static void ConfigureRepositoryManager(this IServiceCollection services) =>
 services.AddScoped<IRepositoryManager, RepositoryManager>();

    }
}