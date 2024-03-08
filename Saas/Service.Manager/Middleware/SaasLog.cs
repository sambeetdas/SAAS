using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Saas.Model.Core;
using Saas.MongoDbLib.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            finally
            {
                httpContext.Request.EnableBuffering();

                await _logManager.InsertLog(new LogModel() { 
                            LogId = Guid.NewGuid(),
                            ApiType = httpContext.Request?.Method,
                            ApiName =   httpContext.Request?.Path.Value,
                            Request = httpContext.Request?.ContentLength == null ? String.Empty : await new System.IO.StreamReader(httpContext.Request?.Body, encoding: Encoding.UTF8, detectEncodingFromByteOrderMarks: false, leaveOpen: true).ReadToEndAsync(),
                            Response = httpContext.Response?.ContentLength == null ? String.Empty : await new System.IO.StreamReader(httpContext.Response?.Body).ReadToEndAsync(),
                            Scheme = httpContext.Request.Scheme,
                            Status = httpContext.Response?.StatusCode.ToString(),
                            RequestedDateTime = DateTime.Now,
                            User = "SAMBEET"
                });

                httpContext.Request.Body.Position = 0;
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
