using Checkout.Web.App.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Checkout.Web.App.Middleware
{
    /// <summary>
    /// middleware interceptor. When errors are thrown, intercepts, logs and returns error JSON
    /// </summary>
    /// <remarks>Designed for Api exception handling</remarks>
    public class ApiErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private ILogger<ApiErrorHandlingMiddleware> logger;

        public ApiErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, ILogger<ApiErrorHandlingMiddleware> logger)
        {
            this.logger = logger;

            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message, null);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = GetHttpStatusCode(ex);
            var result = JsonConvert.SerializeObject(new { error = ex.Message });

            context.Response.ContentType = Constants.ContentTypes.applicationJson;
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }

        private static HttpStatusCode GetHttpStatusCode(Exception ex)
        {
            if (ex is ApiException) return HttpStatusCode.InternalServerError;

            return HttpStatusCode.InternalServerError;
        }


    }
}
