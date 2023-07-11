using ExceptionHandling;
using log4net.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
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
    public class GlobalErrorHandlingMiddleware : PageModel
    {
        private readonly RequestDelegate _next;
        readonly ILogger<GlobalErrorHandlingMiddleware> _logger;
        public GlobalErrorHandlingMiddleware(RequestDelegate next, ILogger<GlobalErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
                _logger.LogWarning("test");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
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
