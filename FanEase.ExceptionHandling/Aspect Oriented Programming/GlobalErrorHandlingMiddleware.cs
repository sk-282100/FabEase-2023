using ExceptionHandling;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace FanEase.ExceptionHandling.Aspect_Oriented_Programming
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public GlobalErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = JsonSerializer.Serialize(new ResponseModel<object>()
            {
                message = exception.Message,
                data = null,
                Succeed = false,
                error = exception.GetType().ToString()
            });

            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(response);
        }
    }
}
