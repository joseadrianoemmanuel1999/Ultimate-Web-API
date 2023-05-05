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
global using global::System.Net.Http;
global using global::System.Net.Http.Json;
global using global::System.Threading;
global using global::System.Threading.Tasks;
using Microsoft.AspNetCore.HttpOverrides;
using Utimate_Web_API.Extensions;
using NLog;

var builder = WebApplication.CreateBuilder(args);
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), 
"/nlog.config"));
builder.Services.ConfigureRepositoryManager();
// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.ConfigurationIISIntegration();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
app.UseDeveloperExceptionPage();
else
app.UseHsts();

if (app.Environment.IsDevelopment())
{
    
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
ForwardedHeaders = ForwardedHeaders.All
});
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.Use(async (context, next) =>
{
 Console.WriteLine($"Logic before executing the next delegate in the Use method");
 await next.Invoke();
 Console.WriteLine($"Logic after executing the next delegate in the Use method");
});

app.Map("/usingmapbranch", builder =>
{
 builder.Use(async (context, next) =>
 {
 Console.WriteLine("Map branch logic in the Use method before the next delegate");
 await next.Invoke();
 Console.WriteLine("Map branch logic in the Use method after the nextdelegate");
 });
 builder.Run(async context =>
 {
 Console.WriteLine($"Map branch response to the client in the Run method");
 await context.Response.WriteAsync("Hello from the map branch.");
 });

});
app.MapWhen(context => context.Request.Query.ContainsKey("testquerystring"), builder 
=>
{
 builder.Run(async context =>
 {
 await context.Response.WriteAsync("Hello from the MapWhen branch.");
 
 });
});


app.Run(async context =>
{
 Console.WriteLine($"Writing the response to the client in the Run method");
 await context.Response.WriteAsync("Hello from the middleware component.");
});
 

app.MapControllers();

app.Run();
