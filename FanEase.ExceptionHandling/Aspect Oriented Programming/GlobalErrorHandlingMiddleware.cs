using ExceptionHandling;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace FanEase.ExceptionHandling.Aspect_Oriented_Programming
{
    public class GlobalErrorHandlingMiddleware 
    {
        private readonly RequestDelegate _next;
        readonly  ILogger<SampleModel> _logger;
        
        public GlobalErrorHandlingMiddleware(RequestDelegate next, ILogger<SampleModel> logger)
        {
            _next = next;
            _logger = logger;
            
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
                var sample = new SampleModel(_logger);
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
