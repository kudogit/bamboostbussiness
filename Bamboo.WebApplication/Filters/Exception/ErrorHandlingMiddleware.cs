using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Bamboo.Util.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Bamboo.WebApplication.Filters.Exception
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await _next(context);
            }
            catch (System.Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, System.Exception exception)
        {
            string result;
            if (exception is BambooException bambooException)
            {
                result = JsonConvert.SerializeObject(new { isSuccess = false, code = bambooException.Code, message = bambooException.Message });
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int) bambooException.Code;
                await context.Response.WriteAsync(result).ConfigureAwait(true);
            };

            result = JsonConvert.SerializeObject(new { error = exception.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;;
            await context.Response.WriteAsync(result).ConfigureAwait(true);
        }
    }
}
