using Microsoft.AspNetCore.Mvc;

namespace Checkout.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BaseApiController : Controller
    {
    }
}