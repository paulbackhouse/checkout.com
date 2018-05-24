using Checkout.Web.App.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Checkout.Web.Tests.Middleware
{
    public class ApiErrorHandlingMiddlewareTest
    {
        private readonly Mock<RequestDelegate> next;
        private readonly Mock<ILogger<ApiErrorHandlingMiddleware>> logger;
        private readonly ApiErrorHandlingMiddleware ware;


        public ApiErrorHandlingMiddlewareTest()
        {
            next = new Mock<RequestDelegate>();
            logger = new Mock<ILogger<ApiErrorHandlingMiddleware>>();

            ware = new ApiErrorHandlingMiddleware(next.Object);
        }

        [Fact]
        public void ItHandlesException()
        {
            // TODO: add test for api middleware
        }

    }
}
