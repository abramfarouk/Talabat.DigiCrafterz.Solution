using System.Net;

namespace Talabat.APIs.Error
{
    public class ApiExceptionServerErrorResponse : ApiErrorResponse
    {
        public string? Details { get; set; }
        public ApiExceptionServerErrorResponse(HttpStatusCode StatusCode, string? message = null, string? details = null) : base(StatusCode, message)
        {

            Details = details;
        }
    }
}
