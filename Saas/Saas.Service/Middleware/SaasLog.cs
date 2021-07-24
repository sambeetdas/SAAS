using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Saas.Model.Core;
using Saas.MongoDbLib.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Saas.Service.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SaasLog
    {
        private readonly RequestDelegate _next;
        private readonly ILogManager _logManager;

        public SaasLog(RequestDelegate next, ILogManager logManager)
        {
            _next = next;
            _logManager = logManager;
        }

        public Task Invoke(HttpContext httpContext)
        {
            try
            {
                return _next(httpContext);
            }
            finally
            {
                string requestBody = string.Empty;
                string responseBody = string.Empty;
                if (httpContext.Request?.ContentLength != null)
                {
                    requestBody = new System.IO.StreamReader(httpContext.Request?.Body).ReadToEndAsync().Result;
                }

                if (httpContext.Response?.ContentLength != null)
                {
                    responseBody = new System.IO.StreamReader(httpContext.Request?.Body).ReadToEndAsync().Result;
                }
               

                _logManager.InsertLog(new LogModel() { 
                LogId = Guid.NewGuid(),
                ApiType = httpContext.Request?.Method,
                ApiName =   httpContext.Request?.Path.Value,
                Request = requestBody,
                Response = responseBody,
                Scheme = httpContext.Request.Scheme,
                Status = httpContext.Response?.StatusCode.ToString(),
                RequestedDateTime = DateTime.Now,
                User = "SAMBEET"
                });
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class SaasLogExtensions
    {
        public static IApplicationBuilder UseSaasLog(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SaasLog>();
        }
    }
}
