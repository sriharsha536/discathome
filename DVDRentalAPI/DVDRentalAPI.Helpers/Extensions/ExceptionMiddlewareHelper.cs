using System;
using System.Net;
using System.Threading.Tasks;
using DVDRentalAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace DVDRentalAPI.Helpers.Extensions
{
    public class ExceptionMiddlewareHelper
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger<ExceptionMiddlewareHelper> _logger;

        public ExceptionMiddlewareHelper(RequestDelegate requestDelegate, ILogger<ExceptionMiddlewareHelper> logger)
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _requestDelegate(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Occured: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return httpContext.Response.WriteAsync(new ErrorDetailsModel
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = "Internal Server Error Occured from the middleware"
            }.ToString());
        }
    }
}
