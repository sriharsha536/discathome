using System;
using Microsoft.AspNetCore.Builder;

namespace DVDRentalAPI.Helpers.Extensions
{
    public static class CustomExtensionsHelper
    {
        public static void UseExceptionMiddleware(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<ExceptionMiddlewareHelper>();
        }

        public static IApplicationBuilder UseRequestResponseLogging(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<RequestResponseLogHelper>();
        }
    }
}
