using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Contratcs;
using Entities.ErrorModel;
using Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Utimate_Web_API.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
         public static void ConfigureExceptionHandler(this WebApplication app, 
ILoggerManager logger) 
    { 
        app.UseExceptionHandler(appError => 
        { 
            appError.Run(async context => 
            { 
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; 
                context.Response.ContentType = "application/json"; 
 
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>(); 
                if (contextFeature != null) 
                { 
                    context.Response.StatusCode = contextFeature.Error switch 
                    { 
                        NotFoundException => StatusCodes.Status404NotFound, 
                        _ => StatusCodes.Status500InternalServerError 
                    };
 
                    await context.Response.WriteAsync(new ErrorDetails() 
                    { 
                        StatusCode = context.Response.StatusCode, 
                        Message = contextFeature.Error.Message, 
                    }.ToString()); 
                } 
            }); 
        }); 
    }
    }
}