using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Aerish.WebAPI.Middlewares
{
    //https://stackoverflow.com/questions/38630076/asp-net-core-web-api-exception-handling
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var _exception = ex.InnermostException();
            Type _exceptionType = _exception.GetType();

#if !DEBUG
            var _result = JsonSerializer.Serialize(new
            {
                type = _exceptionType.Name,
                message = _exception.Message
            });  
#else
            var _result = JsonSerializer.Serialize(new
            {
                type = _exceptionType.Name,
                message = _exception.Message,
                stactTrace = _exception.StackTrace
            });
            
#endif

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(_result);
        }
    }
}
