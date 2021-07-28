using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Restaurant.OrderService.Infrastructure.Middleware.Filters
{
    public class HttpGlobalExceptionFilter
    {
        public static async Task OnHttpException(HttpContext context)
        {
            int statusCode;

            var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
            var exception = exceptionHandlerPathFeature.Error;

            if (exception is HttpRequestException httpRequestException)
            {
                statusCode = (int)httpRequestException.StatusCode;
            }
            else
            {
                statusCode = StatusCodes.Status500InternalServerError;
            }

            var responseError = CreateHttpContextErrorResponseBody(context, exception, statusCode);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            await context.Response.WriteAsync(JsonConvert.SerializeObject(responseError));
        }

        private static ValidationProblemDetails CreateHttpContextErrorResponseBody(HttpContext context, Exception exception, int statusCode)
        {
            return new ValidationProblemDetails
            {
                Instance = context.Request.Method,
                Status = statusCode,
                Detail = exception.Message,
                Type = context.GetType().ToString(),
            };
        }
    }
}
