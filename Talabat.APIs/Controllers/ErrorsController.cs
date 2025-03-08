using System.Net;

namespace Talabat.APIs.Controllers
{
    [Route("errors/{code}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        public IActionResult Error()
        {
            return NotFound(new ApiErrorResponse(HttpStatusCode.NotFound, "Not Found Page"));
        }
    }
}
