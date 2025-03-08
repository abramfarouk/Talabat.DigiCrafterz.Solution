using System.Net;

namespace Talabat.APIs.Error
{
    public class ApiValidationErrorsResponse : ApiErrorResponse
    {

        public IEnumerable<string> Errors { get; set; }
        public ApiValidationErrorsResponse() : base(HttpStatusCode.BadRequest)
        {
            Errors = new List<string>();
        }
    }
}
